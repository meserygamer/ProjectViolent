using ProjectViolent.ApplicationWindows.EnterWindow.AuthUC;
using ProjectViolent.ApplicationWindows.EnterWindow.RegUC;
using ProjectViolent.ApplicationWindows.EnterWindow.SetPersonalDataUC;
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
    public enum StateOfEnterWindow
    {
        AuthOpen,
        RegOpen,
        SetPersonalDataOpen,
        RegistrationIsOver
    }
    public class EnterWindowViewModel : INotifyPropertyChanged
    {
        private AuthUCViewModel _authUCViewModel;
        private RegUCViewModel _regUCViewModel;
        private SetPersonalDataUCViewModel _setPersonalDataUCViewModel;
        private RelayCommand _authHyperLink;
        private RelayCommand _regHyperLink;
        private StateOfEnterWindow _currentStateOfEnterWindow;

        public AuthUCViewModel AuthUCViewModel
        {
            get => _authUCViewModel;
            set
            {
                _authUCViewModel = value;
                OnPropertyChanged(nameof(AuthUCViewModel));
            }
        }

        public RegUCViewModel RegUCViewModel
        {
            get => _regUCViewModel;
            set
            {
                _regUCViewModel = value;
                OnPropertyChanged(nameof(RegUCViewModel));
            }
        }

        public SetPersonalDataUCViewModel SetPersonalDataUCViewModel
        {
            get => _setPersonalDataUCViewModel;
            set
            {
                _setPersonalDataUCViewModel = value;
                OnPropertyChanged(nameof(SetPersonalDataUCViewModel));
            }
        }

        public RelayCommand AuthHyperLink
        {
            get => _authHyperLink ?? (new RelayCommand(obj =>
            {
                CurrentStateOfEnterWindow = StateOfEnterWindow.RegOpen;
            }));
        }

        public RelayCommand RegHyperLink
        {
            get => _authHyperLink ?? (new RelayCommand(obj =>
            {
                CurrentStateOfEnterWindow = StateOfEnterWindow.AuthOpen;
            }));
        }

        public StateOfEnterWindow CurrentStateOfEnterWindow
        {
            get => _currentStateOfEnterWindow;
            set
            {
                _currentStateOfEnterWindow = value;
                OnPropertyChanged(nameof(CurrentStateOfEnterWindow));
            }
        }

        public EnterWindowViewModel()
        {
            AuthUCViewModel = new AuthUCViewModel();
            RegUCViewModel = new RegUCViewModel();
            SetPersonalDataUCViewModel = new SetPersonalDataUCViewModel();
            RegUCViewModel.PropertyChanged += NextRegPage;
            SetPersonalDataUCViewModel.PropertyChanged += AccountRegistration;
            CurrentStateOfEnterWindow = StateOfEnterWindow.AuthOpen;
        }

        private void NextRegPage(object obj, PropertyChangedEventArgs a)
        {
            if(a.PropertyName == "EnterWindowState")
            {
                CurrentStateOfEnterWindow = ((RegUCViewModel)obj).EnterWindowState;
            }
        }

        private void AccountRegistration(object obj, PropertyChangedEventArgs a)
        {
            if (a.PropertyName == "EnterWindowState")
            {
                EnterWindowModel.RegistrationUser();
                MessageBox.Show("Регистрация успешно завершена");
                //CurrentStateOfEnterWindow = ((SetPersonalDataUCViewModel)obj).EnterWindowState;
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
