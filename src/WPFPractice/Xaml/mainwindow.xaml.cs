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

namespace WPFPractice.Xaml
{
    /// <summary>
    /// Interaction logic for mainwindow.xaml
    /// </summary>
    public partial class mainwindow : Window
    {
        public mainwindow()
        {
            InitializeComponent();
        }
    }

    public class MyData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
