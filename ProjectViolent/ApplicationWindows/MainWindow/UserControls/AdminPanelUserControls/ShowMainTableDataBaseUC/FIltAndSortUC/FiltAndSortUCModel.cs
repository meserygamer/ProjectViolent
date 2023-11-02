using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC.FIltAndSortUC
{
    public class FiltAndSortUCModel : INotifyPropertyChanged
    {
        public ObservableCollection<Auction> InputAuctions
        {
            get => _inputAuctions;
            set
            {
                _inputAuctions = value;
                OnPropertyChanged();
                OutputAuctions = _inputAuctions;
            }
        }

        public ObservableCollection<Auction> OutputAuctions
        {
            get => _outputAuctions;
            set
            {
                _outputAuctions = value;
                OnPropertyChanged();
            }
        }


        public void ApplyFilters()
        {
            foreach(IFilter<Auction> filter in _activityFilters)
            {
                _outputAuctions = new ObservableCollection<Auction>(InputAuctions);

                for(int i = 0; i < InputAuctions.Count; i++)
                {
                    if (!filter.CheckAuction(InputAuctions[i]))
                    {
                        _outputAuctions.Remove(InputAuctions[i]);
                    }
                }

                OnPropertyChanged("OutputAuctions");
            }
        }

        public void AddFilter(IFilter<Auction> filter)
        {
            if (filter is null) return;
            _activityFilters.Add(filter);
        }

        public void DelFilter(IFilter<Auction> filter)
        {
            if (filter is null) return;
            _activityFilters.Remove(filter);
        }


        public FiltAndSortUCModel()
        {
            InputAuctions = new ObservableCollection<Auction>();
            _activityFilters = new List<IFilter<Auction>>();
        }


        private ObservableCollection<Auction> _inputAuctions;

        private ObservableCollection<Auction> _outputAuctions;

        private List<IFilter<Auction>> _activityFilters;


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }

}
