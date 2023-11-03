using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC.FIltAndSortUC
{
    public class AuctionSearchFilter : IFilter<Auction>, INotifyPropertyChanged
    {
        public Predicate<Auction> Filter 
        {
            get => _filter ?? (_filter = new Predicate<Auction>(a =>
            {
                return Regex.IsMatch((a.ID_Auction).ToString(), $@".*{SearchQuarry}.*");
            }));
        }

        public string SearchQuarry
        {
            get => _searchQuarry;
            set
            {
                _searchQuarry = value;
                OnPropertyChanged();
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
            return Filter(checkedItem);
        }

        public bool Equals(IFilter<Auction> other)
        {
            return ID == other.ID;
        }


        public AuctionSearchFilter(int id)
        {
            SearchQuarry = "";
        }


        private Predicate<Auction> _filter;

        private int _iD;

        private string _searchQuarry;


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }

    public class AuctionCustomFilter : IFilter<Auction>
    {
        public Predicate<Auction> Filter
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
            return Filter(checkedItem);
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

    public class AuctionCustomCheckBoxFilter : IFilter<Auction>, INotifyPropertyChanged
    {
        public int ID{ get => _id; private set => _id = value;}

        public Predicate<Auction> Filter{get => _filter; private set => _filter = value;}

        public bool IsChecked
        {
            get => _checkBoxState;
            set
            {
                if(value)
                {
                    Filter = _enableFilter;
                }
                else
                {
                    Filter = _disableFilter;
                }
                _checkBoxState = value;
                OnPropertyChanged();
            }
        }


        public bool CheckAuction(Auction checkedItem)
        {
            if (checkedItem == null) return false;
            return Filter(checkedItem);
        }

        public bool Equals(IFilter<Auction> other)
        {
            if(other is null)
            {
                return false;
            }
            return ID == other.ID;
        }

        public override string ToString()
        {
            return _filterName;
        }


        public AuctionCustomCheckBoxFilter(int id, string filterName
            , Predicate<Auction> EnableFilterPredicate, Predicate<Auction> DisableFilterPredicate)
        {
            _id = id;
            _filterName = filterName;
            _enableFilter = EnableFilterPredicate;
            _disableFilter = DisableFilterPredicate;
            IsChecked = true;
        }


        private int _id;

        private string _filterName;

        private bool _checkBoxState;

        private Predicate<Auction> _filter;

        private Predicate<Auction> _enableFilter;

        private Predicate<Auction> _disableFilter;


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }

    public class AuctionCustomCheckBoxUnitedFilter : IFilter<Auction>
    {
        public int ID { get => _id; set => _id = value; }

        public Predicate<Auction> Filter 
        {
            get => _filter ?? (_filter = new Predicate<Auction>(a =>
            {
                foreach(AuctionCustomCheckBoxFilter filter in _implementedFilters)
                {
                    if(filter.CheckAuction(a))
                    {
                        return true;
                    }
                }
                return false;
            }));
        }

        public bool CheckAuction(Auction checkedItem)
        {
            if(checkedItem is null) return false;
            return Filter(checkedItem);
        }

        public void addFilter(AuctionCustomCheckBoxFilter attachingFilter)
        {
            _implementedFilters.Add(attachingFilter);
        }

        public void removeFilter(AuctionCustomCheckBoxFilter removingFilter)
        {
            _implementedFilters.Remove(removingFilter);
        }

        public void clearFilters()
        {
            _implementedFilters.Clear();
        }

        public bool Equals(IFilter<Auction> other)
        {
            return ID == other.ID;
        }


        public AuctionCustomCheckBoxUnitedFilter(int id)
        {
            ID = id;
            _implementedFilters = new List<AuctionCustomCheckBoxFilter>();
        }

        public AuctionCustomCheckBoxUnitedFilter(int id, List<AuctionCustomCheckBoxFilter> implementingFilters)
        {
            ID = id;
            _implementedFilters = implementingFilters;
        }


        private int _id;

        private Predicate<Auction> _filter;

        private List<AuctionCustomCheckBoxFilter> _implementedFilters;
    }

    public interface IFilter<T> : IEquatable<IFilter<T>>
    {
        int ID { get; }

        Predicate<T> Filter {get; }


        bool CheckAuction(T checkedItem);
    }
}
