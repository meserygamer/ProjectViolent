﻿using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AdminPanelMainMenuUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private EnterInSystemUCViewModel _enterInSystemUCDataContext;
        private AdminPanelMainMenuUCViewModel _adminPanelMainMenuUCDataContext;

        public MainControlStates MainControlState
        {
            get => _mainControlState;
            set
            {
                _mainControlState = value;
                OnPropertyChanged(nameof(MainControlState));
            }
        }

        public EnterInSystemUCViewModel EnterInSystemUCDataContext
        {
            get => _enterInSystemUCDataContext;
            set
            {
                _enterInSystemUCDataContext = value;
                OnPropertyChanged(nameof(EnterInSystemUCDataContext));
            }
        }

        public AdminPanelMainMenuUCViewModel AdminPanelMainMenuUCDataContext
        {
            get => _adminPanelMainMenuUCDataContext;
            set
            {
                _adminPanelMainMenuUCDataContext = value;
                OnPropertyChanged(nameof(AdminPanelMainMenuUCDataContext));
            }
        }

        public MainWindowViewModel()
        {
            EnterInSystemUCDataContext = new EnterInSystemUCViewModel();
            AdminPanelMainMenuUCDataContext = new AdminPanelMainMenuUCViewModel();
            MainControlState = MainControlStates.Login;
            EnterInSystemUCDataContext.LoginWasComplete += EnterWasComplete;
        }

        public void EnterWasComplete(int UserID)
        {
            switch(MainWindowModel.DefineRole(UserID))
            {
                case 1:
                    MainControlState = MainControlStates.UserPanel;
                    break;
                case 2:
                    MainControlState = MainControlStates.AdminPanel;
                    break;
                default:
                    MessageBox.Show("Что-то пошло не так!");
                    break;
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
