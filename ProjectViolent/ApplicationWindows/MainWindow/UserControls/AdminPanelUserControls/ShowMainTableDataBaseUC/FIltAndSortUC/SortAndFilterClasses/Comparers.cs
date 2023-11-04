using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC.FIltAndSortUC
{
    public class AuctionItemNameComparer : IComparer<Auction>
    {
        public bool IsDESCComparer {get; set;}

        public int Compare(Auction x, Auction y)
        {
            if (!IsDESCComparer) return string.Compare(x.Items.ItemName, y.Items.ItemName, true);
            return -(string.Compare(x.Items.ItemName, y.Items.ItemName, true));
        }

        public AuctionItemNameComparer(bool isDESCComparer)
        {
            IsDESCComparer = isDESCComparer;
        }
    }

    public class AuctionIDComparer : IComparer<Auction>
    {
        public bool IsDESCComparer { get; set; }

        public int Compare(Auction x, Auction y)
        {
            if (!IsDESCComparer)
            {
                return (x.ID_Auction == y.ID_Auction) ? 0 : (x.ID_Auction > y.ID_Auction) ? 1 : -1;
            }
            return -((x.ID_Auction == y.ID_Auction) ? 0 : (x.ID_Auction > y.ID_Auction) ? 1 : -1);
        }

        public AuctionIDComparer(bool isDESCComparer)
        {
            IsDESCComparer = isDESCComparer;
        }
    }
}
