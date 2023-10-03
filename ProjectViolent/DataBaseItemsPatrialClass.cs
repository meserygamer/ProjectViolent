﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjectViolent
{
    public partial class Items
    {
        public BitmapImage BitImage
        {
            get
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new System.IO.MemoryStream( Image, 0,Image.Length);
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
