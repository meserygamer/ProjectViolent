using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC
{
    public class PersonalAreaUCModel
    {
        public UserData GetInfoAboutUser(int userID)
        {
            return _dataBase.UserData.Find(userID);
        }

        public AuthorizationData GetAuthorizationInfoAboutUser(int userID)
        {
            return _dataBase.UserData.Find(userID).AuthorizationData.First();
        }

        public int LoadPhotosInDataBase(string[] fileNames, int userID)
        {
            try
            {
                foreach (string filePath in fileNames)
                {
                    _dataBase.UsersPhotos.Add(new UsersPhotos()
                    {
                        UserID = userID,
                        Photo = File.ReadAllBytes(filePath)
                    });
                }
                _dataBase.SaveChanges();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int SetUserAvatar(string fileName, int userID) => SetUserAvatar(GetByteArrayFormOfImageFromFile(fileName), userID);

        public int SetUserAvatar(byte[] imageByteForm, int userID)
        {
            if (imageByteForm is null)
            {
                return 2; //Массив пуст
            }
            _dataBase.UserData.Find(userID).CurrentPhoto = imageByteForm;
            try
            {
                _dataBase.SaveChanges();
            }
            catch
            {
                return 1; //При внесении в базу произошла ошибка
            }
            return 0; //Всё корректно
        }

        public BitmapImage[] GetAllUserImages(int userID)
        {
            List<BitmapImage> UserImages = new List<BitmapImage>();
            foreach (var ImageData in _dataBase.UsersPhotos.Where(a => a.UserID == userID))
            {
                using(MemoryStream stream = new MemoryStream(ImageData.Photo, 0, ImageData.Photo.Length))
                {
                    BitmapImage AddingImage = new BitmapImage();
                    AddingImage.BeginInit();
                    AddingImage.StreamSource = stream;
                    AddingImage.CacheOption = BitmapCacheOption.OnLoad;
                    AddingImage.EndInit();
                    UserImages.Add(AddingImage);
                }
            }
            return UserImages.ToArray();
        }


        public PersonalAreaUCModel() 
        { 
            _dataBase = new DataBase();
        }


        /// <summary>
        /// Преобразует изображение по пути в байтовый массив
        /// </summary>
        /// <param name="filePath">Путь к изображению</param>
        /// <returns>Байтовый массив, если преобразование успешно, null, если что-то пошло не так</returns>
        private byte[] GetByteArrayFormOfImageFromFile(string filePath)
        {
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch
            {
                return null;
            }
        }


        private DataBase _dataBase;
    }
}
