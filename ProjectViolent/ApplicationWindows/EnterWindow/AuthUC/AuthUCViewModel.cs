using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectViolent;

namespace ProjectViolent.ApplicationWindows.EnterWindow.AuthUC
{
    public class AuthUCViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _passwordHash;
        private RelayCommand _buttonCommand;

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
                MessageBox.Show("");
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
