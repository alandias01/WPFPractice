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
            //Server();
            //Client2();

            Console.ReadLine();

        }

        static void Client1()
        {
            string input;
            while (true)
            {
                using (TcpClient client = new TcpClient("localhost", 51111))
                using (NetworkStream n = client.GetStream())
                {
                    BinaryWriter w = new BinaryWriter(n);

                    BinaryReader br = new BinaryReader(n);
                    input = Console.ReadLine();
                    if (input != null || input != "qw")
                    {
                        w.Write(input); w.Flush();
                        string msg = new BinaryReader(n).ReadString();
                        //string msg = br.ReadString();
                        Console.WriteLine(msg);
                    }
                }

            }
        }

        static void Client2()
        {
            string input;

            while (true)
            {
                using (TcpClient client = new TcpClient("localhost", 51111))
                using (NetworkStream n = client.GetStream())
                {
                    BinaryWriter w = new BinaryWriter(n);

                    BinaryReader br = new BinaryReader(n);
                    input = Console.ReadLine();
                    if (input != null || input != "qw")
                    {
                        w.Write(input); w.Flush();
                        string msg = new BinaryReader(n).ReadString();
                        //string msg = br.ReadString();
                        Console.WriteLine(msg);
                    }
                }
            }


        }


        static void Server()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any, 51111);

                listener.Start();
                while (true)
                {
                    using (TcpClient c = listener.AcceptTcpClient())
                    using (NetworkStream n = c.GetStream())
                    {
                        string msg = new BinaryReader(n).ReadString();
                        BinaryWriter w = new BinaryWriter(n);
                        w.Write(msg + " right back!");
                        w.Flush();
                    }
                }
            }

            catch (SocketException e) { Console.WriteLine("SocketException: {0}", e); }
            finally { listener.Stop(); }
        }

        //Check readstring = null
        static void Server2()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any, 51111);

                listener.Start();
                while (true)
                {
                    using (TcpClient c = listener.AcceptTcpClient())
                    using (NetworkStream n = c.GetStream())
                    {
                        string msg = new BinaryReader(n).ReadString();
                        BinaryWriter w = new BinaryWriter(n);
                        w.Write(msg + " right back!");
                        w.Flush();
                    }
                }
            }

            catch (SocketException e) { Console.WriteLine("SocketException: {0}", e); }
            finally { listener.Stop(); }
        }
        

        public Socket GetSocket(string Server, int Port)
        {
            Socket S = null;
            Console.WriteLine(Dns.GetHostName()); //alanspc

            IPHostEntry hostentry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress address in hostentry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, 79);

                //The socket constructor initializes the type
                Socket TempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                //This makes the connection to the remote host.  ipe is just an address and port
                //Socket.connect has an overload which takes just ip and port
                TempSocket.Connect(ipe);

                if (TempSocket.Connected)
                {
                    S = TempSocket;
                    break;
                }
                else { continue; }

            }

            return S;
 

        }


    }

 
     

   


   


}


