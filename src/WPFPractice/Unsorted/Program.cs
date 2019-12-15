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
using ConsoleApplication1.Threading;

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
            #endregion

            new ConsoleApplication1.Threading.ConcurrentTutorial.ConcurrentT01();
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }
        }
    }
}




