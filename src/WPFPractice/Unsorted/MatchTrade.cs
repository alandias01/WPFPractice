using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



/* DB of searchable instruments.  Guitar, Mandolin
 * 
 * SN, price
 * Material
 * Paint
 * 
 * 
 * 
 */



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            PositionObject P1 = new PositionObject() { BGNREF = "10031", Ticker = "IBM", Rate = 1, QTY = 1000, BL = 'B', Price = 50, LNVAL = 50000 };
            PositionObject P2 = new PositionObject() { BGNREF = "10032", Ticker = "JPM", Rate = 1.1, QTY = 1000, BL = 'L', Price = 50, LNVAL = 50000 };

            PositionObject P3 = new PositionObject() { BGNREF = "10033", Ticker = "BAC", Rate = 1, QTY = 1000, BL = 'B', Price = 50, LNVAL = 50000 };
            PositionObject P4 = new PositionObject() { BGNREF = "10034", Ticker = "MS", Rate = 1.1, QTY = 1000, BL = 'L', Price = 50, LNVAL = 50000 };

            PositionObject P5 = new PositionObject() { BGNREF = "10035", Ticker = "GME", Rate = 1, QTY = 1000, BL = 'B', Price = 50, LNVAL = 50000 };
            PositionObject P6 = new PositionObject() { BGNREF = "10036", Ticker = "DYN", Rate = 1.1, QTY = 1000, BL = 'L', Price = 50, LNVAL = 50000 };


            MatchObject MO1 = new MatchObject();
            MO1.Borrows.Add(P1);
            MO1.Loans.Add(P2);

            MatchObject MO2 = new MatchObject();
            MO2.Borrows.Add(P3);
            MO2.Loans.Add(P4);

            MatchObject MO3 = new MatchObject();
            MO3.Borrows.Add(P5);
            MO3.Loans.Add(P6);

            MatchCollection MC = new MatchCollection();
            MC.Add(MO1);
            MC.Add(MO2);
            MC.Add(MO3);

            foreach (MatchObject mt in MC)
            {
                foreach (PositionObject p in mt.Borrows)
                { Console.WriteLine(p.BGNREF + " " + p.QTY + " " + p.Price + " " + p.BL); }

                foreach (PositionObject p in mt.Loans)
                { Console.WriteLine(p.BGNREF + " " + p.QTY + " " + p.Price + " " + p.BL); }
            }

            Console.ReadLine();

        }
    }


    class PositionCollection : List<PositionObject>
    { }

    class PositionObject
    {
        public string BGNREF { get; set; }
        public string Ticker { get; set; }
        public double Rate { get; set; }
        public int QTY { get; set; }
        public double Price { get; set; }
        public double LNVAL { get; set; }
        public char BL { get; set; }
    }

    class MatchCollection : List<MatchObject>
    { }



    class MatchObject
    {
        public PositionCollection Borrows = new PositionCollection();
        public PositionCollection Loans = new PositionCollection();
    }











}

