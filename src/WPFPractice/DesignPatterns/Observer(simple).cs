using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;


namespace Console_practice
{
    interface ISubject { void regObs(IObserver o); void notifyObs(); }
    interface IObserver { void update(int a);}

    class WeatherData : ISubject
    {
        int a=5;
        ArrayList observers;
        public WeatherData() { observers = new ArrayList(); }

        public void regObs(IObserver o) { observers.Add(o); }

        public void notifyObs()
        { foreach (IObserver obs in observers){ obs.update(a); } }
    }

    class DSP1 : IObserver
    {
        int a;  WeatherData wd;
        public DSP1(WeatherData wd) { this.wd = wd; wd.regObs(this); }
        public void update(int a) { this.a = a; display(); }
        public void display() { Console.WriteLine("DSP1 "+a); }
    }

    class DSP2 : IObserver
    {
        int a; WeatherData wd;
        public DSP2(WeatherData wd) { this.wd = wd; wd.regObs(this); }
        public void update(int a) { this.a = a; display(); }
        public void display() { Console.WriteLine("DSP2 " + (a+2)); }
    }



    class Program
    {
        static void Main(string[] args)
        {
            WeatherData wd = new WeatherData();
            DSP1 d1 = new DSP1(wd);
            DSP2 d2 = new DSP2(wd);
            wd.notifyObs();
            

            string z = Console.ReadLine();
        } //Main

        

    }//Program

} //namespace Console_practice