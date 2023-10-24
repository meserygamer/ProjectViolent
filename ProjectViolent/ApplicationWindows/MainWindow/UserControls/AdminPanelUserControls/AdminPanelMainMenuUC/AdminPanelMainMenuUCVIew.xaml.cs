using ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.LoginUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AdminPanelMainMenuUC
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelMainMenuUCVIew.xaml
    /// </summary>
    public partial class AdminPanelMainMenuUCVIew : UserControl
    {
        public static readonly DependencyProperty ShowAllUsersCommandDependencyProperty = DependencyProperty.Register("ShowAllUsersCommand", typeof(RelayCommand), typeof(AdminPanelMainMenuUCVIew));
        public static readonly DependencyProperty ShowMainDataBaseTableCommandDependencyProperty = DependencyProperty.Register("ShowMainDataBaseTableCommand", typeof(RelayCommand), typeof(AdminPanelMainMenuUCVIew));
        public static readonly DependencyProperty AddNewItemCommandDependencyProperty = DependencyProperty.Register("AddNewItemCommand", typeof(RelayCommand), typeof(AdminPanelMainMenuUCVIew));
        public static readonly DependencyProperty AddNewAuctionItemCommandDependencyProperty = DependencyProperty.Register("AddNewAuctionItemCommand", typeof(RelayCommand), typeof(AdminPanelMainMenuUCVIew));

        public RelayCommand ShowAllUsersCommand
        {
            get => (RelayCommand)GetValue(ShowAllUsersCommandDependencyProperty);
            set => SetValue(ShowAllUsersCommandDependencyProperty, value);
        }

        public RelayCommand ShowMainDataBaseTableCommand
        {
            get => (RelayCommand)GetValue(ShowMainDataBaseTableCommandDependencyProperty);
            set => SetValue(ShowMainDataBaseTableCommandDependencyProperty, value);
        }

        public RelayCommand AddNewItemCommand
        {
            get => (RelayCommand)GetValue(AddNewItemCommandDependencyProperty);
            set => SetValue(AddNewItemCommandDependencyProperty, value);
        }

        public RelayCommand AddNewAuctionItemCommand
        {
            get => (RelayCommand)GetValue(AddNewAuctionItemCommandDependencyProperty);
            set => SetValue(AddNewAuctionItemCommandDependencyProperty, value);
        }

        public AdminPanelMainMenuUCVIew()
        {
            InitializeComponent();
        }
    }
}
