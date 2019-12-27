using System;
using System.IO;
using System.Data.Common;

namespace WPFPractice.Unsorted
{
    public class FileReading
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