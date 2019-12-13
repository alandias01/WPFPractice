using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFPractice.Controls
{
    /// <summary>
    /// Interaction logic for ListViewExample.xaml
    /// </summary>
    public partial class ListViewExample : Window
    {
        public ObservableCollection<Employee> EmpList { get; set; }

        public ListViewExample()
        {
            InitializeComponent();
            this.DataContext = this;

            this.EmpList = Employee.Load();
        }
    }
}
