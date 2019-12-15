using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApplication1
{
    public interface MyObservable { void register(MyObserver o); void notify();}
    public interface MyObserver { void update();}

    public class Subject : MyObservable
    {
        List<MyObserver> observers=new List<MyObserver>();
        public void register(MyObserver o) { observers.Add(o); }
        public void notify() { foreach (MyObserver o in observers) { o.update(); } }
    }

    public class MyControl : MyObserver
    {
        public MyControl(Subject s) { s.register(this); }
        public void update() { Console.WriteLine("This control added"); }
    }

    class Program
    {        
        static void Main(string[] args)
        {
            Subject s = new Subject();
            MyControl c1 = new MyControl(s);
            MyControl c2 = new MyControl(s);
            MyControl c3 = new MyControl(s);

            s.notify();
            //This control added
            //This control added
            //This control added

            Console.ReadLine();
        }
    }
}
