using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AdminPanelMainMenuUC;
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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowInformationAboutAllUsersUC
{
    /// <summary>
    /// Логика взаимодействия для ShowInformationAboutAllUsersUCView.xaml
    /// </summary>
    public partial class ShowInformationAboutAllUsersUCView : UserControl
    {
        public static readonly DependencyProperty MoveOnPreviousCommandDependencyProperty = DependencyProperty.Register("MoveOnPreviousCommand", typeof(RelayCommand), typeof(ShowInformationAboutAllUsersUCView));

        public RelayCommand MoveOnPreviousCommand
        {
            get => (RelayCommand)GetValue(MoveOnPreviousCommandDependencyProperty);
            set => SetValue(MoveOnPreviousCommandDependencyProperty, value);
        }

        public ShowInformationAboutAllUsersUCView()
        {
            InitializeComponent();
        }
    }
}
