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

namespace WPFPractice.Binding
{
    /// <summary>
    /// Interaction logic for MasterDetailWithListView.xaml
    /// </summary>
    public partial class MasterDetailWithListView : Window
    {
        public MasterDetailWithListView()
        {
            InitializeComponent();
            StockDa SDA = new StockDa(true);
            this.DataContext = SDA.Positions;
        }
    }
}
