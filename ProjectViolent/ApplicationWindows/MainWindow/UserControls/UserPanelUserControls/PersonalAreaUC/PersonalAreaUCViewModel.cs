using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC
{
    public class PersonalAreaUCViewModel : INotifyPropertyChanged
    {
        public UserData UserData
        {
            get => _userData;
            set
            {
                _userData = value;
                OnPropertyChanged(nameof(UserData));
            }
        }

        public RelayCommand AddPhotosInGalleryCommand
        {
            get => _addPhotosInGalleryCommand ?? (_addPhotosInGalleryCommand = new RelayCommand(a =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.ShowDialog();
                if(dialog.FileNames.Length == 0)
                {
                    return;
                }
                if(_model.LoadPhotosInDataBase(dialog.FileNames, _userID) == 1)
                {
                    MessageBox.Show("При загрузке фото, что-то пошло не так");
                    return;
                }
                MessageBox.Show("Загрузка успешно выполнена");
            }));
        }

        public RelayCommand SelectNewAvatarCommand
        {
            get => _selectNewAvatarCommand ?? (_selectNewAvatarCommand = new RelayCommand(a =>
            {
                switch(MessageBox.Show("Вы хотите выбрать изображение из галереи?", "Установка изображения", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Yes:
                        {
                            break;
                        }
                    case MessageBoxResult.No:
                        {
                            SetAvatarFromFile();
                            UserData = _model.GetInfoAboutUser(_userID);
                            break;
                        }
                    case MessageBoxResult.Cancel:
                        {
                            return;
                        }
                }
            }));
        }


        public PersonalAreaUCViewModel(int userID)
        {
            _userID = userID;
            _model = new PersonalAreaUCModel();
            UserData = _model.GetInfoAboutUser(userID);
        }


        private void SetAvatarFromFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName == string.Empty)
            {
                return;
            }
            if (_model.SetAvatarForUserFromFile(dialog.FileName, _userID) == 1)
            {
                MessageBox.Show("При загрузке изображения что-то пошло не так");
                return;
            }
            MessageBox.Show("Аватар успешно изменен!");
        }


        private int _userID;

        private UserData _userData;

        private RelayCommand _addPhotosInGalleryCommand;

        private RelayCommand _selectNewAvatarCommand;

        private PersonalAreaUCModel _model;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
