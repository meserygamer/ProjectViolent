using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC
{
    public class PersonalAreaUCModel
    {
        public UserData GetInfoAboutUser(int userID)
        {
            return _dataBase.UserData.Find(userID);
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

        public int SetAvatarForUserFromFile(string fileName, int userID)
        {
            try
            {
                byte[] LoadedImage = File.ReadAllBytes(fileName);
                _dataBase.UserData.Find(userID).CurrentPhoto = LoadedImage;
                _dataBase.UsersPhotos.Add(new UsersPhotos()
                {
                    UserID = userID,
                    Photo = LoadedImage
                });
                _dataBase.SaveChanges();
                return 0;
            }
            catch
            {
                return 1;
            }
        }


        public PersonalAreaUCModel() 
        { 
            _dataBase = new DataBase();
        }


        private DataBase _dataBase;
    }
}
