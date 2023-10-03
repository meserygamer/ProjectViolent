using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC
{
    public class ShowMainTableDataBaseUCViewModel : INotifyPropertyChanged
    {
        private ShowMainTableDataBaseUCModel _model;

        public ShowMainTableDataBaseUCModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public ShowMainTableDataBaseUCViewModel()
        {
            Model = new ShowMainTableDataBaseUCModel();
            Model.UpdateAuctionList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class IdentifyUserThatDoBid : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)("(ID=" + ((UserData)value).UserID + ") " + ((UserData)value).Surname + " " + ((UserData)value).Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
