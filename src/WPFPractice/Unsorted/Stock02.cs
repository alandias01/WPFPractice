using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Data;
using System.Data.OleDb;

namespace WPFPractice.Unsorteds
{
    public class Stock02
    {
        public Stock02()
        {
            HStockDataDA HSDA = new HStockDataDA();
            HStockDataFac HSDF = new HStockDataFac(HSDA);
            HSDA.DownloadDone += (e) => { Console.WriteLine(e.FileName+"\n"+e.Link); };
            List<HStockDataObject> HstockData = new List<HStockDataObject>();
            HSDF.LoadAll(HstockData);
        }
    }

    public class HStockDataFac
    {
        public HStockDataDA HSDA;
        public HStockDataFac(HStockDataDA HSDA) { this.HSDA = HSDA; }
        
        public void LoadAll(ICollection<HStockDataObject> HStockData) { HSDA.LoadAll(HStockData); }        
    }
    
    public class DownLoadEventArgs : EventArgs
    {
        public DownLoadEventArgs(string L, string F) { this.Link = L; this.FileName = F; }
        public string Link;
        public string FileName;
    }

    public delegate void DownloadDoneDelegate(DownLoadEventArgs e);

    public class HStockDataDA
    {
        string YahooFile= @"e:\HStockData.csv";
        public event DownloadDoneDelegate DownloadDone;
        
        private void onDownLoadDone(DownLoadEventArgs e)
        {
            DownloadDoneDelegate downloadDone = DownloadDone;
            if (downloadDone != null) 
            { 
                downloadDone(e); 
            }
        }

        private void GetFile()
        {
            string YahooLink = @"http://ichart.finance.yahoo.com/table.csv";
            string Symbol;
            DateTime StartDate;
            DateTime EndDate;
            string Frequency;

            Symbol="YHOO";
            StartDate=new DateTime(2011,11,01).AddMonths(-1); //Yahoo months are off by 1
            EndDate=DateTime.Now.AddMonths(-1);
            Frequency = "d";

            WebClient YahooCSVFile= new WebClient();
            YahooCSVFile.QueryString.Add("s",Symbol);
            YahooCSVFile.QueryString.Add("a",StartDate.Month.ToString());
            YahooCSVFile.QueryString.Add("b","01");
            YahooCSVFile.QueryString.Add("c",StartDate.Year.ToString());
            YahooCSVFile.QueryString.Add("d",EndDate.Month.ToString());
            YahooCSVFile.QueryString.Add("e",EndDate.Day.ToString());
            YahooCSVFile.QueryString.Add("f",EndDate.Year.ToString());
            YahooCSVFile.QueryString.Add("g",Frequency);
            YahooCSVFile.QueryString.Add("ignore",@".csv");
            
           
            try
            {
                YahooCSVFile.DownloadFile(YahooLink, YahooFile); 
                onDownLoadDone(new DownLoadEventArgs(YahooLink,YahooFile));
            }
            catch (WebException ex) { Console.WriteLine(ex.Message); Environment.Exit(1); }
            YahooCSVFile.Dispose();
        }

        public void LoadAll(ICollection<HStockDataObject> HSDA)
        {
            GetFile();

            if (!File.Exists(YahooFile))
            {
                Console.WriteLine("Could not find file: " + YahooFile);
            }

            string FullPath = Path.GetFullPath(YahooFile);
            string CurrentFile = Path.GetFileName(FullPath);
            string DirPath = Path.GetDirectoryName(FullPath);
            
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;"
                   + "Data Source=\"" + DirPath + "\\\";"
                   + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\"";

            string query = "SELECT * FROM " + CurrentFile;
            DataTable DT = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(query, connectionString);
            try 
            {
                DA.Fill(DT);
            }
            catch(InvalidOperationException){}
                        
            foreach (DataRow Row in DT.Rows)
            {
                HSDA.Add(new HStockDataObject(Row));
            }

            DA.Dispose();
            

        }

    }

    public class HStockDataObject
    {
        #region Variables
        DateTime _date;
        double _open;
        double _high;
        double _low;
        double _close;
        int _volume;
        double _adj_Close;
        #endregion

        #region Properties
        public DateTime Date { get { return _date; } set { _date = value; } }
        public double Open { get { return _open; } set { _open = value; } }
        public double High { get { return _high; } set { _high = value; } }
        public double Low { get { return _low; } set { _low = value; } }
        public double Close { get { return _close; } set { _close = value; } }
        public int Volume { get { return _volume; } set { _volume = value; } }
        public double Adj_Close { get { return _adj_Close; } set { _adj_Close = value; } }
        #endregion

        #region Methods
        public HStockDataObject(DateTime Date, double Open, double High, double Low, double Close, int Volume, double Adj_Volume)
        {
            this.Date = Date;
            this.Open = Open;
            this.High = High;
            this.Low = Low;
            this.Close = Close;
            this.Volume = Volume;
            this.Adj_Close = Adj_Close;
        }

        public HStockDataObject(DataRow Row)
        {
            this.Date = (DateTime)Row["Date"];
            this.Open = (double)Row["Open"];
            this.High = (double)Row["High"];
            this.Low = (double)Row["Low"];
            this.Close = (double)Row["Close"];
            this.Volume = (int)Row["Volume"];
            this.Adj_Close = (double)Row["Adj Close"];
        }
        #endregion
    }
}