using Microsoft.Win32;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangeAuthorizationDataWindow;
using ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangePersonalDataWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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

        public AuthorizationData AuthorizationData
        {
            get => _authorizationData;
            set
            {
                _authorizationData = value;
                OnPropertyChanged(nameof(AuthorizationData));
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
                            UserImages = _model.GetAllUserImages(_userID);
                            IsImageSpinnerVisiable = true;
                            break;
                        }
                    case MessageBoxResult.No:
                        {
                            string avatarPath = SetAvatarFromFile();
                            if(avatarPath is null)
                            {
                                return;
                            }
                            _model.LoadPhotosInDataBase(new string[] { avatarPath }, _userID);
                            SetAllInformationAboutUser(_userID);
                            break;
                        }
                    case MessageBoxResult.Cancel:
                        {
                            return;
                        }
                }
            }));
        }

        public BitmapImage[] UserImages
        {
            get => _userImages;
            set
            {
                _userImages = value;
                OnPropertyChanged(nameof(UserImages));
            }
        }

        public byte[] SelectedSpinerImage
        {
            get => _selectedSpinerImage;
            set
            {
                _selectedSpinerImage = value;
                OnPropertyChanged(nameof(SelectedSpinerImage));
            }
        }

        public RelayCommand UserSelectedAvatarFromGalleryCommand
        {
            get => _userSelectedAvatarFromGalleryCommand ?? (_userSelectedAvatarFromGalleryCommand = new RelayCommand(a =>
            {
                if(_model.SetUserAvatar(SelectedSpinerImage, _userID) != 0)
                {
                    MessageBox.Show("Установить аватар не удалось");
                    return;
                }
                SetAllInformationAboutUser(_userID);
                IsImageSpinnerVisiable = false;
                MessageBox.Show("Аватар успешно обновлен!");
            }));
        }

        public bool IsImageSpinnerVisiable
        {
            get => _isImageSpinnerVisible;
            set
            {
                _isImageSpinnerVisible = value;
                OnPropertyChanged(nameof(IsImageSpinnerVisiable));
            }
        }

        public RelayCommand ChangePersonalDataCommand
        {
            get => _changePersonalDataCommand ?? (_changePersonalDataCommand = new RelayCommand(a => 
            {
                ChangePersonalDataWindowViewModel DC = new ChangePersonalDataWindowViewModel(_userID);
                ChangePersonalDataWindowView changePersonalDataWindowView = new ChangePersonalDataWindowView()
                {
                    DataContext = DC
                };
                changePersonalDataWindowView.ShowDialog();
                UpdateUserData(_userID);
            }));
        }

        public RelayCommand ChangeAuthorizationDataCommand
        {
            get => _changeAuthorizationDataCommand ?? (_changeAuthorizationDataCommand = new RelayCommand(a =>
            {
                ChangeAuthorizationDataWindowViewModel DC = new ChangeAuthorizationDataWindowViewModel(_userID);
                ChangeAuthorizationDataWindowView changeAuthorizationDataWindowView = new ChangeAuthorizationDataWindowView()
                {
                    DataContext = DC
                };
                changeAuthorizationDataWindowView.ShowDialog();
                UpdateAuthorizationData(_userID);
            }));
        }


        public PersonalAreaUCViewModel(int userID)
        {
            _userID = userID;
            _model = new PersonalAreaUCModel();
            SetAllInformationAboutUser(userID);
            IsImageSpinnerVisiable = false;
        }


        private string SetAvatarFromFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName == string.Empty)
            {
                return null;
            }
            if (_model.SetUserAvatar(dialog.FileName, _userID) == 1 ||
                _model.SetUserAvatar(dialog.FileName, _userID) == 2)
            {
                MessageBox.Show("При загрузке изображения что-то пошло не так");
                return null;
            }
            MessageBox.Show("Аватар успешно изменен!");
            return dialog.FileName;
        }

        private void SetAllInformationAboutUser(int userID)
        {
            UpdateUserData(userID);
            UpdateAuthorizationData(userID);
        }

        private void UpdateUserData(int userID) => UserData = _model.GetInfoAboutUser(userID);

        private void UpdateAuthorizationData(int userID) => AuthorizationData = _model.GetAuthorizationInfoAboutUser(userID);


        private int _userID;

        private UserData _userData;

        private AuthorizationData _authorizationData;

        private RelayCommand _addPhotosInGalleryCommand;

        private RelayCommand _selectNewAvatarCommand;

        private PersonalAreaUCModel _model;

        private BitmapImage[] _userImages;

        private byte[] _selectedSpinerImage;

        private RelayCommand _userSelectedAvatarFromGalleryCommand;

        private bool _isImageSpinnerVisible;

        private RelayCommand _changePersonalDataCommand;

        private RelayCommand _changeAuthorizationDataCommand;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
