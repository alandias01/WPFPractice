using System;

namespace WPFPractice.Unsorted
{
    public delegate void MultDelegate(int num1, int num2);
    public class MathClass
    {
        public void Mult(int num1, int num2) { Console.WriteLine(num1 * num2); }
    }

    public class Delegates
    {
        public Delegates()
        {
            this.Delegate03();
        }

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