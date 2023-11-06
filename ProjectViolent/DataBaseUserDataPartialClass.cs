using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent
{
    public partial class UserData
    {
        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic + "(" + UserID + ")";
        }
    }
}
