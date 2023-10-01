using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowInformationAboutAllUsersUC
{
    public class ShowInformationAboutAllUsersUCViewModel : INotifyPropertyChanged
    {
        public enum SortType
        {
            Ascending,
            Descending,
            Default
        }
        public enum GenderFilterType
        {
            Female,
            Male,
            All
        }
        public enum SearchType
        {
            SearchByID,
            SearchByLogin
        }

        private ShowInformationAboutAllUsersUCModel _model;

        private SortType _sortType;
        private SearchType _searchType;
        private GenderFilterType _genderFilterType;
        private string _findQuery;

        private RelayCommand _searchCommand;
        private RelayCommand _clearCommand;

        public ShowInformationAboutAllUsersUCModel Model
        {
            get => _model ?? (_model = new ShowInformationAboutAllUsersUCModel());
        }

        #region свойства для радио-кнопок сортировки
        public bool AscendingSortTypeIsChecked
        {
            get => (_sortType == SortType.Ascending) ? true : false;
            set
            {
                if (value)
                {
                    _sortType = SortType.Ascending;
                    OnPropertyChanged();
                    Model.UpdateGrid(_sortType, _genderFilterType);
                }
            }
        }

        public bool DescendingSortTypeIsChecked
        {
            get => (_sortType == SortType.Descending) ? true : false;
            set
            {
                if (value)
                {
                    _sortType = SortType.Descending;
                    OnPropertyChanged();
                    Model.UpdateGrid(_sortType, _genderFilterType);
                }
            }
        }

        public bool DefaultSortTypeIsChecked
        {
            get => (_sortType == SortType.Default) ? true : false;
            set
            {
                if (value)
                {
                    _sortType = SortType.Default;
                    OnPropertyChanged();
                    Model.UpdateGrid(null,_genderFilterType);
                }
            }
        }
        #endregion

        #region свойства для радио-кнопок фильтрации
        public bool FemaleGenderFilterTypeIsChecked
        {
            get => (_genderFilterType == GenderFilterType.Female) ? true : false;
            set
            {
                if (value)
                {
                    _genderFilterType = GenderFilterType.Female;
                    OnPropertyChanged();
                    Model.UpdateGrid(_sortType, GenderFilterType.Female);
                }
            }
        }

        public bool MaleGenderFilterTypeIsChecked
        {
            get => (_genderFilterType == GenderFilterType.Male) ? true : false;
            set
            {
                if (value)
                {
                    _genderFilterType = GenderFilterType.Male;
                    OnPropertyChanged();
                    Model.UpdateGrid(_sortType, GenderFilterType.Male);
                }
            }
        }

        public bool AllGenderFilterTypeIsChecked
        {
            get => (_genderFilterType == GenderFilterType.All) ? true : false;
            set
            {
                if (value)
                {
                    _genderFilterType = GenderFilterType.All;
                    OnPropertyChanged();
                    Model.UpdateGrid(_sortType, null);
                }
            }
        }
        #endregion

        #region свойства для радиокнопок поиска 
        public bool SearchByIDSearchTypeIsChecked
        {
            get => (_searchType == SearchType.SearchByID) ? true : false;
            set
            {
                if (value)
                {
                    _searchType = SearchType.SearchByID;
                    OnPropertyChanged();
                }
            }
        }

        public bool SearchByLoginSearchTypeIsChecked
        {
            get => (_searchType == SearchType.SearchByLogin) ? true : false;
            set
            {
                if (value)
                {
                    _searchType = SearchType.SearchByLogin;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public string FindQuery
        {
            get => _findQuery;
            set
            {
                _findQuery = value;
                OnPropertyChanged(nameof(FindQuery));
            }
        }

        public RelayCommand SearchCommand
        {
            get => _searchCommand ?? (_searchCommand = new RelayCommand(a => 
            {
                Model.UpdateGrid();
                DefaultSortTypeIsChecked = true;
                AllGenderFilterTypeIsChecked = true;
                switch (_searchType)
                {
                    case SearchType.SearchByID:
                        try
                        {
                            Model.FindUserByID(Convert.ToInt32(_findQuery));
                        }
                        catch
                        {
                            MessageBox.Show("ID пользователя является числом, повторите ввод!");
                            FindQuery = string.Empty;
                        }
                        break;
                    case SearchType.SearchByLogin:
                        Model.FindUserByLogin(_findQuery);
                        break;
                }
            }));
        }

        public RelayCommand ClearCommand
        {
            get => _clearCommand ?? (_clearCommand = new RelayCommand(a =>
            {
                Model.UpdateGrid();
                DefaultSortTypeIsChecked = true;
                AllGenderFilterTypeIsChecked = true;
                SearchByLoginSearchTypeIsChecked = true;
                FindQuery = string.Empty;
            }));
        }

        public ShowInformationAboutAllUsersUCViewModel()
        {
            DefaultSortTypeIsChecked = true;
            AllGenderFilterTypeIsChecked = true;
            SearchByLoginSearchTypeIsChecked = true;
            Model.UpdateGrid();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
