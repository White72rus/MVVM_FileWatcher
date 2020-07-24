using SkyCloudStorage.Modules;
using SkyCloudStorage.ViewModel;
using SkyCloudStorage.SetupApp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SkyCloudStorage.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            NotifyIcon.MouseDownAction = new Action(() => { viewModel.MainFormVisible(); });
            Initializer initializer = Initializer.Instance;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            NotifyIcon.Remove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            NotifyIcon.Tooltip = "Hello World";
            NotifyIcon.Set();

            Style styles = Resources["TostInfoStyle"] as Style;

            this.Top = SystemParameters.WorkArea.Y;
            this.Left = SystemParameters.WorkArea.X;
            this.Height = SystemParameters.WorkArea.Height;
            this.Width = SystemParameters.WorkArea.Width;

            Thickness margin = new Thickness(5, 5, 0, 0);

            //LoginMenu.Margin = margin; //(this.Width / 2) - LoginMenu.Width / 2;
        }
    }
}
