//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectViolent
{
    using System;
    using System.Collections.Generic;
    
    public partial class BettingHistory
    {
        public int ID_Bid { get; set; }
        public int UserID { get; set; }
        public int ID_Auction { get; set; }
        public decimal BidAmount { get; set; }
    
        public virtual Auction Auction { get; set; }
        public virtual UserData UserData { get; set; }
    }
}