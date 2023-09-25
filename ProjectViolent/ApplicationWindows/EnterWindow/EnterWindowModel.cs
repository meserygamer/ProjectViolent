using ProjectViolent.ApplicationWindows.EnterWindow.RegUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectViolent.ApplicationWindows.EnterWindow
{
    public class EnterWindowModel
    {
        public static bool RegistrationUser()
        {
            AuthorizationData RD;
            UserData UD;
            try
            {
                RD = (AuthorizationData)Application.Current.Resources["RegData"];
                UD = (UserData)Application.Current.Resources["UserData"];
            }
            catch
            {
                return false;
            }
            using(Entities DB = new Entities())
            {
                UD.AuthorizationData = new List<AuthorizationData>() {RD};
                DB.UserData.Add(UD);
                try
                {
                    DB.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
