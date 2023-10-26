using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC;
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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC
{
    /// <summary>
    /// Логика взаимодействия для AddNewItemUCView.xaml
    /// </summary>
    public partial class AddNewItemUCView : UserControl
    {
        public static readonly DependencyProperty BackOnPreviousPageDependencyProperty = DependencyProperty.Register("BackOnPreviousPage", typeof(RelayCommand), typeof(AddNewItemUCView));

        public RelayCommand BackOnPreviousPage
        {
            get => (RelayCommand)GetValue(BackOnPreviousPageDependencyProperty);
            set => SetValue(BackOnPreviousPageDependencyProperty, value);
        }

        public AddNewItemUCView()
        {
            InitializeComponent();
        }
    }
}
