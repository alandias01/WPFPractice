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
using System.Reflection;
using System.Drawing;
using System.Drawing.Printing;


namespace ConsoleApplication1
{
    public class Program
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

            ReverseFormatter r = new ReverseFormatter();
            Book b = new Book(r);
            Paper p = new Paper(r);

            b.Title = "Alans Book";
            p.PaperName = "Alans Paper";

            List<ManuScript> MList = new List<ManuScript>();
            MList.Add(b);
            MList.Add(p);

            foreach (var item in MList)
            {
                item.Print();
            }
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }

    public interface IFormatter { string Format(string key, string value); }

    public class ReverseFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return key + " " + new string(value.Reverse().ToArray());
        }
    }

    public abstract class ManuScript
    {
        protected IFormatter Formatter;
        public ManuScript(IFormatter formatter)
        {
            Formatter = formatter;
        }

        public abstract void Print();        
    }

    public class Book : ManuScript
    {
        public Book(IFormatter formatter) : base(formatter) { }
        
        public string Title { get; set; }
        public string Author { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Title", Title));
        }
    }

    public class Paper : ManuScript
    {
        public Paper(IFormatter formatter) : base(formatter) { }
        
        public string PaperName { get; set; }
        public string Author { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Name", PaperName));
        }
    }

}




