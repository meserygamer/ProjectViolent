using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangePersonalDataWindow
{
    /// <summary>
    /// Логика взаимодействия для ChangePersonalDataWindowView.xaml
    /// </summary>
    public partial class ChangePersonalDataWindowView : Window
    {
        public ChangePersonalDataWindowView()
        {
            InitializeComponent();
        }
    }

    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int genderID)
            {
                return genderID - 1;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int genderID)
            {
                return genderID + 1;
            }
            return null;
        }
    }
}
