using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC.FIltAndSortUC
{
    public class AuctionSearchFilter : IFilter<Auction>
    {
        public Predicate<Auction> filter 
        {
            get => _filter ?? (_filter = new Predicate<Auction>(a =>
            {
                return Regex.IsMatch((a.ID_Auction).ToString(), $@".*{SearchQuarry}.*");
            }));
        }

        public string SearchQuarry { get; set; }

        public int ID
        {
            get => _iD;
            private set
            {
                _iD = value;
            }
        }


        public bool CheckAuction(Auction checkedItem)
        {
            if (checkedItem == null) return false;
            return filter(checkedItem);
        }

        public bool Equals(IFilter<Auction> other)
        {
            throw new NotImplementedException();
        }


        private Predicate<Auction> _filter;

        private int _iD;
    }

    public class AuctionCustomFilter : IFilter<Auction>
    {
        public Predicate<Auction> filter
        {
            get => _filter;
            private set
            {
                _filter = value;
            }
        }

        public int ID
        {
            get => _iD;
            private set
            {
                _iD = value;
            }
        }


        public bool CheckAuction(Auction checkedItem)
        {
            if (checkedItem == null) return false;
            return filter(checkedItem);
        }

        public bool Equals(IFilter<Auction> other)
        {
            return ID == other.ID;
        }

        public override string ToString()
        {
            return _filterName;
        }


        public AuctionCustomFilter(Predicate<Auction> filter, int id, string filterName)
        {
            _filter = filter;
            _iD = id;
            _filterName = filterName;
        }


        private Predicate<Auction> _filter;

        private int _iD;

        private string _filterName;
    }

    public interface IFilter<T> : IEquatable<IFilter<T>>
    {
        int ID { get; }

        Predicate<T> filter {get; }


        bool CheckAuction(T checkedItem);
    }
}
