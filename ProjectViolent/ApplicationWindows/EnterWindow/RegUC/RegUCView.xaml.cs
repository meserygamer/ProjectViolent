using ProjectViolent.ApplicationWindows.EnterWindow.AuthUC;
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

namespace ProjectViolent.ApplicationWindows.EnterWindow.RegUC
{
    /// <summary>
    /// Логика взаимодействия для RegUCView.xaml
    /// </summary>
    public partial class RegUCView : UserControl
    {
        public static readonly DependencyProperty HyperLinkCommandDependencyProperty = DependencyProperty.Register("HyperLinkCommand", typeof(RelayCommand), typeof(RegUCView));
        public static readonly DependencyProperty EnterWindowStateDependencyProperty = DependencyProperty.Register("EnterWindowState", typeof(StateOfEnterWindow), typeof(RegUCView));

        public RelayCommand HyperLinkCommand
        {
            get => (RelayCommand)GetValue(HyperLinkCommandDependencyProperty);
            set => SetValue(HyperLinkCommandDependencyProperty, value);
        }

        public StateOfEnterWindow EnterWindowState
        {
            get => (StateOfEnterWindow)GetValue(EnterWindowStateDependencyProperty);
            set => SetValue(EnterWindowStateDependencyProperty, value);
        }

        public RegUCView()
        {
            InitializeComponent();
        }
    }
}
