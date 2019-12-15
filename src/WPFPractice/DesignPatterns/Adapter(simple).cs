using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;


namespace Console_practice
{
    interface Duck { void quack(); void swim();}
    class Mallard : Duck 
    { 
        public void quack() { Console.WriteLine("Quack"); } 
        public void swim() { Console.WriteLine("Swim"); } 
    }

    class RedMallard:Duck
    {
        public void quack() { Console.WriteLine("RedQuack"); }
        public void swim() { Console.WriteLine("Swim"); }
    }

    class Turkey
    {
        public void gobble() { Console.WriteLine("gobblegobble"); }
        public void swim() { Console.WriteLine("Swim"); }
    }

    class TurkeyAdapter : Duck
    {
        Turkey turkey;
        public TurkeyAdapter(Turkey t) { this.turkey = t; }
        
        public void quack() { turkey.gobble(); }
        public void swim() { turkey.swim(); }
    }


    class Program
    {
        static void Main(string[] args)
        {

            RedMallard a = new RedMallard(); simulate(a);
            Turkey t=new Turkey();
            Duck tb = new TurkeyAdapter(t);
            simulate(tb);
  
            string z = Console.ReadLine();
        } //Main

        static void simulate(Duck duck) { duck.quack(); }

    }//Program

} //namespace Console_practice