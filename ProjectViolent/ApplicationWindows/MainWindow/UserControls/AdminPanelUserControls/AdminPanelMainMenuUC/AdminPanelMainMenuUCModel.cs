using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AdminPanelMainMenuUC
{
    public class AdminPanelMainMenuUCModel
    {
        public static string FindNameFromId(int UserID)
        {
            using (DataBase DB = new DataBase())
            {
                return DB.UserData.Find(UserID).Name;
            }
        }

        public static string FindSurNameFromId(int UserID)
        {
            using (DataBase DB = new DataBase())
            {
                return DB.UserData.Find(UserID).Surname;
            }
        }
    }
}
