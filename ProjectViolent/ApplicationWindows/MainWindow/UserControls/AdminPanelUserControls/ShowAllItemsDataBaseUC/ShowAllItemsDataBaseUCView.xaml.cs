using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC.ImageSelectorUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC;
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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowAllItemsDataBaseUC
{
    /// <summary>
    /// Логика взаимодействия для ShowAllItemsDataBaseUCView.xaml
    /// </summary>
    public partial class ShowAllItemsDataBaseUCView : UserControl
    {
        public static readonly DependencyProperty MoveOnPreviousCommandDependencyProperty = DependencyProperty.Register("MoveOnPreviousCommand", typeof(RelayCommand), typeof(ShowAllItemsDataBaseUCView));
        public static readonly DependencyProperty CreateNewAuctionItemCommandDependencyProperty = DependencyProperty.Register("CreateNewAuctionItemCommand", typeof(RelayCommand), typeof(ShowAllItemsDataBaseUCView));


        public RelayCommand MoveOnPreviousCommand
        {
            get => (RelayCommand)GetValue(MoveOnPreviousCommandDependencyProperty);
            set => SetValue(MoveOnPreviousCommandDependencyProperty, value);
        }

        public RelayCommand CreateNewAuctionItemCommand
        {
            get => (RelayCommand)GetValue(CreateNewAuctionItemCommandDependencyProperty);
            set => SetValue(CreateNewAuctionItemCommandDependencyProperty, value);
        }

        public ShowAllItemsDataBaseUCView()
        {
            InitializeComponent();
        }
    }
}
