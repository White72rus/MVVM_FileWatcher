using SkyCloudStorage.Model;
using SkyCloudStorage.View;
using SkyCloudStorage.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;

namespace SkyCloudStorage.ViewModel
{
    public class MainWindowViewModel : BaseViewModel {
        //private Visibility _loginMenuVisibility = Visibility.Visible;
        private Visibility _mainFormVisibility = Visibility.Visible;
        private DelegateCommand _delegateCommand;
        private string _title;
        private double _loginMenuTop;
        private double _loginMenuLeft;
        private string _path = @"x:\DownloadFTP";

        public Page main;

        // Делегат из View, метода закрытия окна.
        public Action CloseAction { get; set; }

        //public Visibility LoginMenuVisibility
        //{
        //    get => _loginMenuVisibility;
        //    private set
        //    {
        //        _loginMenuVisibility = value;
        //        OnPropertyChanged(nameof(LoginMenuVisibility));
        //    }
        //}

        public Visibility MainFormVisibility
        {
            get =>_mainFormVisibility;
            private set
            {
                _mainFormVisibility = value;
                OnPropertyChanged(nameof(MainFormVisibility));
            }
        }

        public string Title
        {
            get => _title;
            private set { _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public double LoginMenuTop
        {
            get => _loginMenuTop;
            private set
            {
                _loginMenuTop = value;
                OnPropertyChanged(nameof(LoginMenuTop));
            }
        }

        public double LoginMenuLeft
        {
            get => _loginMenuLeft;
            private set
            {
                _loginMenuLeft = value;
                OnPropertyChanged(nameof(LoginMenuLeft));
            }
        }

        public ObservableCollection<string> List
        {
            get => _list;
            private set { _list = value;
                OnPropertyChanged(nameof(List));
            }
        }

        public ObservableCollection<PanelInfo> ListInfo
        {
            get => _listInfo;
            private set
            {
                _listInfo = value;
                OnPropertyChanged(nameof(ListInfo));
            }
        }

        public ObservableCollection<InfoTost> ListInfoTosts
        {
            get => _listInfoTosts;
            private set
            {
                _listInfoTosts = value;
                OnPropertyChanged(nameof(ListInfoTosts));
            }
        }

        public ICommand ButtonOnClicCommand => RunCommand(_delegateCommand, OnClic);
        public ICommand OpenFolderCommand => RunCommand(_delegateCommand, OpenFolder);
        //public ICommand SubmitLoginButton => RunCommand(_delegateCommand, () =>
        //{
        //    LoginMenuVisibility = Visibility.Hidden;
        //});
        public ICommand OnDeactivated => RunCommand(_delegateCommand, ()=> {
            if (MainFormVisibility == Visibility.Visible)
                MainFormVisibility = Visibility.Hidden;
        });

        /// <summary>
        /// Комманда на закрытие окна программы.
        /// </summary>
        public DelegateCommand OnCloseCommand => RunCommand(_delegateCommand, OnClose);

        void OnClic()
        {
            Style styles = Application.Current.TryFindResource("TostInfoStyle") as Style;
        }

        void OnClose()
        {
            //CloseAction.Invoke();
            Application.Current.Shutdown();
        }

        void OpenFolder()
        {
            if (!new DirectoryInfo(_path).Exists)
                return;
            Process.Start("explorer.exe", _path);
        }

        public void MainFormVisible()
        {
            if (MainFormVisibility == Visibility.Visible)
                MainFormVisibility = Visibility.Hidden;
            else
                MainFormVisibility = Visibility.Visible;
        }

        private ObservableCollection<string> _list = new ObservableCollection<string> {
            //"Петя",
            //"Вася",
            //"Юра",
            //"Дима",
            //"Сережа"
        };

        private ObservableCollection<PanelInfo> _listInfo = new ObservableCollection<PanelInfo>
        {
            new PanelInfo(70,200, "1"),
            new PanelInfo(70,200, "2"),
            new PanelInfo(70,200, "3"),
            new PanelInfo(70,200, "4"),
            new PanelInfo(70,200, "5"),
            new PanelInfo(70,200, "6"),
            new PanelInfo(70,200, "7"),
            new PanelInfo(70,200, "8"),
        };

        private ObservableCollection<InfoTost> _listInfoTosts = new ObservableCollection<InfoTost>
        {
            new InfoTost("Name_0", "Desc_0"),
            new InfoTost("Name_1", "Desc_1"),
            new InfoTost("Name_2", "Desc_2"),
            new InfoTost("Name_3", "Desc_3"),
            new InfoTost("Name_4", "Desc_4"),
            new InfoTost("Name_5", "Desc_5"),
            new InfoTost("Name_6", "Desc_6"),
            new InfoTost("Name_7", "Desc_7"),
            
        };

        /// <summary>
        /// Метод исполнения комманд.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private DelegateCommand RunCommand(DelegateCommand command, Action action, bool canExec = true)
        {
            return command ?? (command = new DelegateCommand(obj => { action(); }, obj => canExec));
        }
    }
}
