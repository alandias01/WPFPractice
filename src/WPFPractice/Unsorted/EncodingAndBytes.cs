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
       


        static void Main(string[] args)
        {
            EncodeString();
            Console.ReadLine();
        }

        static void EncodeString()
        {
            using (FileStream fs = File.Create("myfile.txt"))
            {
                string msg = "hello me1";
                byte[] bytemsg = Encoding.Default.GetBytes(msg);

                foreach (byte b in bytemsg)
                {
                    Console.WriteLine(b);
                }

                try
                {

                    fs.Write(bytemsg, 0, bytemsg.Length);
                }
                catch (IOException ex)
                {
                    throw ex;
                }

            }
        }


        static void EncodeString2()
        {
            using (FileStream fs = File.Create("myfile.txt"))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write("Alan");                
            }

            using (FileStream fr = File.OpenRead("myfile.txt"))
            {
                string readmsg = new BinaryReader(fr).ReadString();
                Console.WriteLine(readmsg);
            }
            

        }
        


    }

 
     

   


   


}


