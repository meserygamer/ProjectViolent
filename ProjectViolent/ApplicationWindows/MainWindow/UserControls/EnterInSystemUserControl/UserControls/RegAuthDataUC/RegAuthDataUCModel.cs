using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.EnterInSystemUserControl.UserControls.RegAuthDataUC
{
    public class RegAuthDataUCModel
    {
        public static bool IsLoginFree(string login)
        {
            using (DataBase DB = new DataBase())
            {
                if (DB.AuthorizationData.Find(login) == null)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
