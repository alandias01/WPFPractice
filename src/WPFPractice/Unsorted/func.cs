using System;

namespace WPFPractice.Unsorted
{
    enum types
    {
        add,
        sub
    }

    public class func
    {
        public void test1()
        {
            string x = "su";
            types t = (types)Enum.Parse(typeof(types), x);            
        }

        static int Add(int x, int y)
        { return x + y; }

        static int Sub(int x, int y)
        { return x - y; }

        static int Mult(int x, int y)
        { return x * y; }

        static string[] commands = { "add", "sub", "mult" };

        static Func<int, int, int>[] funcs={Add, Sub, Mult };
    }
}