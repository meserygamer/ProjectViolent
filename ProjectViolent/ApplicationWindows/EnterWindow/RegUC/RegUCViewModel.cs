using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ProjectViolent;

namespace ProjectViolent.ApplicationWindows.EnterWindow.RegUC
{
    public class RegUCViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _passwordHash;
        private string _password;
        private string _confirmPasswordHash;
        private RelayCommand _buttonCommand;
        private StateOfEnterWindow _enterWindowState;

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

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPasswordHash
        {
            get => _confirmPasswordHash;
            set
            {
                _confirmPasswordHash = value;
                OnPropertyChanged(nameof(ConfirmPasswordHash));
            }
        }

        public RelayCommand ButtonCommand
        {
            get => _buttonCommand ?? (new RelayCommand(obj =>
            {
                if (Login == "" || Login is null)
                {
                    MessageBox.Show("Поле логина не заполнено");
                }
                else if (Password is null || Password == "")
                {
                    MessageBox.Show("Поле пароля не заполнено");
                }
                else if (!Regex.IsMatch(Password, @"^(?=.*[A-Z])(?=(.*[a-z].*){3,})(?=(.*[0-9].*){2,})(?=.*[!@#$%^&*])[A-z0-9!@#$%^&*]{8,}$"))
                {
                    MessageBox.Show("Пароль не соответсвует требованиям (не менее 1 заглавного латинского символа," +
                        " не менее 3 строчных латинских символов," +
                        " не менее 2 цифры и не менее 1 спец. символа." +
                        " Общая длина пароля не менее 8 символов)");
                }
                else if(RegUCModel.IsLoginFree(Login))
                {
                    Application.Current.Resources.Add("RegData", new AuthorizationData() 
                    { 
                        Login = Login,
                        SecurePasssword = PasswordHash
                    });
                    EnterWindowState = StateOfEnterWindow.SetPersonalDataOpen;
                }
            }));
        }

        public StateOfEnterWindow EnterWindowState
        {
            get => _enterWindowState;
            set
            {
                _enterWindowState = value;
                OnPropertyChanged(nameof(EnterWindowState));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
