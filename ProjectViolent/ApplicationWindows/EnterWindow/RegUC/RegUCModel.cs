using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.EnterWindow.RegUC
{
    public class RegUCModel
    {
        public static bool IsLoginFree(string login)
        {
            using(Entities DB = new Entities())
            {
                if(DB.AuthorizationData.Find(login) == null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
