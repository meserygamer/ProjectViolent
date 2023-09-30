using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.RegUserDataUC
{
    public class RegUserDataUCModel
    {
        public static int? RegistrationUser(AuthorizationData RD, UserData UD)
        {
            using (DataBase DB = new DataBase())
            {
                UD.AuthorizationData = new List<AuthorizationData>() { RD };
                DB.UserData.Add(UD);
                try
                {
                    DB.SaveChanges();
                }
                catch
                {
                    return null;
                }
                return UD.UserID;
            }
        }
    }
}
