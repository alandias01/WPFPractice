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
            
            Console.ReadLine();

            AutoFactory fac = new AutoFactory();
            IAuto car = fac.CreateInstance("bmw");
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }

    public class AutoFactory
    {
        Dictionary<string, Type> autos;

        public AutoFactory()
        {
            LoadIAutoTypes();
        }


        public IAuto CreateInstance(string carName)
        {
            Type t = GetTypeToCreate(carName);
            if (t==null)
            {
                //return new NullAuto(); Null object pattern
                return null;
            }

            return Activator.CreateInstance(t) as IAuto;
        }

        private Type GetTypeToCreate(string carName)
        {
            foreach (var auto in autos)
            {
                if (auto.Key.Contains(carName))
                {
                    return autos[auto.Key];                    
                }
            }
            return null;
        }

        private void LoadIAutoTypes()
        {
            autos = new Dictionary<string, Type>();
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(IAuto).ToString()) != null)
                {
                    autos.Add(type.Name.ToLower(), type);
                }
            }
            
        }
    }

    public interface IAuto { }

    public class BMW : IAuto
    { }

    public class AUDI : IAuto
    { }



}




