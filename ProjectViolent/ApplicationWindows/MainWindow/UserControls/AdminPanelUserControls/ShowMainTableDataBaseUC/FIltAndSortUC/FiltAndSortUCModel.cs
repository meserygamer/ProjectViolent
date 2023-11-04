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
    public class FiltAndSortUCModel
    {
        public ObservableCollection<Auction> InputAuctions
        {
            get => _inputAuctions;
            set
            {
                _inputAuctions = value;
                ApplyFilters();
            }
        }

        public ObservableCollection<Auction> OutputAuctions
        {
            get => _outputAuctions;
            set
            {
                _outputAuctions = value;
                ApplyFilters();
            }
        }

        public List<IFilter<Auction>> ActivityFilters
        {
            get => _activityFilters;
        }

        public IComparer<Auction> CurrentSortComparer
        {
            get => _currentSortComparer;
            set
            {
                _currentSortComparer = value;
                ApplyFilters();
            }
        }


        public void ApplyFilters()
        {
            if(InputAuctions is null || OutputAuctions is null)
            {
                return;
            }
            OutputAuctions.Clear();
            List<Auction> auctions = new List<Auction>();
            for(int i = 0; i < InputAuctions.Count; i++)
            {
                if(_activityFilters.All(a =>
                {
                    if (a is null) return true;
                    return a.CheckAuction(InputAuctions[i]);
                }))
                {
                    auctions.Add(InputAuctions[i]);
                }
            }
            if (!(CurrentSortComparer is null))
            {
                auctions.Sort(CurrentSortComparer);
            }
            foreach (var auction in auctions)
            {
                OutputAuctions.Add(auction);
            }

        }


        public FiltAndSortUCModel(List<IFilter<Auction>> activityFiltersList)
        {
            _activityFilters = activityFiltersList;
        }


        private ObservableCollection<Auction> _inputAuctions;

        private ObservableCollection<Auction> _outputAuctions;

        private List<IFilter<Auction>> _activityFilters;

        private IComparer<Auction> _currentSortComparer;
    }
}
