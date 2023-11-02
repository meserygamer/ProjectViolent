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
        public ObservableCollection<Auction> AuctionsList
        {
            get => _auctionList;
            set
            {
                _auctionList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Auction> FilteredAuctionList
        {
            get => _filteredAuctionList;
            set
            {
                _filteredAuctionList = value;
                OnPropertyChanged();
            }
        }


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


        private ObservableCollection<Auction> _auctionList;

        private ObservableCollection<Auction> _filteredAuctionList;

        private DataBase DB;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
