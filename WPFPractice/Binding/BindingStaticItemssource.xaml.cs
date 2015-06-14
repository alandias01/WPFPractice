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

namespace WPFPractice.Binding
{
    /// <summary>
    /// Interaction logic for Binding01.xaml
    /// </summary>
    public partial class Binding01 : Window
    {
        public static ObservableCollection<Employee> EmpList = new ObservableCollection<Employee>() { new Employee(1, 1), new Employee(1, 2), new Employee(1, 3) };

        public Binding01()
        {
            InitializeComponent();
        }
    }


    public class Employee
    {
        public int A { get; set; }
        public int B { get; set; }

        public Employee(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}
