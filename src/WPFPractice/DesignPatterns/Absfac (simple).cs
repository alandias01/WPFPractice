using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ConsolePractice.DesignPatterns
{
    public abstract class baseClass
    {
        public void speak()
        {
            string msg = createVoice();
            Console.WriteLine(msg);
        }

        protected abstract string createVoice();
    }

    public class subClass1 : baseClass
    {
        protected override string createVoice() { return "Im subclass 1"; }

    }

    public interface IDough { string getName(); }
    public class ThinCrustDough : IDough { public string getName() { return "TCD"; } }
    public interface IPIF { IDough createDough();}
    public class NYPIF : IPIF { public IDough createDough() { return new ThinCrustDough(); } }

    public abstract class Pizza
    {
        public string Name { get; set; }
        public IDough dough;
        public abstract void prepare();
    }

    public class ClamPizza:Pizza
    {
        IPIF ingFac;
        public ClamPizza(IPIF ingFac) { this.ingFac = ingFac; }
        public override void prepare() 
        { 
            dough = ingFac.createDough(); 
            Name = "thincrust"; 
            Console.WriteLine("Preparing " + dough.getName()); 
        }
    }

    public abstract class PizzaStore
    {        
        public void orderPizza()
        {
            Pizza pizza;
            pizza = createPizza(); pizza.prepare();
        }

        protected abstract Pizza createPizza();
    }

    public class NYPizzaStore : PizzaStore
    {
        IPIF ingFac; 
        Pizza pizza;
        protected override Pizza createPizza()
        {
            ingFac = new NYPIF();
            //switch
            pizza = new ClamPizza(ingFac);
            //end switch
            return pizza;            
        }
    }

    public class AbsFac
    {
        public AbsFac()
        {
            PizzaStore a = new NYPizzaStore();
            a.orderPizza();

            Console.ReadLine();
        }
    }
}
