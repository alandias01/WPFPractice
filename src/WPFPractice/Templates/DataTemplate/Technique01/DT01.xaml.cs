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

namespace WPFPractice.Templates.DataTemplate.Technique01
{
    /// <summary>
    /// Interaction logic for DT01.xaml
    /// </summary>
    public partial class DT01 : Window
    {
        public ObservableCollection<ToolViewModel> Tools { get; set; }

        public DT01()
        {
            InitializeComponent();
            this.DataContext = this;

            Tools = new ObservableCollection<ToolViewModel>();

            Tools.Add(new AToolViewModel());
            Tools.Add(new BToolViewModel());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Tools.Add(new AToolViewModel());
        }

        
    }

    public class ToolViewModel
    {
        public String DisplayName { get; set; }
    }

    public class AToolViewModel : ToolViewModel
    {
        public AToolViewModel() { this.DisplayName = "A"; }
    }

    public class BToolViewModel : ToolViewModel
    {
        public string Greeting{get;set;}
        public BToolViewModel() 
        { 
            this.DisplayName = "B";
            Greeting = "hi";

        }
    }
}
