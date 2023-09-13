using ProjectViolent.ApplicationWindows.EnterWindow.AuthUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.EnterWindow
{
    public class EnterWindowViewModel : INotifyPropertyChanged
    {
        private AuthUCViewModel _authUCViewModel;

        public AuthUCViewModel AuthUCViewModel
        {
            get => _authUCViewModel;
            set
            {
                _authUCViewModel = value;
                OnPropertyChanged(nameof(AuthUCViewModel));
            }
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
