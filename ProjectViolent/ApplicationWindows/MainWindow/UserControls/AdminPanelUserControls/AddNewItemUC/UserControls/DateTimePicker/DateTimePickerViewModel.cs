using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker
{
    public class DateTimePickerViewModel : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SelectedDateTimeProperty = DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(DateTimePickerViewModel));

        public DateTime SelectedDateTime
        {
            get { return (DateTime)GetValue(SelectedDateTimeProperty); }
            set { SetValue(SelectedDateTimeProperty, value); }
        }

        public ObservableCollection<string> HoursList
        {
            get => (new ObservableCollection<string>(_hours.ToList().ConvertAll<string>(a => a.ToString()))).TransformationForEach(a => (a.Length == 1) ? "0" + a : a);
        }
        public ObservableCollection<string> MinutsList
        {
            get => (new ObservableCollection<string>(_minuts.ToList().ConvertAll<string>(a => a.ToString()))).TransformationForEach(a => (a.Length == 1) ? "0" + a : a);
        }

        public int SelectedHours
        {
            get => _selectedHours;
            set
            {
                _selectedHours = value;
                OnPropertyChanged();
            }
        }
        public int SelectedMinuts
        {
            get => _selectedMinuts;
            set
            {
                _selectedMinuts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> _hours;
        private ObservableCollection<int> _minuts;

        private int _selectedHours;
        private int _selectedMinuts;

        public DateTimePickerViewModel()
        {
            _firstInitializeHoursCollection();
            _firstInitializeMinutsCollection();
            SelectedHours = 0;
            SelectedMinuts = 0;
            SelectedDateTime = DateTime.Now;
        }

        /// <summary>
        /// Метод первичной инициализации списка часов
        /// </summary>
        private void _firstInitializeHoursCollection()
        {
            _hours = new ObservableCollection<int>();
            for(int i = 0; i < 24; i++)
            {
                _hours.Add(i);
            }
            OnPropertyChanged("HoursList");
        }

        /// <summary>
        /// Метод первичной инициализации списка минут
        /// </summary>
        private void _firstInitializeMinutsCollection()
        {
            _minuts = new ObservableCollection<int>();
            for (int i = 0; i < 60; i++)
            {
                _minuts.Add(i);
            }
            OnPropertyChanged("MinutsList");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public static class ObservableCollectionExtension
    {
        public static ObservableCollection<T> TransformationForEach<T>(this ObservableCollection<T> Collection, Func<T,T> Action)
        {
            for(int i = 0; i < Collection.Count; i++)
            {
                Collection[i] = Action(Collection[i]);
            }
            return Collection;
        }
    }
}
