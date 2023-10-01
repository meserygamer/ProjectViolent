using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow
{
    public class MainWindowModel
    {
        public static int? DefineRole(int UserRole)
        {
            using(DataBase DB = new DataBase())
            {
                return DB.UserData.Find(UserRole).RoleID;
            }
        }
    }
}
