using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.LoginUC
{
    public class LoginUCModel
    {
        public static int? CheckUser(string login, string securePassword)
        {
            using (DataBase DB = new DataBase())
            {
                AuthorizationData intendedUser = DB.AuthorizationData.Find(login);
                if (intendedUser != null
                    && intendedUser.SecurePasssword == securePassword)
                {
                    return intendedUser.UserID;
                }
                return null;
            }
        }
    }
}
