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
using System.Threading;
using System.Collections.ObjectModel;


namespace WPFPractice
{
    
    public partial class WindowStyling : Window
    {
        StockDa SDA = new StockDa(true);
        ObservableCollection<StockObject> Positions = new ObservableCollection<StockObject>();
        private readonly Random rand = new Random();

        public WindowStyling()
        {
            InitializeComponent();
            Positions = SDA.Positions;                        

            dataGridPositions.ItemsSource = Positions;

        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Positions.Add(new StockObject("r", 100, 120, 3));
        }
    }
}
