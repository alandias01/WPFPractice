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

using System.Windows.Controls.Primitives;


namespace WPFPractice.styles
{
    /// <summary>
    /// Interaction logic for DatagridStyle.xaml
    /// </summary>
    public partial class DatagridStyle : Window
    {
        public ObservableCollection<StockObject> Pos { get; set; }

        public DatagridStyle()
        {
            InitializeComponent();
            this.DataContext = this;
            Pos = new StockDa(true).Positions;

            

        }
    }
}
