using System;
using System.IO;

namespace WPFPractice.Unsorted
{
    public class ReadTradeFile
    {
        FileInfo[] TradeFiles;
        string[] FileData;
        string Header;

        public ReadTradeFile()
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

    //public class Trade
    //{
    //    public string DateOfFile { get; set; }
    //    public string OriginalRecord { get; set; }
    //    public string clearingnumber { get; set; }
    //    public string Ctpy { get; set; }
    //    public string BL { get; set; }
    //    public string CUSIP { get; set; }
    //    public string TRADEDATE { get; set; }
    //    public string QUANTITY { get; set; }
    //    public string LOANVALUE { get; set; }
    //    public string RATE { get; set; }
    //    public string RATECODE { get; set; }
    //}
}