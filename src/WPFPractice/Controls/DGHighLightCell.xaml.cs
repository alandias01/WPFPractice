using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Shapes;
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
        public ObservableCollection<StockObject> Pos { get; set; }
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
