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

namespace WPFPractice.Triggers
{
    /// <summary>
    /// Interaction logic for T01.xaml
    /// </summary>
    public partial class T01 : Window
    {
        public Happy H1 { get; set; }
        
        public T01()
        {
            InitializeComponent(); //Button b = new Button();b.mous
            this.DataContext = this;
            H1 = new Happy();
            
            H1.Name = "Datatrigger";
            H1.HappyStatus = Status.bad;            
        }
    }

    public class Happy
    {
        public Status HappyStatus { get; set; }
        public string Name { get; set; }
        public int Age { get; set; } 
    }

    public enum Status
    {
        none,
        good,
        bad 
    }

    public class MyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int tmpage = System.Convert.ToInt32(value);
            return tmpage <= 20;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true;
        }
    }

    
}
