using ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewItemUC.UserControls.DateTimePicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.AddNewAuctionItemUC.ImageSelectorUC
{
    /// <summary>
    /// Логика взаимодействия для ImageSelectorUCView.xaml
    /// </summary>
    public partial class ImageSelectorUCView : UserControl
    {
        public static readonly DependencyProperty SelectedImageProperty =
            DependencyProperty.Register("SelectedImage", typeof(byte[]), typeof(ImageSelectorUCView));

        public byte[] SelectedImage
        {
            get { return (byte[])GetValue(SelectedImageProperty); }
            set { SetValue(SelectedImageProperty, value); }
        }

        public ImageSelectorUCView()
        {
            InitializeComponent();
        }
    }

    public class ProxyElem : Freezable
    {
        public static readonly DependencyProperty SelectedImageProperty =
            DependencyProperty.Register("SelectedImage", typeof(byte[]), typeof(ProxyElem));

        public byte[] SelectedImage
        {
            get { return (byte[])GetValue(SelectedImageProperty); }
            set { SetValue(SelectedImageProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new ProxyElem();
        }
    }
}
