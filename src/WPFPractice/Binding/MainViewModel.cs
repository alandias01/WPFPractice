using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFPractice.Binding
{
    public class MainViewModel
    {
        public Person person { get; set; }

        public MainViewModel()
        {
            person = new Person("Alan", 31); 
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string N, int A)
        {
            this.Name = N;
            this.Age = A;
        }

        
    }

}
