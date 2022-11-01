using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ObjectInformation.ViewModels;
using ObjectInformation.Views;

namespace ObjectInformation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
