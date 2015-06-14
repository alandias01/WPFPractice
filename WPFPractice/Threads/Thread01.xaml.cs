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

using SL.Data;
using WPFUtils;

namespace WPFPractice.Threads
{
    
    public partial class Thread01 : Window
    {
        StockDataProvider SDP = new StockDataProvider(true);
        public ObservableCollectionEx<SL.Data.Stock> StockList { get; set; }

        public Thread01()
        {
            InitializeComponent();
            this.DataContext = this;
            StockList = new ObservableCollectionEx<SL.Data.Stock>(SDP.StockList);

        }
    }
}
