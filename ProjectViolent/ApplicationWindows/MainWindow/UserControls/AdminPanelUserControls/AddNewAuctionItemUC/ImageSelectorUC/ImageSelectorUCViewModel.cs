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
    public class ImageSelectorUCViewModel : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SelectedImageProperty =
            DependencyProperty.Register("SelectedImage", typeof(byte[]), typeof(ImageSelectorUCViewModel));

        public byte[] SelectedImage
        {
            get { return (byte[])GetValue(SelectedImageProperty); }
            set { SetValue(SelectedImageProperty, value); }
        }

        /// <summary>
        /// Хранит текущее отображаемое изображение
        /// </summary>
        public BitmapImage Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged();
            }
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
                    SetNewImage(File.ReadAllBytes(fileDialog.FileName));
                    SelectedImage = File.ReadAllBytes(fileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("При загрузке картинки что-то пошло не так");
                }
            }));
        }

        private BitmapImage _image;

        private RelayCommand _chooseANewPictureCommand;

        private void SetNewImage(byte[] ImageByteForm)
        {
            BitmapImage newBMI = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(ImageByteForm))
            {
                newBMI.BeginInit();
                newBMI.StreamSource = ms;
                newBMI.CacheOption = BitmapCacheOption.OnLoad;
                newBMI.EndInit();
            }
            Image = newBMI;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
