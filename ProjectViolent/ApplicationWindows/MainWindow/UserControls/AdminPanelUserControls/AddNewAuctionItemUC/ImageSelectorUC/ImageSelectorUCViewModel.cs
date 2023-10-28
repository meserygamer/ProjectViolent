using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC.ImageSelectorUC
{
    public class WPFImage : INotifyPropertyChanged
    {
        public BitmapImage Image
        {
            get => _image;
            private set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public byte[] ImageBytes
        {
            get => _imageBytes;
            set
            {
                _imageBytes = value;
                OnPropertyChanged(nameof(ImageBytes));
            }
        }


        public void UpdateImage()
        {
            try
            {
                BitmapImage newBMI = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(ImageBytes))
                {
                    newBMI.BeginInit();
                    newBMI.StreamSource = ms;
                    newBMI.CacheOption = BitmapCacheOption.OnLoad;
                    newBMI.EndInit();
                }
                Image = newBMI;
            }
            catch
            {
                Image = null;
            }
        }


        public WPFImage(byte[] imageBytes)
        {
            ImageBytes = imageBytes;
            UpdateImage();
        }

        public WPFImage()
        {
            Image = null;
            ImageBytes = null;
        }


        private BitmapImage _image;

        private byte[] _imageBytes;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ImageSelectorUCViewModel : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SelectedImageProperty =
            DependencyProperty.Register("SelectedImage", typeof(WPFImage), typeof(ImageSelectorUCViewModel));

        public WPFImage SelectedImage
        {
            get { return (WPFImage)GetValue(SelectedImageProperty); }
            set { SetValue(SelectedImageProperty, value); }
        }


        /// <summary>
        /// Команда обработки нажатия на кнопку загрузки новой картинки
        /// </summary>
        public RelayCommand ChooseANewPictureCommand
        {
            get => _chooseANewPictureCommand ?? (_chooseANewPictureCommand = new RelayCommand(a =>
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                try
                {
                    SelectedImage = new WPFImage(File.ReadAllBytes(fileDialog.FileName));
                }
                catch
                {
                    MessageBox.Show("При загрузке картинки что-то пошло не так");
                }
            }));
        }


        private RelayCommand _chooseANewPictureCommand;


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
