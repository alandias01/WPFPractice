using System.Windows;
using System.Collections.ObjectModel;
using Stock.Data;

namespace WPFPractice.styles
{
    /// <summary>
    /// Interaction logic for DatagridStyle2.xaml
    /// </summary>
    public partial class DatagridStyle2 : Window
    {
        public ObservableCollection<IStockObject> Pos { get; set; }

        public DatagridStyle2()
        {
            InitializeComponent();
            this.DataContext = this;
            Pos = new StockDa(true).Positions;

        }
    }
}
