using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AdminPanelMainMenuUC
{
    public class AdminPanelMainMenuUCViewModel : INotifyPropertyChanged
    {
        private string _surName;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string SurName
        {
            get => _surName;
            set
            {
                _surName = value;
                OnPropertyChanged(nameof(SurName));
            }
        }

        public AdminPanelMainMenuUCViewModel()
        {
            
        }

        public void NameAndSurName(int UserID)
        {
            Name = AdminPanelMainMenuUCModel.FindNameFromId(UserID);
            SurName = AdminPanelMainMenuUCModel.FindSurNameFromId(UserID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    class DefineFIO : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)values[0] + " " + (string) values[1];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
