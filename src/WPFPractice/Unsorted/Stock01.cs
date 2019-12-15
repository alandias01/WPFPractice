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


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            new StockApp();

            Console.ReadLine();
            
        }       

    }


    class StockApp
    {
        string Link = @"http://ichart.finance.yahoo.com/table.csv?s=YHOO&a=11&b=01&c=2011&d=11&e=14&f=2011&g=d&ignore=.csv";
        string TempFile = @"c:\temp.csv";
        List<string> HistoricalDataRaw = new List<string>();

        public StockApp() { 
            GetFile(); 
            ImportFile(); 
        }
        
        public void GetFile()
        {
            WebClient myfile = new WebClient();
            myfile.DownloadFile(Link, TempFile);
        }



        public void ReadData()
        {
            string Line;
            using (StreamReader sr = new StreamReader(TempFile))
            {
                while ((Line = sr.ReadLine()) != null)
                {
                    HistoricalDataRaw.Add(Line);
                }
            }

            Console.WriteLine(HistoricalDataRaw[1]);
        }

        public bool ImportFile()
        {

            //make sure the file exists
            if (!File.Exists(TempFile))
            {
                throw new Exception("Could not find file: " + TempFile);
            }

            //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + @";Extended Properties=""Excel 8.0;HDR=YES;""";

            string dir = @"c:\";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;"
                   + "Data Source=\"" + dir + "\\\";"
                   + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\"";

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = connection.CreateCommand())
                {
                    // Cities$ comes from the name of the worksheet
                    //command.CommandText = "SELECT open,high,low FROM [Sheet1$]";
                    command.CommandText = "SELECT open,high FROM "+TempFile;
                    connection.Open();

                    using (DbDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            try
                            {
                                string open;
                                string high;
                                //int low = 0;

                                open = dr["open"].ToString();
                                high = dr["high"].ToString();
                                
                                //int.TryParse(dr["Quantity"].ToString(), out quantity);

                                if (open != string.Empty)
                                {
                                    Console.WriteLine(open);
                                }

                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                        }
                    }
                    
                }
            }



            return true;
        }


    }

    class HistoricalPrice
    {
        #region Variables
        string _date;
        string _open;
        string _high;
        string _low; 
        string _close;
        string _volume;
        string _adjClose;
        #endregion

        #region Properties
        public string Date { get { return _date; } set { _date = value; } }
        public string open { get { return _open; } set { _open = value; } }
        public string high { get { return _high; } set { _high = value; } }
        public string low { get { return _low; } set { _low = value; } }
        public string close { get { return _close; } set { _close = value; } }
        public string volume { get { return _volume; } set { _volume = value; } }
        public string adjClose { get { return _adjClose; } set { _adjClose = value;} }
        #endregion

        #region Methods
        #endregion

    }




}


