using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WPFPractice.Unsorted
{
    public class file_dir_performance_watcher
    {
        public file_dir_performance_watcher()
        {
            //ShowDrives();
            //ShowDirectories();
            //ShowFiles();
            //FileWatcher();
            //PerformanceWatcher1();
            //ShowPaths();
            ExtensionRemove();
            //S01();
        }

        static void ShowDrives()
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.IsReady)
                    Console.WriteLine(di.Name + " Space:" + di.AvailableFreeSpace + "  type:" + di.DriveType + " format:" + di.DriveFormat + " total free space:" + di.TotalFreeSpace + " Total size:" + di.TotalSize + " Volume label:" + di.VolumeLabel);
            }

            Console.WriteLine("done");
        }

        static void ShowDirectories()
        {
            DirectoryInfo dir=new DirectoryInfo(@"C:\");
            
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                Console.WriteLine(d.FullName);
            }
        }

        static void ShowFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\");
            foreach (FileInfo fi in dir.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }

        }

        static void ShowPaths()
        {
            string TestFile = @"e:\HStockData.csv";
            Console.WriteLine(Path.GetDirectoryName(TestFile)); //e:\
            Console.WriteLine(Path.GetExtension(TestFile));     //.csv
            Console.WriteLine(Path.GetFileName(TestFile));      //HStockData.csv
            Console.WriteLine(Path.GetFullPath(TestFile));      //e:\HStockData.csv
            
            Console.WriteLine(Environment.CurrentDirectory);
            // H:\Users\Alan\Documents\Visual Studio 2010\Projects\Console_practice\Console_practice\bin\Debug
            
        }

        static void ExtensionRemove()
        {
            DirectoryInfo Di = new DirectoryInfo(@"E:\testdir");
            FileInfo[] FIList = Di.GetFiles();
                        

            foreach(FileInfo fi in Di.GetFiles()) 
            {
                string ext = Path.GetExtension(fi.Name);


                if (Regex.IsMatch(ext, @"\.(wmv|avi|asf|flv|mov|mkv|mp4|mpg|mpeg)$", RegexOptions.IgnoreCase))
                {
                    //Console.WriteLine(ext);
                    string NewFileName = Path.ChangeExtension(fi.FullName, null);
                    File.Move(fi.FullName, NewFileName);
                }
                //      

                //Console.WriteLine(ext);
            }

        }

        static void ExtensionAdd()
        {
            DirectoryInfo Di = new DirectoryInfo(@"E:\testdir");
            FileInfo[] FIList = Di.GetFiles();


            foreach (FileInfo fi in Di.GetFiles())
            {
                string ext = Path.GetExtension(fi.Name);


                if (Regex.IsMatch(ext, @"\.(wmv|avi|asf|flv|mov|mp4|mpg|mpeg|pl|exe|dll|ini|txt|jpg|gif)$", RegexOptions.IgnoreCase))
                {
                    //Console.WriteLine(ext);
                    string NewFileName = Path.ChangeExtension(fi.FullName, null);
                    File.Move(fi.FullName, NewFileName);
                }
                //      

                //Console.WriteLine(ext);
            }

        }

        static void regex01()
        {
            Regex r = new Regex(@"l",RegexOptions.IgnoreCase);
            var M = r.Matches("Helloa");
            Console.WriteLine(M.Count); 
        }

        static void FileWatcher()
        {
            FileSystemWatcher fsw = new FileSystemWatcher(@"C:\maple");

            //fsw.Created += (s, e) => { Console.WriteLine(e.ChangeType + " | " + e.FullPath + " | " + e.Name); };
            
            //fsw.Changed += (s, e) => { Console.WriteLine(e.ChangeType+ " | " +e.FullPath+ " | " +e.Name); };

            fsw.Renamed += (s, e) => { Console.WriteLine(e.ChangeType + " | " + e.FullPath + " | " + e.Name + " | " + e.OldFullPath + " | " + e.OldName); };

            fsw.EnableRaisingEvents = true;
        }

        static void PerformanceWatcher1()
        {
            PerformanceCounter pw = new PerformanceCounter();
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes"); 
            pw.CategoryName="Processor";
            pw.CounterName = "% Processor Time";
            pw.InstanceName = "_Total";
            Console.WriteLine(pw.NextValue());
            Console.WriteLine(ramCounter.NextValue());
        }

        static void S01()
        {
            string Num1 = "0000269";
            string Num2 = "523900";
            string Num3 = "516";

            Console.WriteLine(Num1.Trim(new char[] { '0' }));  //269
            Console.WriteLine(Num3.Substring(1, 1));    //1
            Console.WriteLine(Num3.PadLeft(5, '0'));  //doesn't add 5 0's but adds so that length=5 = 00516
            Console.WriteLine( Num3.Contains("16").ToString() ); //True
            Console.WriteLine(Num2.IndexOf('3'));   //2
            Console.WriteLine(Num1.Replace('0', '1')); //1111269
            Console.WriteLine(Num1.Split('2')[0]+" "+Num1.Split('2')[1]); //splits 0000269 to 0000 and 69            
        }
    }
}