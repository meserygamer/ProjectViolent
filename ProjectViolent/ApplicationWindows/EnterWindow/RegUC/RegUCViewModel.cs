using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectViolent;

namespace ProjectViolent.ApplicationWindows.EnterWindow.RegUC
{
    public class RegUCViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _passwordHash;
        private string _confirmPasswordHash;
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
