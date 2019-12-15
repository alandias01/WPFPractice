using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.EntityClient;
using System.Data.Linq.Mapping;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{

    class Program
    {        
        static void Main(string[] args)
        {
            new MyProg(); Console.ReadLine();            
        }
    }

    public class MyProg
    {
        public MyProg()
        {
            Coffee c = new Columbian();
            s(c);
            c = new Mocha(c);
            s(c);
            c = new Mocha(c);
            s(c);

        }

        public void s(Coffee c) {Console.WriteLine(c.GetDesc()+" Price: "+c.GetCost()); }


    }

    public class Coffee
    {
        protected string Desc;
        protected double Cost;
        public virtual string GetDesc() { return Desc; }
        public virtual double  GetCost() { return Cost; }
        public Coffee() { Desc = "Coffee"; Cost = 1.0; }
    }

    public class Columbian : Coffee
    {
        public Columbian() { }
        public override string GetDesc()
        {
            return "Columbian"+" "+ base.GetDesc();
        }

        public override double GetCost() { return base.GetCost() + .5; }
 
    }

    public abstract class Condiment : Coffee { }


    public class Mocha : Condiment
    {
        Coffee coffee;
        public Mocha(Coffee coffee) { this.coffee = coffee; }

        public override string GetDesc()
        {
            return coffee.GetDesc() + " + Mocha";
        }

        public override double GetCost()
        {
            return coffee.GetCost()+.75;
        }
    }

    



    




}
