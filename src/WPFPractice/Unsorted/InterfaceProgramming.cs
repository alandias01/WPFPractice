using System;
using System.Collections.Generic;

namespace WPFPractice.Unsorted
{
    /* Get File or stream data
     * Read data to string
     * split based on zone
     * add to object
     */

    public class ReadInTrades
    {
        public ReadInTrades()
        {
            ProcessTrade(new FileDataDownloader(), new Z3ReadProcessing());                        
        }

        public void ProcessTrade(IDataDownloader IDD, IReadProcessor IRP)
        {
            String Data = IDD.GetData();
            string[] SplitData = IRP.SplitTheData(Data);
            DataObject DO = IRP.CreateDataObject(SplitData);            
        }
    }

    public interface IDataDownloader
    {
        string GetData();
    }

    public class FileDataDownloader : IDataDownloader
    {
        public string GetData()
        {
            return "Alan,William,Sybil";
        }
    }

    public interface IReadProcessor
    {
        string[] SplitTheData(string Data);
        DataObject CreateDataObject(string[] SplitData);
    }

    public class Z3ReadProcessing : IReadProcessor
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