using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow
{
    public enum MainControlStates
    {
        Login,
        AdminPanel,
        UserPanel
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainControlStates _mainControlState;

        public MainControlStates MainControlState
        {
            get => _mainControlState;
            set
            {
                _mainControlState = value;
                OnPropertyChanged(nameof(MainControlState));
            }
        }

        public MainWindowViewModel()
        {
            MainControlState = MainControlStates.Login;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
