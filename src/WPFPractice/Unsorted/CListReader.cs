using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace WPFPractice.Unsorted
{
    public class CListReader
    {
        public delegate void DownloadDoneDelegate();
        public event DownloadDoneDelegate DownloadDone;

        StringBuilder RawString = new StringBuilder();
        string[] RawData;
        List<string> FormattedData = new List<string>();
        StringBuilder FormattedString = new StringBuilder();
        string URLElec = @"http://newyork.craigslist.org/search/ele";

        public CListReader()
        {
            Thread T = new Thread(() =>
            {
                this.AddToFormattedData("led");
                this.RemoveheaderFromFormatted();
            });

            T.Start();

            this.DownloadDone += () => this.CreateFileFromFormattedData();
        }

        public void onDownloadDone()
        {
            DownloadDoneDelegate downloaddone = DownloadDone;
            if (downloaddone != null)
            {
                this.DownloadDone();
            }
        }

        public void AddToFormattedData(string search)
        {
            WebClient WC = new WebClient();
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
            int EndIndex = 0;
            for (int i = 0; i < FormattedData.Count; i++)
            {

                if (FormattedData[i].Length >= 6)
                {
                    if (DateTime.TryParse(FormattedData[i].Substring(0, 6), out DT))
                    {
                        Breakout = true;
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