using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC.ImageSelectorUC;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC
{
    public class AddNewItemUCViewModel : INotifyPropertyChanged
    {
        #region свойства
        public decimal StartPrice
        {
            get => _startPrice;
            set
            {
                _startPrice = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Items> AvailableItems
        {
            get => _availableItems;
            set
            {
                _availableItems = value;
                OnPropertyChanged();
            }
        }

        public Items ChoseItem
        {
            get => _choseItem;
            set
            {
                _choseItem = value;
                OnPropertyChanged();
                UpdateImage();
            }
        }

        public WPFImage ItemImage
        {
            get => _itemImage;
            set
            {
                _itemImage = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddNewItemCommand
        {
            get => _addNewItemCommand ?? (_addNewItemCommand = new RelayCommand(a =>
            {
                if(ChoseItem == null)
                {
                    MessageBox.Show("Выставляемый на аукцион предмет не выбран!");
                    return;
                }
                if(_model.AddNewAuctionInDataBase(new Auction
                {
                    ID_Item = ChoseItem.ID_Item,
                    Date_Start = DateStart,
                    Date_End = DateEnd,
                    StartPrice = StartPrice
                }))
                {
                    MessageBox.Show("Аукцион успешно добавлен");
                }
                else
                {
                    MessageBox.Show("При добавлении аукциона произошла ошибка");
                }
            }));
        }

        public DateTime DateStart
        {
            get => _dateStart;
            set
            {
                _dateStart = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region public конструкторы
        public AddNewItemUCViewModel()
        {
            _model = new AddNewItemUCModel();
            AvailableItems = new ObservableCollection<Items>(_model.AllItems);
            DateStart = DateTime.Now;
            DateEnd = DateTime.Now;
        }
        #endregion

        #region private поля
        private decimal _startPrice;

        private ObservableCollection<Items> _availableItems;

        private Items _choseItem;

        private WPFImage _itemImage;

        private RelayCommand _addNewItemCommand;

        private DateTime _dateStart;

        private DateTime _dateEnd;

        private AddNewItemUCModel _model;
        #endregion

        #region private функции
        private void UpdateImage() => ItemImage = new WPFImage(ChoseItem.Image);
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }

    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is decimal decimalValue)
            {
                return decimalValue.ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(targetType == typeof(decimal))
            {
                try
                {
                    return System.Convert.ToDecimal(value);
                }
                catch 
                {
                    return (decimal)0;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
