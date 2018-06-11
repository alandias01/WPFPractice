using System.Windows;
using System.Collections.ObjectModel;
using Stock.Data;

namespace WPFPractice.styles
{
    /// <summary>
    /// Interaction logic for DatagridStyle.xaml
    /// </summary>
    public partial class DatagridStyle : Window
    {
        public ObservableCollection<IStockObject> Pos { get; set; }

        public DatagridStyle()
        {
            InitializeComponent();
            this.DataContext = this;
            Pos = new StockDa(true).Positions;

            

        }
    }
}
