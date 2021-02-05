using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TesonetHomeAssignment.Core;
using TesonetHomeAssignment.Helpers;
using TesonetHomeAssignment.ViewModel.Base;

namespace TesonetHomeAssignment.UserInterfaceStructures
{
    public class LoginStructure : BaseViewModel
    {

        private readonly Appcore _core = Appcore.Instance;
        private readonly HttpClient _client = Appcore.Client;
        private readonly MainWindow _mainWindow;

        public Visibility LogOutButtonVisibility { get; set; }
        public Visibility LogInButtonVisibility { get; set; }               
        public Visibility WrongCredentialsVisibility { get; set; }   

        public ICommand LogIn { get; set; }
        public ICommand LogOut { get; set; }

        public event EventHandler UpdateMainWindow;

        public string ErrorMessage { get; set; }
        public string UserName { get; set; }

        public LoginStructure(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            LogIn = new RelayCommand(async () => await LogInImpl());
            LogOut = new RelayCommand(LogOutImpl);            
        }

        /// <summary>
        /// Prisijungimo komandos implementavimas
        /// </summary>
        public async Task LogInImpl()
        {
            var token = await LoginHelper.SendLoginRequest(UserName, _mainWindow.FloatingPasswordBox.Password, _client);
            
            if (token == null)
            {
                ErrorMessage = "Blogi prisijungimo duomenys";
                WrongCredentialsVisibility = Visibility.Visible;

                return;
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _core.IsUserLoggedIn = true;
            _mainWindow.DialogHost.IsOpen = false;
            UpdateMainWindow.Invoke(this, EventArgs.Empty);
            ChangeVisibilityAfterLogIn();
        }


        /// <summary>
        /// Atsijungimo komandos implementavimas
        /// </summary>
        public void LogOutImpl()
        {            
            _core.IsUserLoggedIn = false;            
            _client.DefaultRequestHeaders.Remove("Authorization");

            _mainWindow.FloatingPasswordBox.Password = "";           
            LogInButtonVisibility = Visibility.Visible;
            LogOutButtonVisibility = Visibility.Collapsed;
            UpdateMainWindow.Invoke(this, EventArgs.Empty);
        }

        private void ChangeVisibilityAfterLogIn()
        {
            LogInButtonVisibility = Visibility.Collapsed;
            LogOutButtonVisibility = Visibility.Visible;
            WrongCredentialsVisibility = Visibility.Collapsed;
            _mainWindow.FloatingPasswordBox.Password = "";
            UserName = "";
        }

    }
}
