using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SkyCloudStorage.Controls;
using SkyCloudStorage.Modules;

namespace SkyCloudStorage
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //LoginControl loginControl = new LoginControl();
            Fingerprint fingerprint = new Fingerprint();
        }
    }
}
