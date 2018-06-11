using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Data
{
    public interface IStockDa
    {
        ObservableCollection<IStockObject> Positions { get; set; }        
    }

    public class StockDa : IStockDa
    {
        public ObservableCollection<IStockObject> Positions { get; set; }
        
        private readonly Random rand = new Random();
        private const int TIMER_INTERVAL = 750;

        public StockDa(bool isLive)
        {
            this.Positions = new ObservableCollection<IStockObject>();
            this.Load(isLive);
        }   

        private void Load(bool isLive)
        {
            Positions.Add(new StockObject("International Business Machines Corporation", "912828C01", "IBM", 100, 120, 3));
            Positions.Add(new StockObject("JPMorgan Chase & Co.", "049512865", "JPM", 50, 120, 1));
            Positions.Add(new StockObject("Apple Inc.", "316514P02", "AAPL", 25, 120, 4));
            Positions.Add(new StockObject("Novartis AG", "825514966", "NVS", 80, 120, 2));
            Positions.Add(new StockObject("RF Micro Devices Inc.", "101234985", "RFMD", 100, 120, 3));
            Positions.Add(new StockObject("The Goldman Sachs Group, Inc.", "912589356", "GS", 50, 120, 1));
            Positions.Add(new StockObject("GameStop Corp.", "548965748", "GME", 25, 120, 4));

            Positions.Add(new StockObject("Dynegy Inc.", "321485968", "DYN", 80, 120, 2));
            Positions.Add(new StockObject("Exxon Mobil Corporation", "784652356", "XOM", 100, 120, 3));
            Positions.Add(new StockObject("BP plc", "912547896", "BP", 50, 120, 1));
            Positions.Add(new StockObject("SolarWinds, Inc.", "912458796", "SWI", 25, 120, 4));
            Positions.Add(new StockObject("Intel Corporation", "912478523", "INTC", 80, 120, 2));

            if (isLive)
            {
                UpdatePositions<IStockObject>(Positions);
            }
        }

        /// <summary>
        /// Use this for when you want to create n amount of symbols when random prices
        /// </summary>
        /// <param name="symbolsToCreate"></param>
        private void LoadGeneratedSymbols(int symbolsToCreate)
        {
            this.Positions.Clear();
            var r = new Random();
            this.GenerateSymbols(symbolsToCreate).ToList().ForEach(x => Positions.Add(new StockObject() { Symbol = x, Price = r.Next(999) }));
            UpdatePositions<IStockObject>(Positions);
        }

        private List<string> GenerateSymbols(int ct)
        {
            List<string> collection = new List<string>();
            List<string> Letters = new List<string>();
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList().ForEach(x => Letters.Add(x.ToString()));

            int charlen = Letters.Count();
            int ctr = 1;
            string s = "";
            for (int i = 0; i < charlen; i++)
            {
                if (ctr > ct)
                {
                    break;
                }
                s = Letters[i];

                for (int j = 0; j < charlen; j++)
                {
                    if (ctr > ct)
                    {
                        break;
                    }
                    string s2 = s;
                    s2 += Letters[j];

                    for (int k = 0; k < charlen; k++)
                    {
                        string s3 = s2;
                        s3 += Letters[k];
                        collection.Add(s3);
                        ctr++;
                        if (ctr > ct)
                        {
                            break;
                        }
                    }
                }

            }

            return collection;


        }

        private void UpdatePositions<T>(IList<T> collection) where T : IStockObject
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(TIMER_INTERVAL);
                    {
                        foreach (var item in collection)
                        {                            
                            item.Qty += rand.Next(-3, 3);
                            item.Price += rand.Next(-3, 3);
                            decimal d = Convert.ToDecimal(rand.NextDouble());
                            item.Rate += d - (1 / 2);
                        }
                    }
                }
            });
        }
    }
}
