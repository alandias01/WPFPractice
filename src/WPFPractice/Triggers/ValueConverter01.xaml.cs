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
    
    /* Create a text box
     * If number >7, make yellow
     * 
     */

    public partial class ValueConverter01 : Window
    {
        public Person APerson { get; set; }

        public ValueConverter01()
        {            
            InitializeComponent();
            this.DataContext = this;
            APerson = new Person();
            APerson.Age = 6;
            APerson.Name = "Alan";
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class MyVal : IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int Result = 0;
            if (int.TryParse(value.ToString(), out Result))
            {
                return Result > 7;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true;
        }
    }
}

/*
 * <!--
            <TextBox.Triggers>
                <DataTrigger Binding="{}" Value="True">
                    <Setter Property="TextBox.Background" Value="Yellow"/>
                </DataTrigger>
            </TextBox.Triggers>
            -->
 */