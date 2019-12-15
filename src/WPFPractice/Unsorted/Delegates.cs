using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Linq;
using System.Data.Linq;



namespace Console_practice
{
    public delegate void MultDelegate(int num1, int num2);
    public class MathClass
    {
        public void Mult(int num1, int num2) { Console.WriteLine(num1 * num2); }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            DelegateExamples d = new DelegateExamples();
            d.Delegate03();

            Console.ReadLine();
        }
    }



    public class DelegateExamples
    {
        public void Delegate01()
        {
            MathClass myMathClass = new MathClass();
            MultDelegate dm = new MultDelegate(myMathClass.Mult);
            dm(5, 4); //20            
        }

        public string v() { return "f"; }
        public void Delegate02() { Func<string> f = new Func<string>(v); Console.WriteLine(f()); }

        public void Delegate03()
        {
            
 
        }
        
        
 
    }

} //namespace Console_practice