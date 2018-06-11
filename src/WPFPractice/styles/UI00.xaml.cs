using System;
using System.Windows;
using Stock.Data;
using System.Collections.ObjectModel;

namespace WPFPractice
{
    
    public partial class WindowStyling : Window
    {
        StockDa SDA = new StockDa(true);
        ObservableCollection<IStockObject> Positions;
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
