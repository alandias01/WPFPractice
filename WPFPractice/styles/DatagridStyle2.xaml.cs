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
using System.Collections.ObjectModel;
using Stock.Data;

namespace WPFPractice.styles
{
    /// <summary>
    /// Interaction logic for DatagridStyle2.xaml
    /// </summary>
    public partial class DatagridStyle2 : Window
    {
        public ObservableCollection<StockObject> Pos { get; set; }

        public DatagridStyle2()
        {
            InitializeComponent();
            this.DataContext = this;
            Pos = new StockDa(true).Positions;

        }
    }
}
