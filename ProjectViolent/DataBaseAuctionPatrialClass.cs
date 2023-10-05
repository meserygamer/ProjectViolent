using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectViolent
{
    public partial class Auction 
    {
        public string AuctionStatus
        {
            get
            {
                if(DateTime.Now < Date_Start)
                {
                    return "Не начался";
                }
                else if(DateTime.Now >= Date_Start && DateTime.Now < Date_End)
                {
                    return "В процессе";
                }
                else if(DateTime.Now >= Date_End)
                {
                    return "Закончился";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public SolidColorBrush ColorOfAuctionStatus
        {
            get
            {
                if (DateTime.Now < Date_Start)
                {
                    return new SolidColorBrush(System.Windows.Media.Colors.LightGray);
                }
                else if (DateTime.Now >= Date_Start && DateTime.Now < Date_End)
                {
                    return new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 89, 250, 96));
                }
                else if (DateTime.Now >= Date_End)
                {
                    return new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 250, 93, 87));
                }
                else
                {
                    return new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
                }
            }
        }

        public decimal SumOfBiddings
        {
            get
            {
                decimal result = 0;
                foreach (BettingHistory bet in BettingHistory)
                {
                    result += bet.BidAmount;
                }
                return result;
            }
        }
    }
}
