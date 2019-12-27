using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml.Linq;

namespace WPFPractice.Unsorted
{   
    public class linqtoxml
    {
        public linqtoxml()
        {
            XDocument X = new XDocument(
                new XElement("Cars",
                    new XElement("Ford",
                        new XElement("Owner", "Alan"),
                        new XElement("Owner", "Sybil"))));

            Console.WriteLine(X);
        }

        static void Quote(string sym)
        {
            string url = @"http://www.google.com/ig/api?stock=" + sym;
            XDocument Doc = XDocument.Load(url);

            string Company = GetData(Doc, "company");
            string Exchange = GetData(Doc, "exchange");
            Double Last = Convert.ToDouble(GetData(Doc, "last"));
            Double High = Convert.ToDouble(GetData(Doc, "high"));
            Double Low = Convert.ToDouble(GetData(Doc, "low"));
            Console.WriteLine(Doc);
        }

        static void CreateXML()
        {
            List<TradeObj> TradeCollection = new List<TradeObj>();

            TradeObj tobj = new TradeObj("IBM", 1000);
            TradeCollection.Add(tobj);

            TradeObj tobj2 = new TradeObj("JPM", 2000);
            TradeCollection.Add(tobj2);

            XDocument Doc = new XDocument(
                new XElement("Trades",
                    from i in TradeCollection
                    select new XElement("Trade",
                        new XElement("Symbol", i.TradeName), new XElement("TradeId", i.TradeId))));
            Console.WriteLine(Doc);
        }

        static string GetData(XDocument doc, string name)
        {
            return doc.Root.Element("finance").Element(name).Attribute("data").Value;
        }
    }

    public class TradeObj
    {
        public TradeObj(string N, int ID) { TradeName = N; TradeId = ID; }
        public string TradeName { get; set; }
        public int TradeId { get; set; }
    }
}