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
            //cd "Documents and Settings\alan\My Documents\Visual Studio 2010\Projects\Console_practice\Console_practice\bin\Debug"
            #endregion

            new test().test1();


            Console.ReadLine();
            
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }

    class test
    {

        public void test1()
        {
            var ADPList = new List<ADPData> { new ADPData("1", 2), new ADPData("1", 3), new ADPData("1", 4), new ADPData("2", 3), new ADPData("2", 4), new ADPData("3", 5), new ADPData("3", 6) };

            var DTCList = new List<ADPData> { new ADPData("1", 5), new ADPData("1", 4), new ADPData("2", 3), new ADPData("2", 3), new ADPData("2", 1), new ADPData("3", 11) };


            var GrpADPList = ADPList.GroupBy(x => x.Ctpy);
            var GrpDTCList = DTCList.GroupBy(x => x.Ctpy);

            foreach (var GrpADP in GrpADPList)
            {
                foreach (var GrpDTC in GrpDTCList)
                {
                    if (GrpADP.Key == GrpDTC.Key)
                    {
                        if (GrpADP.Sum(x => x.Amt) == GrpDTC.Sum(x => x.Amt))
                        {
                            foreach (var ADP in GrpADP)
                            {
                                ADP.MatchAmt = GrpADP.Sum(x => x.Amt);
                            }

                            foreach (var DTC in GrpDTC)
                            {
                                DTC.MatchAmt = GrpDTC.Sum(x => x.Amt);
                            }

                        }

                        //Console.WriteLine(GrpADP.Key);
                        //Console.WriteLine("--" + GrpADP.Sum(x => x.Amt));
                        //Console.WriteLine("--" + GrpDTC.Sum(x => x.Amt)); 
                    }
                }
            }

            foreach (var G in ADPList)
            {
                Console.WriteLine(G.Ctpy + " " + G.Amt + " " + G.MatchAmt);
            }

            /*
            foreach (var A in GrpADPList)
            {
                Console.WriteLine(A.Key);
                Console.WriteLine(A.Sum(x => x.Amt));                
            }
            */           

        }


  



    }

    class ADPData
    {
        public string Ctpy { get; set; }
        public int Amt { get; set; }
        public int MatchAmt { get; set; }

        public ADPData(string C, int A) { this.Ctpy = C; this.Amt = A; }

    }




}


