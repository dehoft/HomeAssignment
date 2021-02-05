using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using TesonetHomeAssignment.UserInterfaceStructures;
using TesonetHomeAssignment.ViewModel.Base;
using TesonetHomeAssignment.Core;
using System;
using System.Collections.ObjectModel;
using TesonetHomeAssignment.DB.Models;
using System.Threading.Tasks;
using TesonetHomeAssignment.Helpers;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace TesonetHomeAssignment.ViewModel
{
    /// <summary>
    /// View model'is langui
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        private readonly MainWindow _mainWindow;
        private readonly Appcore _core = Appcore.Instance;
        private readonly HttpClient _client = Appcore.Client;
        public LoginStructure Login { get; set; }
        public Visibility VisibleToLoggedInUser { get; set; } = Visibility.Collapsed;
        public ICommand GetServersListFromApi { get; set; }
        public ICommand GetServersListFromDB { get; set; }
        public ObservableCollection<Servers> Servers { get; set; }

        public WindowViewModel(Window window)

        {
            _mainWindow = (MainWindow)window;
            Login = new LoginStructure(_mainWindow);
            Login.UpdateMainWindow += Update;
            GetServersListFromApi = new RelayCommand(async () => await GetServersListFromApiImpl());
            GetServersListFromDB = new RelayCommand(GetServersListFromDBImpl);
        }

        public void Update(object s, EventArgs e)
        {
            if (_core.IsUserLoggedIn)
            {
                VisibleToLoggedInUser = Visibility.Visible;
                return;
            }
            else
            {
                VisibleToLoggedInUser = Visibility.Collapsed;
                return;
            }
        }

        public async Task GetServersListFromApiImpl()
        {
            var servers = await ServersHelper.GetServersListFromApi(_client);
            var unitOfWork = UnitOfWorkHelper.GetUnitOfWork();


            unitOfWork.Servers.RemoveRange(unitOfWork.Servers.GetAll());
            unitOfWork.Servers.AddRange(servers);
            unitOfWork.Save();
        }

        public void GetServersListFromDBImpl()
        {
            var servers = ServersHelper.GetServersListFromDB();
            var orderedServers = servers.OrderByDescending(x => x.Distance).ToList();
            Servers = new ObservableCollection<Servers>();

            var id = 1;
            foreach(var server in orderedServers)
            {
                server.id = id;
                Servers.Add(server);
                id++;
            }     
        }
    }
}