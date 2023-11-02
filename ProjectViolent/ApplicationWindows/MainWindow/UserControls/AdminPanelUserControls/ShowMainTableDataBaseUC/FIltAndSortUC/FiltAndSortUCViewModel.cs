using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC.FIltAndSortUC
{
    public enum SortingStates
    {
        ASC,
        DESC
    }
    
    public class FiltAndSortUCViewModel : DependencyObject, INotifyPropertyChanged
    {
        public ObservableCollection<Auction> InputObserverCollectionProperty
        {
            get => (ObservableCollection<Auction>)GetValue(InputObserverCollectionDependencyProperty);
            set => SetValue(InputObserverCollectionDependencyProperty, value);
        }

        public ObservableCollection<Auction> OutputObserverCollectionProperty
        {
            get { return (ObservableCollection<Auction>)GetValue(OutputObserverCollectionDependencyProperty); }
            set { SetValue(OutputObserverCollectionDependencyProperty, value); }
        }

        #region фильтрация свойства

        public AuctionCustomFilter SelectedItemFromComboBox
        {
            get => _selectedItemFromComboBox;
            set
            {
                _selectedItemFromComboBox = value;
                OnPropertyChanged();
                Model.DelFilter(value);
                Model.AddFilter(value);
                Model.ApplyFilters();
            }
        }

        public ObservableCollection<AuctionCustomFilter> ComboBoxFilterList
        {
            get => _comboBoxFilterList ?? (_comboBoxFilterList = new ObservableCollection<AuctionCustomFilter>
            {
                new AuctionCustomFilter(a => {return true;}, 1, "Все аукционы"),
                new AuctionCustomFilter(a => {return a.BettingHistory.Count == 0;}, 1, "Аукционы без ставок"),
                new AuctionCustomFilter(a => {return a.BettingHistory.Count != 0;}, 1, "Аукционы со ставками")
            });
        }

        public string SearchBarQuary
        {
            get => _searchBarQuary;
            set
            {
                _searchBarQuary = value;
                OnPropertyChanged();
            }
        }

        public bool ShowCompletedAuctions
        {
            get => _showCompletedAuctions;
            set
            {
                _showCompletedAuctions = value;
                OnPropertyChanged();
            }
        }

        public bool ShowStartedAuctions
        {
            get => _showStartedAuctions;
            set
            {
                _showStartedAuctions = value;
                OnPropertyChanged();
            }
        }

        public bool ShowNotStartedAuctions
        {
            get => _showNotStartedAuctions;
            set
            {
                _showNotStartedAuctions = value;
                OnPropertyChanged();
            }
        }

        public int ComboBoxSelectedIndex
        {
            get => _comboBoxSelectedIndex;
            set
            {
                _comboBoxSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region сортировка свойства
        public SortingStates SortingState
        {
            get => _sortingState;
            set
            {
                _sortingState = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTargetSortingType
        {
            get => _selectedTargetSortingType;
            set
            {
                _selectedTargetSortingType = value;
                OnPropertyChanged();
            }
        }

        public bool ModeASCIsChecked
        {
            get => _modeASCIsChecked;
            set
            {
                _modeASCIsChecked = value;
                OnPropertyChanged();
                if (ModeASCIsChecked) SortingState = SortingStates.ASC;
            }
        }

        public bool ModeDESCIsChecked
        {
            get => _modeDESCIsChecked;
            set
            {
                _modeDESCIsChecked = value;
                OnPropertyChanged();
                if (ModeDESCIsChecked) SortingState = SortingStates.DESC;
            }
        }
        #endregion


        public FiltAndSortUCModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }


        public static DependencyProperty InputObserverCollectionDependencyProperty =
            DependencyProperty.Register("InputObserverCollectionProperty", typeof(ObservableCollection<Auction>), typeof(FiltAndSortUCViewModel));

        public static readonly DependencyProperty OutputObserverCollectionDependencyProperty =
            DependencyProperty.Register("OutputObserverCollectionProperty", typeof(ObservableCollection<Auction>), typeof(FiltAndSortUCViewModel));


        public FiltAndSortUCViewModel()
        {
            Model = new FiltAndSortUCModel();
            Model.PropertyChanged += OutPutCollectionListner;
            SetDependencyPropertyListners();
            ShowCompletedAuctions = true;
            ShowNotStartedAuctions = true;
            ShowStartedAuctions = true;
            ModeASCIsChecked = true;
            ComboBoxSelectedIndex = 0;
        }

        private void OutPutCollectionListner(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "OutputAuctions")
            {
                OutputObserverCollectionProperty = Model.OutputAuctions;
            }
        }

        private void SetDependencyPropertyListners()
        {
            DependencyPropertyDescriptor descriptorInputCollection = DependencyPropertyDescriptor.FromProperty(InputObserverCollectionDependencyProperty
                , typeof(FiltAndSortUCViewModel));
            descriptorInputCollection.AddValueChanged(this, ChangedInputCollection);
        }

        private void ChangedInputCollection(object sender, EventArgs e)
        {
            Model.InputAuctions = InputObserverCollectionProperty;
        }


        #region сортировка поля
        private SortingStates _sortingState;

        private string _selectedTargetSortingType;

        private bool _modeASCIsChecked;

        private bool _modeDESCIsChecked;
        #endregion

        #region фильтрация поля
        private AuctionCustomFilter _selectedItemFromComboBox;

        private ObservableCollection<AuctionCustomFilter> _comboBoxFilterList;

        private string _searchBarQuary;

        private bool _showCompletedAuctions;

        private bool _showStartedAuctions;

        private bool _showNotStartedAuctions;

        private int _comboBoxSelectedIndex;

        #endregion

        private FiltAndSortUCModel _model;


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
