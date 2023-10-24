﻿using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AdminPanelMainMenuUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowInformationAboutAllUsersUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC;
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
        ShowAllUsers,
        ShowMainTable,
        AddNewItem,
        AddNewAuctionItem,
        UserPanel
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainControlStates _mainControlState;
        private EnterInSystemUCViewModel _enterInSystemUCDataContext;
        private AdminPanelMainMenuUCViewModel _adminPanelMainMenuUCDataContext;
        private ShowInformationAboutAllUsersUCViewModel _showInformationAboutAllUsersUCDataContext;
        private ShowMainTableDataBaseUCViewModel _showMainTableDataBaseUCDataContext;
        private AddNewItemUCViewModel _addNewItemUCDataContext;
        private AddNewAuctionItemUCViewModel _addNewAuctionItemUCDataContext;
        private RelayCommand _showAllUserCommand;
        private RelayCommand _showMainTableCommand;
        private RelayCommand _moveOnAdminPanel;
        private RelayCommand _showAddNewItemCommand;
        private RelayCommand _showAddNewAuctionItemCommand;

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

        public ShowInformationAboutAllUsersUCViewModel ShowInformationAboutAllUsersUCDataContext
        {
            get => _showInformationAboutAllUsersUCDataContext;
            set
            {
                _showInformationAboutAllUsersUCDataContext = value;
                OnPropertyChanged(nameof(ShowInformationAboutAllUsersUCDataContext));
            }
        }

        public ShowMainTableDataBaseUCViewModel ShowMainTableDataBaseUCDataContext
        {
            get => _showMainTableDataBaseUCDataContext;
            set
            {
                _showMainTableDataBaseUCDataContext = value;
                OnPropertyChanged(nameof(ShowMainTableDataBaseUCDataContext));
            }
        }

        public AddNewItemUCViewModel AddNewItemUCDataContext
        {
            get => _addNewItemUCDataContext;
            set
            {
                _addNewItemUCDataContext = value;
                OnPropertyChanged();
            }
        }

        public AddNewAuctionItemUCViewModel AddNewAuctionItemUCDataContext
        {
            get => _addNewAuctionItemUCDataContext;
            set
            {
                _addNewAuctionItemUCDataContext = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ShowAllUserCommand
        {
            get => _showAllUserCommand ?? (_showAllUserCommand = new RelayCommand(a => 
            {
                ShowInformationAboutAllUsersUCDataContext = new ShowInformationAboutAllUsersUCViewModel();
                MainControlState = MainControlStates.ShowAllUsers;
            }));
        }

        public RelayCommand ShowMainTableCommand
        {
            get => _showMainTableCommand ?? (_showMainTableCommand = new RelayCommand(a => 
            {
                ShowMainTableDataBaseUCDataContext = new ShowMainTableDataBaseUCViewModel();
                MainControlState = MainControlStates.ShowMainTable;
            }));
        }

        public RelayCommand MoveOnAdminPanel
        {
            get => _moveOnAdminPanel ?? (_moveOnAdminPanel = new RelayCommand(a => 
            {
                MainControlState = MainControlStates.AdminPanel;
            }));
        }

        public RelayCommand ShowAddNewItemCommand
        {
            get => _showAddNewItemCommand ?? (_showAddNewItemCommand = new RelayCommand(a =>
            {
                AddNewItemUCDataContext = new AddNewItemUCViewModel();
                MainControlState = MainControlStates.AddNewItem;
            }));
        }

        public RelayCommand ShowAddNewAuctionItemCommand
        {
            get => _showAddNewAuctionItemCommand ?? (_showAddNewAuctionItemCommand = new RelayCommand(a =>
            {
                AddNewAuctionItemUCDataContext = new AddNewAuctionItemUCViewModel();
                MainControlState = MainControlStates.AddNewAuctionItem;
            }));
        }

        public MainWindowViewModel()
        {
            EnterInSystemUCDataContext = new EnterInSystemUCViewModel();
            AdminPanelMainMenuUCDataContext = new AdminPanelMainMenuUCViewModel();
            MainControlState = MainControlStates.Login;
            EnterInSystemUCDataContext.LoginWasComplete += EnterWasComplete;
            EnterInSystemUCDataContext.LoginWasComplete += AdminPanelMainMenuUCDataContext.NameAndSurName;
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
