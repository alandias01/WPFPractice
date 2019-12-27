using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WPFPractice.Unsorted
{    
    public class tcp
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
            //this works multiple times being opened and closed
            //May have something to do with while(true)

            using (TcpClient client = new TcpClient("localhost", 51111))
            using (NetworkStream n = client.GetStream())
            {
                BinaryWriter w = new BinaryWriter(n);
                string input;
                input = Console.ReadLine();
                w.Write(input);w.Flush();
                Console.WriteLine(new BinaryReader(n).ReadString());
            }        
        }

        static void Server() // Handles a single client request, then exits.
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 51111);

            listener.Start();
            while (true)
            {
                using (TcpClient c = listener.AcceptTcpClient())
                using (NetworkStream n = c.GetStream())
                {
                    string msg = new BinaryReader(n).ReadString();
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(msg + " right back!");
                    w.Flush(); // Must call Flush because we're not disposing the writer.
                } 
            }
            //listener.Stop();
        }

        static void Server2() // Handles a single client request, then exits.
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 51111);

            listener.Start();
            while (true)
            {
                using (TcpClient c = listener.AcceptTcpClient())
                using (NetworkStream n = c.GetStream())
                {
                    string msg = new BinaryReader(n).ReadString();
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(msg + " right back!");
                    w.Flush(); // Must call Flush because we're not disposing the writer.
                }
            }
            //listener.Stop();
        }

        public tcp()
        {
            //new Thread(Server).Start(); // Run server method concurrently.
            //Thread.Sleep(500); // Give server time to start.
            Client1();
        }
    }
}