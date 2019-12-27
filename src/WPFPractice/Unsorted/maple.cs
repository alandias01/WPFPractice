using System;
using System.Collections.Generic;
using System.IO;

namespace WPFPractice.Unsorted
{
    /*
     * This application was designed for scalability
     * All we need to do is create multiple trader classes for each person who wants to trade
     * The details of a traders position were abstracted away from the trader class and I created its own position class
     * This way if anything changes relating to position, we don't have to touch the trader class
     * Same goes for the trade class
     * Each class deals only with it own responsibility (SRP, high cohesion, abstraction, low coupling)
     * I could create interfaces for each class for better abstraction
     */

    public class Position
    {
        public Dictionary<string, int> pos=new Dictionary<string,int>();
        
        /* update Position
         * If direction is a buy, we add the quantity, else subtract
         */
        public void updatePosition(List<Trade> trades) 
        {
            foreach (Trade t in trades)
            {                
                if (pos.ContainsKey(t.symbol)) //Check if key exists, else added to pos
                {                    
                    if (t.buysell == "BUY") { pos[t.symbol] += t.quantity;  }
                    else { pos[t.symbol] -= t.quantity; }
                }
                else { pos.Add(t.symbol, t.quantity); }
            }
        }

        public void generateReport() //Creates report
        {
            using (StreamWriter sw = File.AppendText(@"c:/maple/report.txt")) 
            {
                foreach (KeyValuePair<string, int> k in pos) { sw.WriteLine(k.Key + " " + k.Value); }
                sw.WriteLine();            
            }
        }
    }

    public class Trade
    {
        public string symbol { get;  set; }
        public string buysell { get;  set; }
        public int quantity { get;  set; }
        public string orderTime { get;  set; }

        public Trade(string symbol, string buysell, int quantity, string orderTime)
        {
            this.symbol = symbol; this.buysell = buysell; this.quantity = quantity; this.orderTime = orderTime;
        }         
    }

    public class Trader
    {
        public Position myPosition;
        public List<Trade> trades;

        public Trader()
        {
            //initialize  myPosition and trades by reading in values from csv files

            myPosition = new Position();
            trades = new List<Trade>();

            using (StreamReader sr2 = new StreamReader(@"c:/maple/Positions.csv"))
            {
                try
                {
                    sr2.ReadLine(); //moves internal pointer to next since 1st line are column names
                    while (!sr2.EndOfStream)
                    {
                        string[] temp2 = sr2.ReadLine().Split(new char[] { ',' });  //split by comma
                        myPosition.pos.Add(temp2[0], Convert.ToInt16(temp2[1])); //converting quantity to int for value
                    }
                }
                catch (IndexOutOfRangeException e) {  }
            }

            using (StreamReader sr = new StreamReader(@"c:/maple/Trades.csv"))
            {
                try
                {
                    sr.ReadLine(); //moves internal pointer to next since 1st line are column names
                    while (!sr.EndOfStream)
                    {
                        string[] temp = sr.ReadLine().Split(new char[]{','});
                        Trade t = new Trade(temp[0], temp[1], Convert.ToInt16(temp[2]), temp[3]);
                        trades.Add(t);
                    }
                }
                catch (IndexOutOfRangeException e) {  }
            }
        }

        public void performTrades() { myPosition.updatePosition(trades); }
        public void generateReport() { myPosition.generateReport(); }
    }

    public class maple
    {
        public maple()
        {
            Trader alan = new Trader();
            alan.generateReport();  //initial position
            alan.performTrades();   //upload traders trades
            alan.generateReport();  //End of day position            
            
            //Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
