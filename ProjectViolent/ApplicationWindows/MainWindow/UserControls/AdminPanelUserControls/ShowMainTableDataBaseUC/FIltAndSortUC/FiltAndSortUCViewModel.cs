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
                Model.ActivityFilters[0] = SelectedItemFromComboBox;
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

        public AuctionSearchFilter SearchBarQuary
        {
            get => _searchBarQuary;
            set
            {
                _searchBarQuary = value;
                OnPropertyChanged();
            }
        }

        public AuctionCustomCheckBoxFilter CheckBoxFilterCompletedAuctions
        {
            get => _checkBoxFilterCompletedAuctions;
            set
            {
                _checkBoxFilterCompletedAuctions = value;
                OnPropertyChanged();
            }
        }

        public AuctionCustomCheckBoxFilter CheckBoxFilterBeOnAuctions
        {
            get => _checkBoxFilterBeOnAuctions;
            set
            {
                _checkBoxFilterBeOnAuctions = value;
                OnPropertyChanged();
            }
        }

        public AuctionCustomCheckBoxFilter CheckBoxFilterFuturedAuctions
        {
            get => _checkBoxFilterFuturedAuctions;
            set
            {
                _checkBoxFilterFuturedAuctions = value;
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
            FiltersInitializator();
            SetDependencyPropertyListners();
            Model = new FiltAndSortUCModel(new List<IFilter<Auction>>()
            {
                SelectedItemFromComboBox,
                new AuctionCustomCheckBoxUnitedFilter(5,new List<AuctionCustomCheckBoxFilter>()
                { CheckBoxFilterCompletedAuctions,
                    CheckBoxFilterBeOnAuctions,
                    CheckBoxFilterFuturedAuctions}), 
                SearchBarQuary});
            SelectedItemFromComboBox = ComboBoxFilterList[0];
            ModeASCIsChecked = true;
        }


        private void SetDependencyPropertyListners()
        {
            DependencyPropertyDescriptor descriptorInputCollection = DependencyPropertyDescriptor.FromProperty(InputObserverCollectionDependencyProperty
                , typeof(FiltAndSortUCViewModel));
            DependencyPropertyDescriptor descriptorOutputCollection = DependencyPropertyDescriptor.FromProperty(OutputObserverCollectionDependencyProperty
                , typeof(FiltAndSortUCViewModel));
            descriptorInputCollection.AddValueChanged(this, ChangedInputCollection);
            descriptorOutputCollection.AddValueChanged(this, ChangedOutputCollection);
        }

        private void ChangedInputCollection(object sender, EventArgs e)
        {
            Model.InputAuctions = InputObserverCollectionProperty;
        }

        private void ChangedOutputCollection(object sender, EventArgs e)
        {
            Model.OutputAuctions = OutputObserverCollectionProperty;
        }

        private void FiltersInitializator()
        {
            CheckBoxFilterCompletedAuctions = new AuctionCustomCheckBoxFilter(2, "Завершенные аукционы", a => a.AuctionStatus == "Закончился", a => false);
            CheckBoxFilterCompletedAuctions.PropertyChanged += RefilteringCheckBoxWasEdited;
            CheckBoxFilterBeOnAuctions = new AuctionCustomCheckBoxFilter(3, "Идущие аукционы", a => a.AuctionStatus == "В процессе", a => false);
            CheckBoxFilterBeOnAuctions.PropertyChanged += RefilteringCheckBoxWasEdited;
            CheckBoxFilterFuturedAuctions = new AuctionCustomCheckBoxFilter(4, "Будущие аукционы", a => a.AuctionStatus == "Не начался", a => false);
            CheckBoxFilterFuturedAuctions.PropertyChanged += RefilteringCheckBoxWasEdited;
            SearchBarQuary = new AuctionSearchFilter(6);
            SearchBarQuary.PropertyChanged += RefilteringSearchBoxWasEdited;

        }

        private void RefilteringCheckBoxWasEdited(object sender, PropertyChangedEventArgs handler)
        {
            if(handler.PropertyName == "IsChecked") Model.ApplyFilters();
        }

        private void RefilteringSearchBoxWasEdited(object sender, PropertyChangedEventArgs handler)
        {
            if (handler.PropertyName == "SearchQuarry") Model.ApplyFilters();
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

        private AuctionSearchFilter _searchBarQuary;

        private AuctionCustomCheckBoxFilter _checkBoxFilterCompletedAuctions;

        private AuctionCustomCheckBoxFilter _checkBoxFilterBeOnAuctions;

        private AuctionCustomCheckBoxFilter _checkBoxFilterFuturedAuctions;
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
