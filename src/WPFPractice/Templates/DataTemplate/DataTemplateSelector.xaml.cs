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

namespace WPFPractice.Templates.DataTemplate
{
    /// <summary>
    /// Interaction logic for DataTemplateSelector.xaml
    /// </summary>
    public partial class DataTemplateSelector01 : Window
    {
        public DataTemplateSelector01()
        {
            InitializeComponent();
            this.DataContext = new StockDa(true).Positions;


        }
    }

    public class PropertyDataTemplateSelector : DataTemplateSelector
    {        
        public System.Windows.DataTemplate DefaultnDataTemplate { get; set; }
        public System.Windows.DataTemplate GreaterThanDataTemplate { get; set; }
        public System.Windows.DataTemplate LessThanDataTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            StockObject SO = item as StockObject; ;

            if (SO.Price>100)
            {
                return GreaterThanDataTemplate;                
            }

            if (SO.Price < 100)
            {
                return LessThanDataTemplate;
            }

            return DefaultnDataTemplate;
        }


    }


}
