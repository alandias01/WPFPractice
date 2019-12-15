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
using System.Data.Common;
using System.Data.OleDb;


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

            new ReadInTrades();

            Console.ReadLine();
            
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }



    /* Get File or stream data
     * Read data to string
     * split based on zone
     * add to object
     */

    public class ReadInTrades
    {
        public ReadInTrades()
        {
            ProcessTrade(new FileDataDownload(), new Z3ReadProcessing());                        
        }

        public void ProcessTrade(IDataDownload IDD, IReadProcessing IRP)
        {
            String Data = IDD.GetData();
            string[] SplitData = IRP.SplitTheData(Data);
            DataObject DO = IRP.CreateDataObject(SplitData);
            
        }
    }

    public interface IDataDownload
    {
        string GetData();
    }

    public class FileDataDownload : IDataDownload
    {
        public string GetData()
        {
            return "Alan,William,Sybil";
        }
    }

    public interface IReadProcessing
    {
        string[] SplitTheData(string Data);
        DataObject CreateDataObject(string[] SplitData);
    }

    public class Z3ReadProcessing : IReadProcessing
    {
        public string[] SplitTheData(string Data)
        {
            return Data.Split(",".ToCharArray());
        }

        public DataObject CreateDataObject(string[] SplitData)
        {
            return new Z3DataObject() { A = SplitData[0], B = SplitData[1], C = SplitData[2] };
        }
    }

    public class DataObject { }

    public class Z3DataObject : DataObject 
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }

    public class Z4DataObject : DataObject 
    {
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; } 
    }
}


