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
using System.Globalization;


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

            new TradeProcessor().Run();
            
            Console.WriteLine("");
            
            //Console.ReadLine();
            //cd "Documents and Settings\alan\My Documents\Visual Studio 2010\Projects\Console_practice\Console_practice\bin\Debug"


        }

    }

    class TradeProcessor
    {
        FileInfo[] TradeFiles;
        string[] FileData;
        string Header;

        public void Run()
        {
            GetTradeFilesAndRead();
            ConvertToObject();
        }

        public void GetTradeFilesAndRead()
        {
            try
            {
                DirectoryInfo TradeDir = new DirectoryInfo(@"d:/trades1");
                TradeFiles = TradeDir.GetFiles();
            }
            catch (Exception e) 
            {
                //Message gets logged, remove throw
                throw;
            }
        }


        public void ConvertToObject()
        {
            foreach (FileInfo TradeFile in TradeFiles)
            {
                FileData = File.ReadAllLines(TradeFile.FullName);
                Header = FileData[0];

            }

            
            
        }





    }

    public class Trade
    {
        public string DateOfFile { get; set; }
        public string OriginalRecord { get; set; }
        public string clearingnumber { get; set; }
        public string Ctpy { get; set; }
        public string BL { get; set; }
        public string CUSIP { get; set; }
        public string TRADEDATE { get; set; }
        public string QUANTITY { get; set; }
        public string LOANVALUE { get; set; }
        public string RATE { get; set; }
        public string RATECODE { get; set; }
    }


   

}


