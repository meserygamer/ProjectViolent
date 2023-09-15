using ProjectViolent.ApplicationWindows.EnterWindow.RegUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.EnterWindow.SetPersonalDataUC
{
    public class SetPersonalDataUCModel
    {
        public static async void AddUserInSystem(UserData UD, RegData RD)
        {
            await new Task(() =>
            {
                using (Entities DB = new Entities())
                {
                    DB.UserData.Add(new ProjectViolent.UserData()
                    {
                        Name = UD.UserName,
                        Surname = UD.UserSurName,
                        Patronymic = UD.UserPatronymic,
                        Birthday = UD.BirthDay,
                        GenderID = UD.IdGender,
                        AuthorizationData = new List<AuthorizationData>()
                        {
                            new AuthorizationData() 
                            {
                                Login = RD.Login,
                                SecurePasssword = RD.PasswordHash
                            }
                        }
                    });
                    DB.SaveChanges();
                }
            });
        }
    }
}
