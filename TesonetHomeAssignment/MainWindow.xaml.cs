using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TesonetHomeAssignment.ViewModel;

namespace TesonetHomeAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new WindowViewModel(this);
            InitializeComponent();
            
        }
    }
}
