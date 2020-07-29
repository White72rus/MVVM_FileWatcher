using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SkyCloudStorage.ViewModel {
    internal class LoginMenuViewModel : BaseViewModel {

        private Visibility _loginMenuVisibility = Visibility.Visible;
        private DelegateCommand _delegateCommand;

        public Visibility LoginMenuVisibility
        {
            get => _loginMenuVisibility;
            private set
            {
                _loginMenuVisibility = value;
                OnPropertyChanged(nameof(LoginMenuVisibility));
            }
        }

        public ICommand SubmitLoginButton => RunCommand(_delegateCommand, () =>
        {
            LoginMenuVisibility = Visibility.Hidden;
        });

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
