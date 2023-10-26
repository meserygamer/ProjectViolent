using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC
{
    public class AddNewItemUCViewModel : INotifyPropertyChanged
    {
        private decimal _startPrice;
        private ObservableCollection<Items> _availableItems;
        private Items _choseItem;
        private BitmapImage _itemImage;
        private RelayCommand _addNewItemCommand;

        private AddNewItemUCModel _model;

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
                OnPropertyChanged(nameof(ItemImage));
            }
        }

        public BitmapImage ItemImage
        {
            get
            {
                if(_choseItem == null)
                    return null;
                if (_choseItem.Image != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new System.IO.MemoryStream(_choseItem.Image, 0, _choseItem.Image.Length);
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
                else return null;
            }
        }

        public RelayCommand AddNewItemCommand
        {
            get => _addNewItemCommand ?? (_addNewItemCommand = new RelayCommand(a =>
            {
                _model.AddNewAuctionInDataBase(new Auction() 
                {
                    //ID_Item = _choseItem.ID_Item,
                    //Date_Start = _sinceDateTimePickerVM.SelectedDate,
                    //Date_End = _untilDateTimePickerVM.SelectedDate,
                    //StartPrice = _startPrice,
                });
            }));
        }

        public AddNewItemUCViewModel()
        {
            _model = new AddNewItemUCModel();
            AvailableItems = new ObservableCollection<Items>(_model.AllItems);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
