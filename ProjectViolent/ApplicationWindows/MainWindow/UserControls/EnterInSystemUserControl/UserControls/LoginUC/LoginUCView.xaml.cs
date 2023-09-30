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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.LoginUC
{

    /// <summary>
    /// Логика взаимодействия для LoginUCView.xaml
    /// </summary>
    public partial class LoginUCView : UserControl
    {
        public static readonly DependencyProperty HyperLinkCommandDependencyProperty = DependencyProperty.Register("HyperLinkCommand", typeof(RelayCommand), typeof(LoginUCView));

        public RelayCommand HyperLinkCommand
        {
            get => (RelayCommand)GetValue(HyperLinkCommandDependencyProperty);
            set => SetValue(HyperLinkCommandDependencyProperty, value);
        }

        public LoginUCView()
        {
            InitializeComponent();
        }
    }
}
