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
using Outlook = Microsoft.Office.Interop.Outlook;

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

            ExchangeServer.ReadOutlookNightCrawler();


            Console.ReadLine();
            
        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }



    class ExchangeServer
    {
        public static bool GetFile(string filename, DateTime date)
        {
            //Log.WriteLine("Create MAPI Session");
            try
            {
                MAPI.Session oSession = new MAPI.Session();
                
                //Log.WriteLine("Created MAPI Session");

                // Will use vEmpty for Empty parameter
                Object vEmpty = System.Reflection.Missing.Value;

                //setup profile
                string strProfileInfo = "NIGHTCRAWLER.maplenj.com" + "\n" + "SLLists";

                // Logon
                //Log.WriteLine("Loging in");
                oSession.Logon("SLLists", "welcome", false, true, 0, true, strProfileInfo);
                //Log.WriteLine("Logged in");


                //get inbox
                MAPI.Folder inbox = (MAPI.Folder)oSession.Inbox;


                //get the processed folder
                MAPI.Folders oFolders = (MAPI.Folders)inbox.Folders;

                MAPI.Folder processedFolder = (MAPI.Folder)oFolders.get_Item("Processed");

                // Get Messages collection.
                MAPI.Messages oMsgs = (MAPI.Messages)inbox.Messages;

                //process the collection
                for (int i = 0; i < (int)oMsgs.Count; i++)
                {
                    MAPI.Message msg = (MAPI.Message)oMsgs.get_Item(i + 1);

                    if (DateTime.Parse(msg.TimeReceived.ToString()) >= date.Date)
                    {
                        MAPI.Attachments atm = (MAPI.Attachments)msg.Attachments;

                        // modified to check all attachments
                        for (int j = 0; j < (int)atm.Count; j++)
                        {
                            MAPI.Attachment a = (MAPI.Attachment)atm.get_Item(j + 1);

                            if (a.Name.ToString().ToUpper() == filename.ToUpper())
                            {
                                //Log.WriteLine("Saving file");
                                a.WriteToFile(System.AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.ImportDir + DateTime.Today.ToString("yyyyMMdd") + "_" + a.Name);
                                //a.WriteToFile(@"C:\" + a.Name); // remove 
                                //Log.WriteLine("Saved file");
                                return true;
                            }
                        }

                    }
                }

                // Log off session.
                if (oSession != null)
                    oSession.Logoff();
            }
            catch (Exception e)
            {
                //Log.WriteLine(e.ToString());
            }
            return false;
        }

        public static void ReadOutlookNightCrawler()
        {
            //I think ApplicationClass() works only if you have outlook installed
            Outlook.Application outlook = new Outlook.ApplicationClass();
            Outlook.NameSpace ns = outlook.GetNamespace("Mapi");
            object _missing = Type.Missing;

            ns.Logon(_missing, _missing, false, true);

            //Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            Outlook.Recipient recip = (Outlook.Recipient)ns.CreateRecipient("AuditConfirm@mapleusa.com");
            Outlook.MAPIFolder inbox = ns.GetSharedDefaultFolder(recip, Outlook.OlDefaultFolders.olFolderInbox);

            int unread = inbox.UnReadItemCount;
            /*
            foreach (Outlook.MailItem mail in inbox.Items)
            {
                string s = mail.Subject;
            }
            */

            Outlook.MailItem mitem = inbox.Items[1] as Outlook.MailItem;

            //mitem.PrintOut();

            string AttachmentFolder = System.AppDomain.CurrentDomain.BaseDirectory + @"Attachments";
            if (!Directory.Exists(AttachmentFolder))
            {
                Directory.CreateDirectory(AttachmentFolder);
            }

            mitem.Attachments[1].SaveAsFile(System.AppDomain.CurrentDomain.BaseDirectory + "a");


        }



    }

}


