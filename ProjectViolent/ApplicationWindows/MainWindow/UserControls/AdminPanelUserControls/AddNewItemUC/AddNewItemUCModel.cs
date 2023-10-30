using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC
{
    public class AddNewItemUCModel
    {
        private DataBase _dB;

        public List<Items> AvailableItems
        {
            get
            {
                return AllItems.Where((a) => a.Auction.All(b => b.Date_End < DateTime.Now)).ToList();
            }
        }

        public List<Items> AllItems
        {
            get
            {
                try
                {
                    return _dB.Items.ToList();
                }
                catch
                {
                    return new List<Items>();
                }
            }
        }

        public ObservableCollection<UserData> AllUsers
        {
            get => new ObservableCollection<UserData>(_dB.UserData.ToList());
        }

        public bool AddNewAuctionInDataBase(Auction auction)
        {
            try
            {
                _dB.Auction.Add(auction);
                _dB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAuctionInDataBase(Auction auction)
        {
            try
            {
                _dB.BettingHistory.RemoveRange(_dB.BettingHistory.Where(a => a.ID_Auction == auction.ID_Auction));
                Auction updatedAuction = _dB.Auction.Find(auction.ID_Auction);
                updatedAuction.ID_Item = auction.ID_Item;
                updatedAuction.Date_Start = auction.Date_Start;
                updatedAuction.Date_End = auction.Date_End;
                updatedAuction.StartPrice = auction.StartPrice;
                updatedAuction.BettingHistory = auction.BettingHistory;
                _dB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AddNewItemUCModel()
        {
            _dB = new DataBase();
        }
    }
}
