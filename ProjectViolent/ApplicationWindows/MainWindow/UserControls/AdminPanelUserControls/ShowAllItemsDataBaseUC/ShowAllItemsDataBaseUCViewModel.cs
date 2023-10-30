using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC;
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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowAllItemsDataBaseUC
{
    public class ShowAllItemsDataBaseUCViewModel : DependencyObject, INotifyPropertyChanged
    {
        public event Action<Items> ItemsChanged;

        public ShowAllItemsDataBaseUCModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public Items SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                UpdateSelectedItem();
            }
        }

        public RelayCommand DelElemCommand
        {
            get => _delElemCommand ?? (_delElemCommand = new RelayCommand(a =>
            {
                if(a is Items deletedItem)
                {
                    if(MessageBox.Show("Вы точно хотите удалить данный предмет?", "Предупреждение", MessageBoxButton.OKCancel,
                        MessageBoxImage.Warning) == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                    if(Model.DeleteItem(deletedItem))
                    {
                        Model.UpdateItemsList();
                        MessageBox.Show("Предмет успешно удален!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении предмета");
                    }
                }
            }));
        }


        public ShowAllItemsDataBaseUCViewModel()
        {
            _model = new ShowAllItemsDataBaseUCModel();
        }


        private void UpdateSelectedItem()
        {
            if(SelectedItem != null)
            {
                ItemsChanged(SelectedItem);
            }
        }


        private ShowAllItemsDataBaseUCModel _model;

        private Items _selectedItem;

        private RelayCommand _delElemCommand;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ItemCreatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string) return value;
            else if(value is UserData creator)
            {
                return creator.Surname +" "+ creator.Name +" "+ creator.Surname + " (" + creator.UserID + ")";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
