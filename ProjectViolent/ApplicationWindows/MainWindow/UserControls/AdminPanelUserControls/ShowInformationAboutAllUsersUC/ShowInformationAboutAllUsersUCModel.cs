using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowInformationAboutAllUsersUC
{
    public class ShowInformationAboutAllUsersUCModel : INotifyPropertyChanged
    {
        private List<UserData> _userDatas = new List<UserData>();
        private DataBase _dataBase = new DataBase();

        public List<UserData> UserDatas
        {
            get => _userDatas;
            set
            {
                _userDatas = value;
                OnPropertyChanged(nameof(UserDatas));
            }
        }

        public bool UpdateGrid(ShowInformationAboutAllUsersUCViewModel.SortType? sortType = null,
            ShowInformationAboutAllUsersUCViewModel.GenderFilterType? genderFilterType = null)
        {
            try
            {
                UserDatas = _dataBase.UserData.ToList();
            }
            catch
            {
                return false;
            }
            if(sortType!=null)
            {
                switch (sortType)
                {
                    case ShowInformationAboutAllUsersUCViewModel.SortType.Ascending:
                        AscendingSortBySurname();
                        break;
                    case ShowInformationAboutAllUsersUCViewModel.SortType.Descending:
                        DescendingSortBySurname();
                        break;
                    default:
                        break;
                }
            }
            if(genderFilterType != null)
            {
                switch(genderFilterType)
                {
                    case ShowInformationAboutAllUsersUCViewModel.GenderFilterType.Female:
                        ShowOnlyFemale();
                        break;
                    case ShowInformationAboutAllUsersUCViewModel.GenderFilterType.Male:
                        ShowOnlyMans();
                        break;
                    case ShowInformationAboutAllUsersUCViewModel.GenderFilterType.All:
                        break;
                }
            }
            return true;
        }

        public bool AscendingSortBySurname()
        {
            try
            {
                UserDatas = _userDatas.OrderBy(x => x.Surname).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DescendingSortBySurname()
        {
            try
            {
                UserDatas = _userDatas.OrderByDescending(x => x.Surname).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool ShowOnlyFemale()
        {
            try
            {
                UserDatas = _userDatas.Where(a => a.GenderID == 2).ToList();
            }
            catch 
            { 
                return false;
            }
            return true;
        }

        public bool ShowOnlyMans()
        {
            try
            {
                UserDatas = _userDatas.Where(a => a.GenderID == 1).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool FindUserByID(int UserID)
        {
            try
            {
                UserDatas = _userDatas.FindAll(x => x.UserID == UserID);
            }
            catch 
            { 
                return false;
            }
            return true;
        }

        public bool FindUserByLogin(string Login)
        {
            try
            {
                UserDatas = _userDatas.FindAll(x => x.AuthorizationData.ToList()[0].Login == Login);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class AuthorizationDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((HashSet<AuthorizationData>)value).First().Login;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
