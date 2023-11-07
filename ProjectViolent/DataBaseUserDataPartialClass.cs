using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjectViolent
{
    public partial class UserData
    {
        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic + "(" + UserID + ")";
        }

        public BitmapImage BitImage
        {
            get
            {
                if(CurrentPhoto is null)
                {
                    return null;
                }
                BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream ImageStream = new System.IO.MemoryStream(CurrentPhoto, 0, CurrentPhoto.Length))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ImageStream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
                return bitmapImage;
            }
        }
    }
}
