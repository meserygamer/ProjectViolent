using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangePersonalDataWindow
{
    public class ChangePersonalDataWindowViewModel : INotifyPropertyChanged
    {
        public UserData DataOfCurrentUser
        {
            get => _dataOfCurrentUser;
            set
            {
                _dataOfCurrentUser = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ConfirmChangesCommand
        {
            get => _confirmChangesCommand ?? (_confirmChangesCommand = new RelayCommand(a => 
            {
                if(DataOfCurrentUser.Surname.Length == 0)
                {
                    MessageBox.Show("Фамилия пользователя пуста!");
                    return;
                }
                if (DataOfCurrentUser.Name.Length == 0)
                {
                    MessageBox.Show("Имя пользователя пустое!");
                    return;
                }
                switch(ChangePersonalDataWindowModel.SetUserData(DataOfCurrentUser))
                {
                    case 0:
                        {
                            MessageBox.Show("Изменения успешно произведены!");
                            return;
                            /////
                        }
                    case 1:
                        {
                            MessageBox.Show("Произошла ошибка, изменения не были произведены!");
                            return;
                        }
                }
            }));
        }

        public DateTime TimeNow
        {
            get => DateTime.Now;
        }


        public ChangePersonalDataWindowViewModel(int userID)
        {
            DataOfCurrentUser = ChangePersonalDataWindowModel.GetUserData(userID);
        }


        private UserData _dataOfCurrentUser;

        private RelayCommand _confirmChangesCommand;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
