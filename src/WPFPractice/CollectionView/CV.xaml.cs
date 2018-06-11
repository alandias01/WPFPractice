using System.Windows;
using System.Windows.Data;
using Stock.Data;
using System.Collections.ObjectModel;

namespace WPFPractice.CollectionView
{
    /// <summary>
    /// Interaction logic for CV.xaml
    /// </summary>
    public partial class CV : Window
    {
        public ObservableCollection<IStockObject> Pos { get; set; }

        public CV()
        {
            InitializeComponent();
            Pos = new StockDa(false).Positions;
            Pos.Add(new StockObject("IBM", 102, 120, 3));
            Pos.Add(new StockObject("JPM", 51, 120, 1));
            Pos.Add(new StockObject("IBM", 101, 120, 3));


            this.DataContext = this;
                        
            var cv = CollectionViewSource.GetDefaultView(Pos);
            //cv.Filter = ss;
            cv.GroupDescriptions.Add(new PropertyGroupDescription("Symbol"));
        }

        private bool ss(object t)        
        {
            var src = t as StockObject;
            return src.Symbol.ToLower() == "ibm";
            //CollectionViewGroup
            //DataGrid
        }
    }
}
