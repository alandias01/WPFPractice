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

            new DataProcessService();

            Console.ReadLine();
            
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }

    public class DataProcessService
    {
        public DataProcessService()
        {            
            ProcessData(new FileDataDownload(), new AutoMarkReadProcessing());  //2 files
            ProcessData(new FileDataDownload(), new ManualMarkReadProcessing()); //3 files
        }

        public void ProcessData(IDataDownload IDD, IReadProcessing IRP)
        {            
            String Data = IDD.GetData();
            List<string> SplitData = IRP.SplitTheData(Data);
            List<IDataObject> ADO = IRP.CreateDataObject(SplitData);
            
            /*
            List<string> RawData = IDD.GetDataList();
            List<List<string>> d = IRP.SplitTheData(RawData);
            List<List<IDataObject>> ADO = IRP.CreateDataObjects(d);
            */
        }

    }

    public interface IDataDownload
    {
        /// <summary>
        /// This is when you have say 1 file and you want to put all the text in a string
        /// </summary>
        /// <returns></returns>
        string GetData();

        /// <summary>
        /// Either you have one file where the data is already split into multiple lines or you have many 
        /// files and you want to put the contents of each file into its own string
        /// </summary>
        /// <returns></returns>        
        List<string> GetDataList();

        /// <summary>
        /// When you have multiple files and each file is already broken into its own lines, you can put it in here
        /// </summary>
        /// <returns></returns>
        List<List<string>> GetDataListOfList(); 

    }

    public class FileDataDownload : IDataDownload
    {
        public string GetData()
        {
            FileInfo Fi = new FileInfo(@"D:\cmo.txt");

            try
            {                
                string data = File.ReadAllText(Fi.FullName);
                MoveFile(Fi, "CMO", true);
                return data;
            }
            catch (Exception)
            {
                MoveFile(Fi, "CMO", false);
                throw;
            }
        }

        public List<string> GetDataList()
        {

            try
            {
                List<string> data = new List<string>();
                DirectoryInfo Di = new DirectoryInfo(@"d:\");
                FileInfo[] FI = Di.GetFiles("*.txt");
                foreach (FileInfo file in FI)
                {
                    data.Add(File.ReadAllText(file.FullName));
                }

                return data;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public List<List<string>> GetDataListOfList()
        {
            try
            {
                List<List<string>> data = new List<List<string>>();
                DirectoryInfo Di = new DirectoryInfo(@"d:\trades");
                FileInfo[] FI = Di.GetFiles("*.txt");
                foreach (FileInfo file in FI)
                {
                    data.Add(File.ReadAllLines(file.FullName).ToList());
                }

                return data;
            }
            catch (Exception)
            {                                
                throw;
            }
        }

        /// <summary>
        /// Pass in the FileInfo File, an appropriate folder to add it to, and if your process for reading
        /// the file was successful.  If successful, goes in Done folder, else Error folder
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="FolderName"></param>
        /// <param name="isSuccessful"></param>
        private void MoveFile(FileInfo fi, string FolderName, bool isSuccessful)
        {
            try
            {
                if (string.IsNullOrEmpty(FolderName))
                {
                    FolderName = "RANDOM";

                    //An implementation to extract a FolderName from the filename
                    string[] SplitFileName = fi.Name.Split(new char[] { '.' });
                    string FolderNameFromFileName = SplitFileName[2];

                    string msg = "The File: " + fi.FullName + " did not have a FolderName\n";
                    msg += "Its Folder Name is " + FolderNameFromFileName;
                    //Util.SendEmail("aland@mapleusa.com", "CorporationProcessor ALERT", msg, false);
                }


                string BookDir = fi.DirectoryName + @"\" + FolderName;
                if (!Directory.Exists(BookDir))
                {
                    Directory.CreateDirectory(BookDir);
                }

                string BookDir_Date = BookDir + @"\" + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(BookDir_Date))
                {
                    Directory.CreateDirectory(BookDir_Date);
                }

                string BookDir_Date_Done = BookDir_Date + @"\Done";
                string BookDir_Date_Error = BookDir_Date + @"\Error";

                if (isSuccessful)
                {
                    if (!Directory.Exists(BookDir_Date_Done))
                    {
                        Directory.CreateDirectory(BookDir_Date_Done);
                    }

                    Directory.Move(fi.FullName, BookDir_Date_Done + @"\" + fi.Name);
                }

                else
                {
                    if (!Directory.Exists(BookDir_Date_Error))
                    {
                        Directory.CreateDirectory(BookDir_Date_Error);
                    }

                    Directory.Move(fi.FullName, BookDir_Date_Error + @"\" + fi.Name);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("void MoveFile(): " + ex.Message);
            }


        }
    }

    public class WebServiceDataDownload : IDataDownload
    {

        public string GetData()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDataList()
        {
            throw new NotImplementedException();
        }

        public List<List<string>> GetDataListOfList()
        {
            throw new NotImplementedException();
        }
    }

    public interface IReadProcessing
    {
        /// <summary>
        /// Takes the data and splits it into an array
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        List<string> SplitTheData(string Data);

        /// <summary>
        /// Each string item in the List gets split into its own List and put each of those Lists go into the Main List
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        List<List<string>> SplitTheData(List<string> Data);

        List<IDataObject> CreateDataObject(List<string> SplitData);
                
        List<List<IDataObject>> CreateDataObjects(List<List<string>> SplitData);


    }

    public class AutoMarkReadProcessing : IReadProcessing
    {
        public List<string> SplitTheData(string Data)
        {            
            List<string> tmp = new List<string>();

            for (int i = 0; i < Data.Length; i += 80)
            {
                tmp.Add(Data.Substring(i, 80));
            }
            return tmp;
        }

        public List<List<string>> SplitTheData(List<string> DataList)
        {
            List<List<string>> tmp = new List<List<string>>();

            foreach (string dataItem in DataList)
            {
                List<string> StringList = new List<string>();
                for (int i = 0; i < dataItem.Length; i += 80)
                {
                    StringList.Add(dataItem.Substring(i, 80));
                }
                tmp.Add(StringList);
            }

            return tmp;
        }

        public List<IDataObject> CreateDataObject(List<string> SplitData)
        {
            List<IDataObject> AMDOList = new List<IDataObject>();
            foreach (string item in SplitData)
            {
                AutoMarkDataObject AMDO = new AutoMarkDataObject();
                AMDO.RecordType = item.Substring(0, 1);
                AMDO.ReceivingParticipant = item.Substring(1, 4);
                AMDO.AccountNumber = item.Substring(5, 4);
                AMDO.BorrowLoanIndicator = item.Substring(9, 1);
                AMDO.CUSIPNumber = item.Substring(10, 9);
                AMDO.DeliveryDate = item.Substring(19, 6);
                AMDOList.Add(AMDO);
            }

            return AMDOList;
        }

        public List<List<IDataObject>> CreateDataObjects(List<List<string>> SplitData)
        {
            List<List<IDataObject>> AMDOListOfList = new List<List<IDataObject>>();
            
            foreach (List<string> SplitDataItem in SplitData)
            {
                List<IDataObject> AMDOList = new List<IDataObject>();
                foreach (string item in SplitDataItem)
                {
                    AutoMarkDataObject AMDO = new AutoMarkDataObject();
                    AMDO.RecordType = item.Substring(0, 1);
                    AMDO.ReceivingParticipant = item.Substring(1, 4);
                    AMDO.AccountNumber = item.Substring(5, 4);
                    AMDO.BorrowLoanIndicator = item.Substring(9, 1);
                    AMDO.CUSIPNumber = item.Substring(10, 9);
                    AMDO.DeliveryDate = item.Substring(19, 6);
                    AMDOList.Add(AMDO);
                }
                AMDOListOfList.Add(AMDOList);
            }
            return AMDOListOfList;
        }
    }

    public class ManualMarkReadProcessing : IReadProcessing
    {

        public List<string> SplitTheData(string Data)
        {
            throw new NotImplementedException();
        }

        public List<List<string>> SplitTheData(List<string> Data)
        {
            throw new NotImplementedException();
        }

        public List<IDataObject> CreateDataObject(List<string> SplitData)
        {
            throw new NotImplementedException();
        }

        public List<List<IDataObject>> CreateDataObjects(List<List<string>> SplitData)
        {
            throw new NotImplementedException();
        }
    }

    public class CSVReadProcessing : IReadProcessing
    {

        public List<string> SplitTheData(string Data)
        {
            return Data.Split(",".ToCharArray()).ToList();
        }

        public List<List<string>> SplitTheData(List<string> Data)
        {
            throw new NotImplementedException();
        }

        public List<IDataObject> CreateDataObject(List<string> SplitData)
        {
            throw new NotImplementedException();
        }


        public List<List<IDataObject>> CreateDataObjects(List<List<string>> SplitData)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDataObject { }

    public class AutoMarkDataObject : IDataObject
    {
        public AutoMarkDataObject() { }
        
        public string Header { get; set; }
        public string RecordType { get; set; }
        public string ReceivingParticipant { get; set; }
        public string AccountNumber { get; set; }
        public string BorrowLoanIndicator { get; set; }
        public string CUSIPNumber { get; set; }
        public string DeliveryDate { get; set; }
    }

    public class WebServiceDataObject : IDataObject
    {        
    }


}




