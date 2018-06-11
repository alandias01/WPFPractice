using System.Windows;
using Stock.Data;
using System.Collections.ObjectModel;

namespace WPFPractice.Templates.DataTemplate
{
    /// <summary>
    /// Interaction logic for DataTemplate01.xaml
    /// </summary>
    public partial class DataTemplate01 : Window
    {
        public ObservableCollection<IStockObject> SOList { get; set; }
        
        public DataTemplate01()
        {
            InitializeComponent();
            SOList = new StockDa(true).Positions;
            this.DataContext = this;
            
        }
    }
}
