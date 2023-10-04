using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public System.Windows.Media.Color ColorOfAuctionStatus
        {
            get
            {
                if (DateTime.Now < Date_Start)
                {
                    return System.Windows.Media.Colors.LightGray;
                }
                else if (DateTime.Now >= Date_Start && DateTime.Now < Date_End)
                {
                    return System.Windows.Media.Color.FromArgb(255, 89, 250, 96);
                }
                else if (DateTime.Now >= Date_End)
                {
                    return System.Windows.Media.Color.FromArgb(255, 250, 93, 87);
                }
                else
                {
                    return System.Windows.Media.Color.FromArgb(0, 0, 0, 0);
                }
            }
        }
    }
}
