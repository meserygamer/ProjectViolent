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
    public enum AddNewItemUCStatus
    {
        Create,
        Update
    }

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
            get => _addNewItemCommand;
            set
            {
                _addNewItemCommand = value;
                OnPropertyChanged();
            }
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

        public AddNewItemUCModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BettingHistory> BetHistory
        {
            get => _betHistory;
            set
            {
                _betHistory = value;
                OnPropertyChanged();
            }
        }

        public AddNewItemUCStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region public конструкторы
        public AddNewItemUCViewModel()
        {
            Model = new AddNewItemUCModel();
            Status = AddNewItemUCStatus.Create;
            AvailableItems = new ObservableCollection<Items>(_model.AllItems);
            DateStart = DateTime.Now;
            DateEnd = DateTime.Now;
            setCreateItemCommand();
            //BetHistory = new ObservableCollection<BettingHistory>() {new BettingHistory(){
            //    UserID = 4,
            //    BidAmount = 10000,
            //    ID_Auction = 10
            //} };
        }

        public AddNewItemUCViewModel(Auction selectionAuction)
        {
            Model = new AddNewItemUCModel();
            Status = AddNewItemUCStatus.Update;
            AvailableItems = new ObservableCollection<Items>(_model.AllItems);
            StartPrice = (decimal)selectionAuction.StartPrice;
            ChoseItem = AvailableItems.Where(x => x.ID_Item == selectionAuction.ID_Item).FirstOrDefault();
            //ChoseItem = selectionAuction.Items;
            DateStart = selectionAuction.Date_Start;
            DateEnd = selectionAuction.Date_End;
            BetHistory = new ObservableCollection<BettingHistory>();
            foreach(BettingHistory item in selectionAuction.BettingHistory)
            {
                BetHistory.Add(new BettingHistory()
                {
                    ID_Auction = item.ID_Auction,
                    UserData = Model.AllUsers.Where(a=>a.UserID == item.UserID).First(),
                    BidAmount = item.BidAmount,
                    UserID = item.UserID,
                });
            }
            _updatedAuction = selectionAuction;
            setUpdateItemCommand();
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

        private ObservableCollection<BettingHistory> _betHistory;

        private AddNewItemUCStatus _status;

        private Auction _updatedAuction;
        #endregion

        #region private функции
        private void UpdateImage() => ItemImage = new WPFImage(ChoseItem.Image);

        private void setCreateItemCommand()
        {
            AddNewItemCommand = new RelayCommand(a =>
            {
                if (ChoseItem == null)
                {
                    MessageBox.Show("Выставляемый на аукцион предмет не выбран!");
                    return;
                }
                if (_model.AddNewAuctionInDataBase(new Auction
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
            });
        }

        private void setUpdateItemCommand()
        {
            AddNewItemCommand = new RelayCommand(a =>
            {
                if (ChoseItem == null)
                {
                    MessageBox.Show("Выставляемый на аукцион предмет не выбран!");
                    return;
                }
                if (_model.UpdateAuctionInDataBase(new Auction
                {
                    ID_Auction = _updatedAuction.ID_Auction,
                    ID_Item = ChoseItem.ID_Item,
                    Date_Start = DateStart,
                    Date_End = DateEnd,
                    StartPrice = StartPrice,
                    BettingHistory = BetHistory
                }))
                {
                    MessageBox.Show("Аукцион успешно обновлен");
                }
                else
                {
                    MessageBox.Show("При обновлении аукциона произошла ошибка");
                }
            });
        }
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
