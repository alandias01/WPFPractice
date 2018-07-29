using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFPractice.SmartGrid
{
    /// <summary>
    /// Interaction logic for SmartGridExampleView.xaml
    /// </summary>
    public partial class SmartGridExampleView : Window
    {
        public SmartGridExampleView()
        {
            InitializeComponent();
            var rowvm = new RowViewModel();
            rowvm[0] = "Hello";
        }
    }
}
