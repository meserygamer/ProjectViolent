using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC.ImageSelectorUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC
{
    public class AddNewAuctionItemUCViewModel : INotifyPropertyChanged
    {
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                OnPropertyChanged();
            }
        }

        public string ItemDescription
        {
            get => _itemDescription;
            set
            {
                _itemDescription = value;
                OnPropertyChanged();
            }
        }

        public WPFImage Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddNewItemCommand
        {
            get => _addNewItemCommand ?? (_addNewItemCommand = new RelayCommand(a =>
            {
                if (ItemName == null || ItemName.Length == 0)
                {
                    MessageBox.Show("Минимальные требования для добавления предмета:\n*Имя предмета должно быть заполнено");
                    return;
                }
                if (AddNewAuctionItemUCModel.AddNewItemAuctionItem(
                    (int)Application.Current.Resources["UserID"],
                    ItemName, ItemDescription, Image.ImageBytes) == 0)
                {
                    MessageBox.Show("Предмет успешно добавлен");
                }
                else
                {
                    MessageBox.Show("При добавлении предмета произошла ошибка");
                }
            }));
        }


        public AddNewAuctionItemUCViewModel()
        {
            Image = new WPFImage();
        }


        private string _itemName;

        private string _itemDescription;

        private WPFImage _image;

        private RelayCommand _addNewItemCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
