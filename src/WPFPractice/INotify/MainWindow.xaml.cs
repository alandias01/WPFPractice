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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person;

        public MainWindow()
        {
            InitializeComponent();
            person = new Person("Alan", 25);
            this.DataContext = person;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            person.Age += 1;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(person.Age.ToString());
        }


    }


    public class Person : NPC
    {
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get { return _age; }
            set 
            { 
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        
        public Person(string N, int A)
        {
            this.Name = N;
            this.Age = A;
        }
                
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        */ 
    }

    public class NPC : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
