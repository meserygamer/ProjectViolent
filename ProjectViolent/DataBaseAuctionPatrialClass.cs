using System;
using System.Collections.Generic;
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
    }
}
