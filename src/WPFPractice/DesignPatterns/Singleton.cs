using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;

namespace ConsoleApplication1
{
    public class Singleton
    {
        private static  Singleton instance;

        private Singleton() { }

        public static Singleton getUniqueInstance () 
        {
            if (instance == null) { instance = new Singleton(); }
            return instance;
        }

    }

    //C# implementation using specific language rules
    public sealed class Singleton2
    {
        private static readonly Singleton2 instance = new Singleton2();

        private Singleton2() { }

        public static Singleton2 getUniqueInstance { get { return instance; } }
 
    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.ReadLine();
            //Console.WriteLine("");
        }
    }
}
