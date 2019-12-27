using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WPFPractice.Unsorted
{
    public class mytcp
    {
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

        public mytcp()
        {
            Server();
            //Client2();
        }
    }
}
