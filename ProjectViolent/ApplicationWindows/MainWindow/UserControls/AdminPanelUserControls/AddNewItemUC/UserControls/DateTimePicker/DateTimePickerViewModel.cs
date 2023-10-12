using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker
{
    internal class DateTimePickerViewModel : INotifyPropertyChanged
    {
        DateTime _dateTimeOnClock;
        RelayCommand _addHour;
        RelayCommand _putAwayHour;
        RelayCommand _addMinute;
        RelayCommand _putAwayMinute;

        public DateTime DateTimeOnClock
        {
            get => _dateTimeOnClock;
            set
            {
                _dateTimeOnClock = value;
                OnPropertyChanged(nameof(DateTimeOnClock));
            }
        }

        public DateTime SelectedDate
        {
            get=> _dateTimeOnClock;
            set
            {
                _dateTimeOnClock = new DateTime(value.Year, value.Month, value.Day, _dateTimeOnClock.Hour, _dateTimeOnClock.Minute, 0);
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public RelayCommand AddHour
        {
            get => _addHour ?? (_addHour = new RelayCommand(a => 
            {
                _dateTimeOnClock.AddHours(1);
            }));
        }

        public RelayCommand AddMinute
        {
            get => _addHour ?? (_addHour = new RelayCommand(a =>
            {
                _dateTimeOnClock.AddMinutes(1);
            }));
        }

        public RelayCommand putAwayHour
        {
            get => _addHour ?? (_addHour = new RelayCommand(a =>
            {
                _dateTimeOnClock.AddHours(-1);
            }));
        }

        public RelayCommand putAwayMinute
        {
            get => _addHour ?? (_addHour = new RelayCommand(a =>
            {
                _dateTimeOnClock.AddMinutes(-1);
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    class HourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime date)
            {
                if (date.Hour.ToString().Length < 2)
                {
                    return "0" + date.Hour.ToString();
                }
                else
                {
                    return date.Hour.ToString();
                }
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class MinutesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if(date.Minute.ToString().Length < 2)
                {
                    return "0" + date.Minute.ToString();
                }
                else
                {
                    return date.Minute.ToString();
                }
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
