using System;
using System.Collections.Generic;
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

        public AddNewItemUCModel()
        {
            _dB = new DataBase();
        }
    }
}
