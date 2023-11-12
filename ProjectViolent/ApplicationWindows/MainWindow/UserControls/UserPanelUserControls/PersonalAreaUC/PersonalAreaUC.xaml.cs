using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC
{
    /// <summary>
    /// Логика взаимодействия для PersonalAreaUC.xaml
    /// </summary>
    public partial class PersonalAreaUC : UserControl
    {
        public static readonly DependencyProperty BackOnPreviousPageCommandProperty =
            DependencyProperty.Register("BackOnPreviousPageCommand", typeof(RelayCommand), typeof(PersonalAreaUC));


        public RelayCommand BackOnPreviousPageCommand
        {
            get => (RelayCommand) GetValue(BackOnPreviousPageCommandProperty);
            set => SetValue(BackOnPreviousPageCommandProperty, value);
        }


        public PersonalAreaUC()
        {
            InitializeComponent();
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                return null;
            }
            if(value is ObservableCollection<BitmapImage> images)
            {
                return images[System.Convert.ToInt32(parameter)];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisabilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is bool))
            {
                return null;
            }
            switch((bool)value)
            {
                case true:
                    return Visibility.Visible;
                case false:
                    return Visibility.Hidden;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
