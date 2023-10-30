using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowAllItemsDataBaseUC
{
    public class ShowAllItemsDataBaseUCModel : INotifyPropertyChanged
    {
        public ObservableCollection<Items> ItemsList
        {
            get => _itemsList;
            set
            {
                _itemsList = value;
                OnPropertyChanged();
            }
        }


        public bool DeleteItem(Items deletedItem)
        {
            try
            {
                DB.Items.Remove(DB.Items.Find(deletedItem.ID_Item));
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateItemsList()
        {
            ItemsList = new ObservableCollection<Items>(DB.Items);
        }


        public ShowAllItemsDataBaseUCModel()
        {
            DB = new DataBase();
            UpdateItemsList();
        }


        private DataBase DB;

        private ObservableCollection<Items> _itemsList;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
