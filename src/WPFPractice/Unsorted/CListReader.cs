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
    class Program
    {
        delegate void d();
        static void Main(string[] args)
        {

            CListReader clr = new CListReader();

            Thread T = new Thread(() => 
            { 
                clr.AddToFormattedData("led");
                clr.RemoveheaderFromFormatted();
            });

            T.Start();
            
            //Console.ReadLine();

            clr.DownloadDone += () => clr.CreateFileFromFormattedData();
            
        }

      

    }

    public delegate void DownloadDoneDelegate();
    
    public class CListReader
    {
        public event DownloadDoneDelegate DownloadDone;

        StringBuilder RawString=new StringBuilder();
        string[] RawData;        
        List<string> FormattedData = new List<string>();
        StringBuilder FormattedString = new StringBuilder();
        string URLElec = @"http://newyork.craigslist.org/search/ele";

        public void onDownloadDone()
        {
            DownloadDoneDelegate downloaddone = DownloadDone;
            if (downloaddone != null)
            {
                DownloadDone();
            }
        }

        public CListReader()
        {
            //AddToFormattedData("led");
            //RemoveheaderFromFormatted();
            //CreateFileFromFormattedData();
        }


        public void AddToFormattedData(string search)
        {
            WebClient WC= new WebClient();
            WC.QueryString.Add("query", search);
            WC.QueryString.Add("srchType", "A");
            WC.QueryString.Add("minAsk", "");
            WC.QueryString.Add("maxAsk", "");

            using (StreamReader sr = new StreamReader(WC.OpenRead(URLElec)))
            {
                RawString.Append(Strip(sr.ReadToEnd()));
            }

            RawData = RawString.ToString().Split('\n');

            foreach (string RD in RawData)
            {
                FormattedData.Add(RD.TrimStart());
            }
 
        }

        public void RemoveheaderFromFormatted()
        {
            /*iterate array and find when beginning starts with a date and get its index
             * remove range from beginning to index-1             * 
             */

            DateTime DT;
            bool Breakout = false;
            int EndIndex=0;
            for (int i = 0; i < FormattedData.Count; i++)
            {

                if (FormattedData[i].Length>=6)
                {
                    if (DateTime.TryParse(FormattedData[i].Substring(0,6),out DT)) 
                    {
                        Breakout=true;
                        EndIndex = i - 1;
 
                    }
                    if (Breakout) { break; }
                }
            }

            FormattedData.RemoveRange(0, EndIndex);
            onDownloadDone();
        }

        public void CreateFileFromFormattedData()
        {
            foreach (string S in FormattedData) { FormattedString.AppendLine(S); }

            using (StreamWriter sw = new StreamWriter(@"e:\clist.txt"))
            {
                sw.WriteLine(FormattedString);
            }
            
 
        }

        private string Strip(string text)
        {
            return Regex.Replace(text, @"(<(.|\n)*?>|&nbsp;)", string.Empty);
        }

    }


}


