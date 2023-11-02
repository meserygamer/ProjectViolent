using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjectViolent.ApplicationWindows.MainWindow.UserControls.AdminPanelUserControls.ShowMainTableDataBaseUC.FIltAndSortUC
{
    /// <summary>
    /// Логика взаимодействия для FiltAndSortUCView.xaml
    /// </summary>
    public partial class FiltAndSortUCView : UserControl
    {

        public ObservableCollection<Auction> InputObserverCollectionProperty
        {
            get => (ObservableCollection<Auction>)GetValue(InputObserverCollectionDependencyProperty);
            set => SetValue(InputObserverCollectionDependencyProperty, value);
        }

        public ObservableCollection<Auction> OutputObserverCollectionProperty
        {
            get { return (ObservableCollection<Auction>)GetValue(OutputObserverCollectionDependencyProperty); }
            set { SetValue(OutputObserverCollectionDependencyProperty, value); }
        }


        public static DependencyProperty InputObserverCollectionDependencyProperty =
            DependencyProperty.Register("InputObserverCollectionProperty", typeof(ObservableCollection<Auction>), typeof(FiltAndSortUCView));

        public static readonly DependencyProperty OutputObserverCollectionDependencyProperty =
            DependencyProperty.Register("OutputObserverCollectionProperty", typeof(ObservableCollection<Auction>), typeof(FiltAndSortUCView));


        public FiltAndSortUCView()
        {
            InitializeComponent();
        }
    }

    public partial class Proxy : Freezable
    {

        public ObservableCollection<Auction> InputObserverCollectionProperty
        {
            get => (ObservableCollection<Auction>)GetValue(InputObserverCollectionDependencyProperty);
            set => SetValue(InputObserverCollectionDependencyProperty, value);
        }

        public ObservableCollection<Auction> OutputObserverCollectionProperty
        {
            get { return (ObservableCollection<Auction>)GetValue(OutputObserverCollectionDependencyProperty); }
            set { SetValue(OutputObserverCollectionDependencyProperty, value); }
        }


        public static DependencyProperty InputObserverCollectionDependencyProperty =
            DependencyProperty.Register("InputObserverCollectionProperty", typeof(ObservableCollection<Auction>), typeof(Proxy));

        public static readonly DependencyProperty OutputObserverCollectionDependencyProperty =
            DependencyProperty.Register("OutputObserverCollectionProperty", typeof(ObservableCollection<Auction>), typeof(Proxy));


        protected override Freezable CreateInstanceCore()
        {
            return new Proxy();
        }
    }
}
