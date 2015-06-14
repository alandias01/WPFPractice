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

namespace WPFPractice.UI
{
    /// <summary>
    /// Interaction logic for w03.xaml
    /// </summary>
    public partial class FontPolyline : Window
    {
        
        public PointCollection points { get; set; }
        public FontPolyline()
        {            
            InitializeComponent();
            this.DataContext = this;
            points = new PointCollection();            
            points.Add(new Point(1, 1));
            points.Add(new Point(100, 100));
            points.Add(new Point(200, 1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double p1 = Convert.ToDouble(px.Text);
            double p2 = Convert.ToDouble(py.Text);            
            points.Add(new Point(p1, p2));            
        }
    }

    
}
