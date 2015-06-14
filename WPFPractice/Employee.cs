using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPFPractice
{    
    public class Employee
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged("Name"); }
        }

        int age;
        public int Age
        {
            get { return age; }
            set { age = value; RaisePropertyChanged("Age"); }
        }

        public Employee(string n, int a)
        {
            Name = n;
            Age = a;
        }

        public static ObservableCollection<Employee> Load()
        {
            return new ObservableCollection<Employee> { new Employee("alan", 1), new Employee("Ben", 2), new Employee("Kyle", 3), new Employee("Stan", 4) };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
			    
			
}
