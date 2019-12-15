using System; using System.Collections; using System.Collections.Generic;
using System.Collections.ObjectModel; using System.Collections.Specialized;
using System.Text;

namespace Console_practice
{
    public enum bondType {corp, gov}

    abstract class Bond
    {
        public string name;        
        public void processing() { Console.WriteLine("You are purchasing a "+name); }
    }

    class Gov : Bond{ public Gov() {name="Government Bond";} }
    class Corp : Bond { public Corp() {name="Corporate Bond"; } }

    class Exchange
    {
        public Bond buyBond(bondType type)
        {
            Bond bond = createBond(type);
            bond.processing();
            return bond;        
        }

        private Bond createBond(bondType type) 
        {
            Bond bond=null;
            if(type.Equals(bondType.corp)){bond=new Corp();}
            else if(type.Equals(bondType.gov)){bond=new Corp();}
            return bond;
        }    
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange();
            exchange.buyBond(bondType.corp);

            string z = Console.ReadLine();
        } //Main

    }//Program

} //namespace Console_practice