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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker
{
    /// <summary>
    /// Логика взаимодействия для DateTimePickerView.xaml
    /// </summary>
    public partial class DateTimePickerView : UserControl
    {
        public static readonly DependencyProperty SelectedDateTimeProperty = DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(DateTimePickerView));
        public static readonly DependencyProperty StartSelectedDateProperty = DependencyProperty.Register("StartSelectedDate", typeof(DateTime), typeof(DateTimePickerView));


        public DateTime SelectedDateTime
        {
            get { return (DateTime)GetValue(SelectedDateTimeProperty); }
            set { SetValue(SelectedDateTimeProperty, value); }
        }

        public DateTime StartSelectedDate
        {
            get { return (DateTime)GetValue(StartSelectedDateProperty); }
            set { SetValue(StartSelectedDateProperty, value); }
        }

        public DateTimePickerView()
        {
            InitializeComponent();
        }
    }

    public class proxy : Freezable
    {
        public static readonly DependencyProperty SelectedDateTimeProperty = DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(proxy));
        public static readonly DependencyProperty StartSelectedDateProperty = DependencyProperty.Register("StartSelectedDate", typeof(DateTime), typeof(proxy));

        public DateTime SelectedDateTime
        {
            get { return (DateTime)GetValue(SelectedDateTimeProperty); }
            set { SetValue(SelectedDateTimeProperty, value); }
        }

        public DateTime StartSelectedDate
        {
            get { return (DateTime)GetValue(StartSelectedDateProperty); }
            set { SetValue(StartSelectedDateProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new proxy();
        }
    }
}
