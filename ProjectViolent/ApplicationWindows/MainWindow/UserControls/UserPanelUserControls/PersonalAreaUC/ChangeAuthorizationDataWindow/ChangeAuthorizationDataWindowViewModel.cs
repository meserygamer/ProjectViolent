using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.RegAuthDataUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.Security;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangeAuthorizationDataWindow
{
    public class ChangeAuthorizationDataWindowViewModel : INotifyPropertyChanged
    {
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
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

        public RelayCommand ConfirmChangesCommand
        {
            get => _confirmChangesCommand ?? (_confirmChangesCommand = new RelayCommand(a =>
            {
                if (Login == "" || Login is null)
                {
                    MessageBox.Show("Поле логина не заполнено");
                    return;
                }
                if (Password is null || Password == "")
                {
                    ChangeDataWithoutPassword();
                    return;
                }
                if (!Regex.IsMatch(Password, @"^(?=.*[A-Z])(?=(.*[a-z].*){3,})(?=(.*[0-9].*){2,})(?=.*[!@#$%^&*])[A-z0-9!@#$%^&*]{8,}$"))
                {
                    MessageBox.Show("Пароль не соответсвует требованиям (не менее 1 заглавного латинского символа," +
                        " не менее 3 строчных латинских символов," +
                        " не менее 2 цифры и не менее 1 спец. символа." +
                        " Общая длина пароля не менее 8 символов)");
                    return;
                }
                ChangeDataWithPassword();
                return;
            }));
        }


        public ChangeAuthorizationDataWindowViewModel(int userID)
        {
            GetUserLogin(userID);
            _userID = userID;
        }


        private void GetUserLogin(int userID) => Login = ChangeAuthorizationDataWindowModel.GetAuthorizationData(userID).Login;

        private void ChangeDataWithoutPassword()
        {
            if (RegAuthDataUCModel.IsLoginFree(Login) || Login == ChangeAuthorizationDataWindowModel.GetAuthorizationData(_userID).Login)
            {
                if (ChangeAuthorizationDataWindowModel.UpdateAuthorizationData(new AuthorizationData()
                {
                    Login = Login,
                    SecurePasssword = null
                }, _userID) == 0)
                {
                    MessageBox.Show("Данные успешно изменены!");
                    return;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка, данные не были изменены!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
        }

        private void ChangeDataWithPassword()
        {
            if (RegAuthDataUCModel.IsLoginFree(Login) || Login == ChangeAuthorizationDataWindowModel.GetAuthorizationData(_userID).Login)
            {
                string securePassword;
                using (SHA256 hash = SHA256.Create())
                {
                    securePassword = BitConverter.ToString(hash.ComputeHash(Encoding.UTF8.GetBytes(Password))).Replace("-", "");
                }
                if (ChangeAuthorizationDataWindowModel.UpdateAuthorizationData(new AuthorizationData()
                {
                    Login = Login,
                    SecurePasssword = securePassword
                }, _userID) == 0)
                {
                    MessageBox.Show("Данные успешно изменены!");
                    return;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка, данные не были изменены!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
        }


        private string _login;

        private string _password;

        private int _userID;

        private RelayCommand _confirmChangesCommand;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
