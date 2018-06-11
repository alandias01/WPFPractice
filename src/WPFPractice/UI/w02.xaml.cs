using System.Windows;

using Stock.Data;
using WPFUtils;

namespace WPFPractice.UI
{
    /// <summary>
    /// Interaction logic for w02.xaml
    /// </summary>
    public partial class w02 : Window
    {
        public ObservableCollectionEx<IStockObject> Pos { get; set; }

        public w02()
        {
            InitializeComponent();
            Pos = new ObservableCollectionEx<IStockObject>(new StockDa(true).Positions);
            Pos.Sort(x => x.Symbol);
            this.DataContext = this;            
        }        
    }    
}
