using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.EnterWindow.AuthUC
{
    public class AuthUCModel
    {
        public static bool CheckUser(string login, string securePassword)
        {
            using (Entities DB = new Entities())
            {
                AuthorizationData intendedUser = DB.AuthorizationData.Find(login);
                if (intendedUser != null 
                    && intendedUser.SecurePasssword == securePassword)
                {
                    Application.Current.Resources.Add("CurrentUser", intendedUser);
                    return true;
                }
                return false;
            }
        }
    }
}
