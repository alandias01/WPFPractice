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
using System.ComponentModel;



namespace WPFPractice.Controls
{
    /// <summary>
    /// Interaction logic for datagridValidation.xaml
    /// </summary>
    public partial class datagridValidation : Window
    {
        public MySource MS { get; set; }

        public datagridValidation()
        {
            InitializeComponent();
            this.DataContext = this;
            MS = new MySource();
            MS.Age = 5;
        }
    }

    public class MySource : IDataErrorInfo
    {
        public string Name { get; set; }
        public double Age { get; set; }

        //Error for the whole object
        public string Error
        {
            get 
            {
                if (Name == "Alan" && Age < 5)
                { return "Alan is not less than 5"; }
                else { return ""; }
            }
        }

        //Error for each property
        public string this[string columnName]
        {
            get 
            {
                switch (columnName)
                {
                    case  "Age":
                        if (Name=="Ian" && Age <34)
                        {
                            
                            return "Yeah";                            
                        }
                        break;

                    case "Name":
                        break;

                    default:
                        throw new ArgumentException("Unknown Property: " + columnName, "columnName");
                }
                return "";
            }
        }

    }
}
