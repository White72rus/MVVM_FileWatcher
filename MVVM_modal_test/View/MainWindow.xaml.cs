using SkyCloudStorage.Modules;
using SkyCloudStorage.ViewModel;
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
            DataContext = viewModel;
            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new Action(() => this.Close());

            NotifyIcon.MouseDownAction = new Action(() => { viewModel.MainFormVisible(); });
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

        private void ItemsControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var obj = sender;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var obj = sender;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            MessageBox.Show("Deactivated");
        }
    }
}
