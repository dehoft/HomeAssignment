using System.Windows;
using TesonetHomeAssignment.Core;

namespace TesonetHomeAssignment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Appcore core = Appcore.Instance;

            MainWindow = new MainWindow();

            MainWindow.Show();
            MainWindow.Activate();
        }
    }
}
