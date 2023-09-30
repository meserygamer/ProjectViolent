using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.LoginUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.RegAuthDataUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.RegUserDataUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl
{
    public enum StateOfEnterWindow
    {
        AuthOpen,
        RegOpen,
        SetPersonalDataOpen
    }

    public class EnterInSystemUCViewModel : INotifyPropertyChanged
    {
        private LoginUCViewModel _loginUCViewModel;
        private RegAuthDataUCViewModel _regAuthDataUCViewModel;
        private RegUserDataUCViewModel _regUserDataUCViewModel;
        private RelayCommand _authHyperLink;
        private RelayCommand _regHyperLink;
        private StateOfEnterWindow _currentStateOfEnterWindow;

        public LoginUCViewModel LoginUCViewModel
        {
            get => _loginUCViewModel;
            set
            {
                _loginUCViewModel = value;
                OnPropertyChanged(nameof(LoginUCViewModel));
            }
        }

        public RegAuthDataUCViewModel RegAuthDataUCViewModel
        {
            get => _regAuthDataUCViewModel;
            set
            {
                _regAuthDataUCViewModel = value;
                OnPropertyChanged(nameof(RegAuthDataUCViewModel));
            }
        }

        public RegUserDataUCViewModel RegUserDataUCViewModel
        {
            get => _regUserDataUCViewModel;
            set
            {
                _regUserDataUCViewModel = value;
                OnPropertyChanged(nameof(RegUserDataUCViewModel));
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

        public EnterInSystemUCViewModel()
        {
            LoginUCViewModel = new LoginUCViewModel();
            RegAuthDataUCViewModel = new RegAuthDataUCViewModel();
            RegUserDataUCViewModel = new RegUserDataUCViewModel();
            RegAuthDataUCViewModel.PropertyChanged += NextRegPage;
            RegUserDataUCViewModel.RegistrationWasComplete += LoginInAccountWasComplete;
            LoginUCViewModel.LoginWasComplete += LoginInAccountWasComplete;
            CurrentStateOfEnterWindow = StateOfEnterWindow.AuthOpen;
        }

        private void LoginInAccountWasComplete(int obj)
        {
            Application.Current.Resources.Add("UserID", obj);
            MessageBox.Show($"Вы вошли в аккаунт ваш номер: {obj}");
            //
        }

        private void NextRegPage(object obj, PropertyChangedEventArgs a)
        {
            if (a.PropertyName == "EnterWindowState")
            {
                CurrentStateOfEnterWindow = ((RegAuthDataUCViewModel)obj).EnterWindowState;
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
