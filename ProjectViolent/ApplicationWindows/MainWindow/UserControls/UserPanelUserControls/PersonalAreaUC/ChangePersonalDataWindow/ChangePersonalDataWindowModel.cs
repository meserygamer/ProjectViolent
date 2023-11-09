using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangePersonalDataWindow
{
    public class ChangePersonalDataWindowModel
    {
        public static UserData GetUserData(int UserID)
        {
            using(DataBase DB = new DataBase())
            {
                return DB.UserData.Find(UserID);
            }
        }

        public static int SetUserData(UserData changedData)
        {
            using (DataBase DB = new DataBase())
            {
                UserData MutableData = DB.UserData.Find(changedData.UserID);
                MutableData.Surname = changedData.Surname;
                MutableData.Name = changedData.Name;
                MutableData.Patronymic = changedData.Patronymic;
                MutableData.Birthday = changedData.Birthday;
                MutableData.GenderID = changedData.GenderID;
                try
                {
                    DB.SaveChanges();
                    return 0;
                }
                catch
                {
                    return 1;
                }
            }
        }
    }
}
