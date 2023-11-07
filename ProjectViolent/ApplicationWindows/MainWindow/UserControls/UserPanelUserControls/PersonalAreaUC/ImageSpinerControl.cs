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
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC
{
    public class ImageSpiner : Control, INotifyPropertyChanged
    {
        public RelayCommand LeftButton
        {
            get => _leftButton ?? (_leftButton = new RelayCommand((a) => 
            {
                _displayedImagesCounter--;
                SetCurrentImages();
            }));
        }

        public RelayCommand RightButton
        {
            get => _rightButton ?? (_rightButton = new RelayCommand((a) =>
            {
                _displayedImagesCounter++;
                SetCurrentImages();
            }));
        }

        public BitmapImage[] BitmapImages
        {
            get => (BitmapImage[])GetValue(InputImagesArrayProperty);
            set => SetValue(InputImagesArrayProperty, value);
        }

        public ObservableCollection<BitmapImage> DisplayedImages
        {
            get => _displayedImages;
            set
            {
                _displayedImages = value;
                OnPropertyChanged();
            }
        }


        public static DependencyProperty InputImagesArrayProperty = DependencyProperty.Register("BitmapImages", typeof(BitmapImage[]), typeof(ImageSpiner));


        public ImageSpiner()
        {
            DependencyPropertyDescriptor descriptorSelectedDate = DependencyPropertyDescriptor.FromProperty(InputImagesArrayProperty, typeof(ImageSpiner));
            descriptorSelectedDate.AddValueChanged(this, ChangedInputImages);
            _displayedImagesCounter = 0;
            _spinerSource = new PythonList<BitmapImage>();
            DisplayedImages = new ObservableCollection<BitmapImage>(){null, null, null};
        }


        private void ChangedInputImages(object sender, EventArgs e)
        {
            DisplayedImages = new ObservableCollection<BitmapImage>();
            if(BitmapImages.Length == 0)
            {
                return;
            }
            _spinerSource = new PythonList<BitmapImage>(BitmapImages);
            _displayedImagesCounter = 0;
            SetCurrentImages();
        }

        private void SetCurrentImages()
        {
            DisplayedImages[0] = _spinerSource[_displayedImagesCounter];
            DisplayedImages[1] = _spinerSource[_displayedImagesCounter + 1];
            DisplayedImages[2] = _spinerSource[_displayedImagesCounter + 2];
        }


        private RelayCommand _leftButton;

        private RelayCommand _rightButton;

        private PythonList<BitmapImage> _spinerSource;

        private ObservableCollection<BitmapImage> _displayedImages;

        private int _displayedImagesCounter;


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
