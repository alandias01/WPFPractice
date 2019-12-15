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
            #endregion

            Person p = new Person(new RetardedPersonFactory());
            
            Console.WriteLine(p.Arm.fingers);
            
            Console.ReadLine();
            //cd "Documents and Settings\alan\My Documents\Visual Studio 2010\Projects\Console_practice\Console_practice\bin\Debug"
        }

    }

    public interface IPersonFactory
    {
        IArm CreateArm();
    }

    public class NormalPersonFactory : IPersonFactory
    {

        public IArm CreateArm()
        {
            return new NormalArm();
        }
    }
    public class RetardedPersonFactory : IPersonFactory
    {

        public IArm CreateArm()
        {
            return new RetardArm();
        }
    }

    public interface IArm
    {
        int fingers { get; set; } 
    }

    public class NormalArm : IArm
    {
        public int fingers { get; set; }
        public NormalArm() { fingers = 5; }
    }

    public class RetardArm : IArm
    {
        public int fingers { get; set; }
        public RetardArm() { fingers = 6; }
    }

    public class Person
    {
        public IArm Arm;
        IPersonFactory IPF;
        public Person(IPersonFactory IPF) 
        { 
            this.IPF = IPF;
            Arm = IPF.CreateArm();
        }
    }

}


