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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC
{
    public class ShowMainTableDataBaseUCViewModel : INotifyPropertyChanged
    {
        public event Action<Auction> SelectionAuctionWasUpdateNotify;

        public ShowMainTableDataBaseUCModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public Auction SelectedAuction
        {
            get => _selectedAuction;
            set
            {
                _selectedAuction = value;
                OnPropertyChanged(nameof(SelectedAuction));
                selectionAuctionWasUpdate();
            }
        }

        public RelayCommand DelElemCommand
        {
            get => _delElemCommand ?? (_delElemCommand = new RelayCommand(a =>
            {
                if (a is Auction deletedItem)
                {
                    if (MessageBox.Show("Вы точно хотите удалить данный аукцион?", "Предупреждение", MessageBoxButton.OKCancel,
                        MessageBoxImage.Warning) == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                    if (Model.DeleteAuct(deletedItem))
                    {
                        Model.UpdateAuctionList();
                        MessageBox.Show("Аукцион успешно удален!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении аукциона");
                    }
                }
            }));
        }


        public ShowMainTableDataBaseUCViewModel()
        {
            Model = new ShowMainTableDataBaseUCModel();
            Model.UpdateAuctionList();
        }


        private void selectionAuctionWasUpdate()
        {
            if(SelectedAuction != null)
            {
                SelectedAuction.Items = SelectedAuction.Items;
                SelectedAuction.BettingHistory = SelectedAuction.BettingHistory;
                SelectionAuctionWasUpdateNotify(SelectedAuction);
            }
        }


        private ShowMainTableDataBaseUCModel _model;

        private Auction _selectedAuction;

        private RelayCommand _delElemCommand;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class IdentifyUserThatDoBid : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)("(ID=" + ((UserData)value).UserID + ") " + ((UserData)value).Surname + " " + ((UserData)value).Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
            {
                return dt.ToString("g", CultureInfo.GetCultureInfo("ru-RU"));
            }
            else return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
