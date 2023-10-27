using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC
{
    public class AddNewAuctionItemUCModel
    {
        public static int AddNewItemAuctionItem(
            int UserID,
            string ItemName,
            string Description,
            byte[] Image)
        {
            try
            {
                using (DataBase DB = new DataBase())
                {
                    Items addingItem = new Items()
                    {
                        UserID = UserID,
                        ItemName = ItemName,
                        Description = Description,
                        Image = Image,
                    };
                    DB.Items.Add(addingItem);
                    DB.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}
