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
using WPFUtils;

namespace WPFPractice.UI
{
    /// <summary>
    /// Interaction logic for w02.xaml
    /// </summary>
    public partial class w02 : Window
    {
        public ObservableCollectionEx<StockObject> Pos { get; set; }

        public w02()
        {
            InitializeComponent();
            Pos = new ObservableCollectionEx<StockObject>(new StockDa(true).Positions);
            Pos.Sort(x => x.Symbol);
            this.DataContext = this;            
        }       
        
    }
    
}
