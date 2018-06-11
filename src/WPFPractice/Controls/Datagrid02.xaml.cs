using System;
using System.Windows;
using System.Windows.Data;
using WPFUtils;
using Stock.Data;

namespace WPFPractice.Controls
{
    /// <summary>
    /// Interaction logic for Datagrid02.xaml
    /// </summary>
    public partial class Datagrid02 : Window
    {
                
        public ObservableCollectionEx<IStockObject> Pos { get; set; }

        public Datagrid02()
        {
            InitializeComponent();
            Pos = new ObservableCollectionEx<IStockObject>(new StockDa(true).Positions);
            Pos.Sort(x => x.Symbol);
            this.DataContext = this;
            DGV1.ItemsSource = Pos;
        }
    }

    public class PriceValidator : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int P = System.Convert.ToInt32(value);
            return P < 110 && P > 107;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true;
        }
    }
}
