using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowAllItemsDataBaseUC
{
    public class ShowAllItemsDataBaseUCModel
    {
        public ObservableCollection<Items> ItemsList
        {
            get => _itemsList;
            set
            {
                _itemsList = value;
            }
        }


        public ShowAllItemsDataBaseUCModel()
        {
            DB = new DataBase();
            _itemsList = new ObservableCollection<Items>(DB.Items);
        }


        private DataBase DB;

        private ObservableCollection<Items> _itemsList; 
    }
}
