using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Stock.Data;
namespace WPFPractice
{
    /// <summary>
    /// Interaction logic for DGHighLightCell.xaml
    /// </summary>
    public partial class DGHighLightCell : Window
    {
        public DGHighLightCell()
        {
            InitializeComponent();
            this.DataContext = new DGHighLightCellViewModel();
        }
    }

    public class DGHighLightCellViewModel
    {
        public ObservableCollection<IStockObject> Pos { get; set; }
        public DGHighLightCellViewModel()
        {
            Pos = new StockDa(true).Positions;
            
            

        }
    }

    public class valconv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Int32 price = System.Convert.ToInt32(value);

            if (price > 110 && price < 115)
            {
                return "Red";
            }
            else { return null; }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }







}
