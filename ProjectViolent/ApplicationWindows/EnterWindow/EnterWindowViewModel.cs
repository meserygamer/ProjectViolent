using ProjectViolent.ApplicationWindows.EnterWindow.AuthUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.EnterWindow
{
    public class EnterWindowViewModel : INotifyPropertyChanged
    {
        private AuthUCViewModel _authUCViewModel;
        private RelayCommand _authHyperLink;

        public AuthUCViewModel AuthUCViewModel
        {
            get => _authUCViewModel;
            set
            {
                _authUCViewModel = value;
                OnPropertyChanged(nameof(AuthUCViewModel));
            }
        }

        public RelayCommand AuthHyperLink
        {
            get => _authHyperLink ?? (new RelayCommand(obj =>
            {
                MessageBox.Show("");
            }));
        }

        public EnterWindowViewModel()
        {
            AuthUCViewModel = new AuthUCViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
