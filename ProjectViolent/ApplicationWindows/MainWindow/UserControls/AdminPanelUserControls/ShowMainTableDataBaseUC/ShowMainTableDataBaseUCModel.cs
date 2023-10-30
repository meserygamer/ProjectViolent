using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC
{
    public class ShowMainTableDataBaseUCModel : INotifyPropertyChanged
    {
        private ObservableCollection<Auction> _auctionList;

        private DataBase DB;


        public bool DeleteAuct(Auction deletedAuction)
        {

            try
            {
                DB.Auction.Remove(DB.Auction.Find(deletedAuction.ID_Auction));
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }


        public ObservableCollection<Auction> AuctionsList
        {
            get => _auctionList;
            set
            {
                _auctionList = value;
                OnPropertyChanged();
            }
        }

        public bool UpdateAuctionList()
        {
            try
            {
                AuctionsList = new ObservableCollection<Auction>(DB.Auction.ToList());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public ShowMainTableDataBaseUCModel()
        {
            DB = new DataBase();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
