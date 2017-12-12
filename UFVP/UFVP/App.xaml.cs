using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace UFVP
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow;
            if(e.Args.Length > 0 && e.Args[0] != "")
            {
                mainWindow = new MainWindow(e.Args[0]);
            }
            else
            {
                mainWindow = new MainWindow();
            }
            mainWindow.Show();
        }
    }
}
