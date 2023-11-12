using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.UserPanelUserControls.PersonalAreaUC.ChangeAuthorizationDataWindow
{
    public static class ChangeAuthorizationDataWindowModel
    {
        public static AuthorizationData GetAuthorizationData(int userID)
        {
            using (DataBase DB = new DataBase())
            {
                return DB.AuthorizationData.Where(a => a.UserID == userID).First();
            }
        }

        public static int UpdateAuthorizationData(AuthorizationData userData, int userID)
        {
            try
            {
                using(DataBase DB = new DataBase())
                {
                    AuthorizationData ChangingData = DB.AuthorizationData.Single(a => a.UserID == userID);
                    AuthorizationData NewData = new AuthorizationData()
                    {
                        UserID = ChangingData.UserID,
                        Login = userData.Login,
                        SecurePasssword = ChangingData.SecurePasssword
                    };
                    if (userData.SecurePasssword != null)
                    {
                        NewData.SecurePasssword = userData.SecurePasssword;
                    }
                    DB.AuthorizationData.Remove(ChangingData);
                    DB.AuthorizationData.Add(NewData);
                    DB.SaveChanges();
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }
    }
}
