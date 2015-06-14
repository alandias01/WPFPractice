using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Stock.Data;
using System.Collections.ObjectModel;

namespace WPFPractice.Templates.DataTemplate
{
    /// <summary>
    /// Interaction logic for DataTemplate01.xaml
    /// </summary>
    public partial class DataTemplate01 : Window
    {
        public ObservableCollection<StockObject> SOList { get; set; }
        
        public DataTemplate01()
        {
            InitializeComponent();
            SOList = new StockDa(true).Positions;
            this.DataContext = this;
            
        }
    }
}
