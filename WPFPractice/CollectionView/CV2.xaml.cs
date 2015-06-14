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
using System.ComponentModel;

using Stock.Data;

namespace WPFPractice.CollectionView
{    
    public partial class CV2 : Window
    {
        public ObservableCollection<StockObject> Pos { get; set; }
        ICollectionView cv;
        
        public CV2()
        {
            InitializeComponent();
            Pos = new StockDa(false).Positions;
            cv = CollectionViewSource.GetDefaultView(Pos);
            this.DataContext = this;

            Pos.Add(new StockObject("International Business Machines Corporation", "912828C01", "IBM", 102, 120, 3));
            Pos.Add(new StockObject("JPMorgan Chase & Co.", "049512865", "JPM", 51, 120, 1));
            Pos.Add(new StockObject("International Business Machines Corporation", "912828C01", "IBM", 101, 120, 3));            

        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            /*
            cv.Filter += new Predicate<object>((o) => 
            {
                StockObject so = o as StockObject; 
                return so.Symbol.ToLower() == "ibm";
            });
             */

            //Simpler
            cv.Filter += (o) =>
            {
                StockObject so = o as StockObject;
                return so.Symbol.ToLower() == "ibm";
            };
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            cv.Filter = null;
        }

        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            cv.GroupDescriptions.Add(new PropertyGroupDescription("Symbol"));            
        }

        private void checkBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            cv.GroupDescriptions.Clear();
        }
    }
}
