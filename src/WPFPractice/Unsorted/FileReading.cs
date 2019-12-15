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
using System.Data.OleDb;
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

            new FileReading();


            Console.ReadLine();
            
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }



    class FileReading
    {
        public FileReading()
        {
            ReadXLSFile(); 
        }

        public void ReadCSVFile()
        {
            string MyFile = @"C:\Users\Alan\Desktop\table.csv";
            string[] Raw = File.ReadAllLines(MyFile);
 
        }

        public bool ReadXLSFile()
        {
            string MyFile = @"C:\Users\Alan\Desktop\table.xls";

            //make sure the file exists
            if (!File.Exists(MyFile))
            {
                throw new Exception("Could not find file: " + MyFile);
            }


            string dir = @"C:\Users\Alan\Desktop\";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=table.xls;Extended Properties=Excel 8.0;"; //Readonly=False;FMT=Delimited

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = connection.CreateCommand())
                {
                    // Cities$ comes from the name of the worksheet
                    //command.CommandText = "SELECT open,high,low FROM [Sheet1$]";
                    command.CommandText = "SELECT [Open],[High] FROM [Sheet1$]";
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

                                open = dr["Open"].ToString();
                                high = dr["High"].ToString();

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

}


