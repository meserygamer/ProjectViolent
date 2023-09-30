using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.RegUserDataUC
{
    public class RegUserDataUCViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surName;
        private string _patronymic;
        private DateTime _birthday;
        private int _idSelectedGender;
        private StateOfEnterWindow _enterWindowState;
        private RelayCommand _confirmData;

        public event Action<int> RegistrationWasComplete;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string SurName
        {
            get => _surName;
            set
            {
                _surName = value;
                OnPropertyChanged("SurName");
            }
        }

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public int IdSelectedGender
        {
            get => _idSelectedGender;
            set
            {
                _idSelectedGender = value;
                OnPropertyChanged("IdSelectedGender");
            }
        }

        public StateOfEnterWindow EnterWindowState
        {
            get => _enterWindowState;
            set
            {
                _enterWindowState = value;
                OnPropertyChanged("EnterWindowState");
            }
        }

        public RelayCommand ConfirmData
        {
            get => _confirmData ?? (new RelayCommand(obj =>
            {
                if (SurName is null || SurName == "")
                {
                    MessageBox.Show("Заполните фамилию");
                }
                else if (Name is null || Name == "")
                {
                    MessageBox.Show("Заполните имя");
                }
                else if (IdSelectedGender == 0)
                {
                    MessageBox.Show("Выберите пол");
                }
                else
                {
                    AuthorizationData RD = null;
                    try
                    {
                        RD = (AuthorizationData)Application.Current.Resources["RegData"];
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так");
                        return;
                    }
                    int? userID = null;
                    if ((userID = RegUserDataUCModel.RegistrationUser(RD, new UserData()
                    {
                        Name = Name,
                        Surname = SurName,
                        Patronymic = Patronymic,
                        Birthday = Birthday,
                        GenderID = IdSelectedGender,
                        RoleID = 1
                    })) != null)
                    {
                        RegistrationWasComplete((int)userID);
                        MessageBox.Show("Регистрация успешно завершена");
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                }
            }));
        }

        public RegUserDataUCViewModel()
        {
            Birthday = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
