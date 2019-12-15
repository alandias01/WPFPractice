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
using System.ComponentModel;
using System.Xml.Linq;
using System.Diagnostics;
using System.Configuration;


namespace ConsoleApplication1
{
    //Create a person with an arm object that if normal, 5 fingers, retard has 6

    class Program
    {

        static void Main(string[] args)
        {
            #region Args
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
            #endregion

            new Processor().Run();
            
            Console.WriteLine("");
            
            Console.ReadLine();
            //cd "Documents and Settings\alan\My Documents\Visual Studio 2010\Projects\Console_practice\Console_practice\bin\Debug"
        }

    }

    class Processor
    {        
        InterCompanyTrade ICT = new InterCompanyTrade(DateTime.Today, "5239", "5289");

        public void Run()
        {
            LoadTrades();
            ICT.GetUncompared();
        }


        


        public void LoadTrades() 
        {   
            ICT.We.Add(new Position("192304101", "300", "123", "3000", "102"));
            ICT.We.Add(new Position("192304102", "400", "133", "4000", "101"));
            ICT.We.Add(new Position("192304103", "500", "143", "5000", "102"));
            ICT.We.Add(new Position("192304104", "600", "153", "6000", "102"));
            ICT.We.Add(new Position("192304105", "700", "163", "7000", "102"));
            ICT.We.Add(new Position("192304106", "850", "173", "8000", "101"));
            ICT.We.Add(new Position("192304107", "900", "183", "9000", "102"));

            ICT.They.Add(new Position("192304101", "300", "123", "3000", "102"));
            ICT.They.Add(new Position("192304102", "400", "133", "4000", "101"));
            ICT.They.Add(new Position("192304103", "500", "143", "5000", "102"));
            ICT.They.Add(new Position("192304104", "600", "153", "6000", "102"));
            ICT.They.Add(new Position("192304105", "700", "163", "7000", "102"));
            ICT.They.Add(new Position("192304106", "860", "173", "8000", "101"));
            ICT.They.Add(new Position("192304107", "900", "183", "9000", "102"));
            ICT.They.Add(new Position("192304107", "900", "183", "9000", "102"));

            
        }

 

    }

    class InterCompanyTrade
    {
        public PositionCollection We = new PositionCollection();
        public PositionCollection They = new PositionCollection();

        public PositionCollection WeUncompared = new PositionCollection();
        public PositionCollection TheyUncompared = new PositionCollection();

        public InterCompanyTrade(DateTime dt, string BU, string BT) 
        {
            We.DateOfData = dt;
            We.BookUs = BU;
            We.BookThem = BT;
            We.UncomparedAdvisory = "W";

            WeUncompared.DateOfData = dt;
            WeUncompared.BookUs = BU;
            WeUncompared.BookThem = BT;
            WeUncompared.UncomparedAdvisory = "W";
            
            They.DateOfData = dt;
            They.BookUs = BU;
            They.BookThem = BT;            
            They.UncomparedAdvisory = "T";

            TheyUncompared.DateOfData = dt;
            TheyUncompared.BookUs = BU;
            TheyUncompared.BookThem = BT;
            TheyUncompared.UncomparedAdvisory = "T";
        }

        

        public void GetUncompared()
        {
            WeUncompared.Clear();
            TheyUncompared.Clear();

            List<Position> WEU = We.Except(They, new PositionComparer()).ToList();
            WeUncompared.AddRange(WEU);

            List<Position> WET = They.Except(We, new PositionComparer()).ToList();
            TheyUncompared.AddRange(WET); 
        }

    }
    class PositionCollection : List<Position>
    {
        public DateTime DateOfData;
        public string BookUs { get; set; }
        public string BookThem { get; set; }
        public string UncomparedAdvisory { get; set; }

        public PositionCollection() { }
        //public PositionCollection(IEnumerable<Position> c) : base(c) { }
        
    }

    class Position
    {
        public Position(string C, string Q, string R, string L, string M)
        { Cusip = C; Qty = Q; Rate = R; LNVAL = L; Mark = M; }
        public string Cusip { get; set; }
        public string Qty { get; set; }
        public string Rate { get; set; }
        public string LNVAL { get; set; }
        public string Mark { get; set; }


        /*public bool Equals(Position other)
        {
            if (this.Cusip == other.Cusip && this.Qty == other.Qty && this.Rate == other.Rate && this.LNVAL == other.LNVAL && this.Mark == other.Mark)
            { return true; }
            else { return false; }
        }*/

    }

    class PositionComparer : IEqualityComparer<Position>
    {
        public bool Equals(Position x, Position y)
        {
            return (x.Cusip == y.Cusip && x.Qty == y.Qty && x.Rate == y.Rate && x.LNVAL == y.LNVAL && x.Mark == y.Mark);
        }

        public int GetHashCode(Position obj)
        {
            return obj.Cusip.GetHashCode() ^ obj.Qty.GetHashCode() ^ obj.Rate.GetHashCode() ^ obj.LNVAL.GetHashCode() ^ obj.Mark.GetHashCode();
        }
    }


   

}


