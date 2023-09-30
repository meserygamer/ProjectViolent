using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.LoginUC
{
    public class LoginUCViewModel: INotifyPropertyChanged
    {
        private string _login;
        private string _passwordHash;
        private RelayCommand _buttonCommand;
        public event Action<int> LoginWasComplete;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                _passwordHash = value;
                OnPropertyChanged(nameof(PasswordHash));
            }
        }

        public RelayCommand ButtonCommand
        {
            get => _buttonCommand ?? (new RelayCommand(obj =>
            {
                int? UserID = null;
                if (Login is null || Login.Length == 0)
                {
                    MessageBox.Show("Заполните поле логина");
                }
                else if (PasswordHash is null || PasswordHash.Length == 0)
                {
                    MessageBox.Show("Заполните поле пароля");
                }
                else if ((UserID = LoginUCModel.CheckUser(Login, PasswordHash)) != null)
                {
                    LoginWasComplete((int)UserID);
                }
                else
                {
                    MessageBox.Show("Неправильно введен пароль или логин");
                }
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
