using System;
using System.Linq;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace WPFPractice.Unsorted
{
    /* Commented out since I don't have a reference to MAPI
     * 
    public class ExchangeServer
    {
        public ExchangeServer()
        {
            ReadOutlookNightCrawler();
        }
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
            Outlook.Application outlook = new Outlook.Application();
            Outlook.NameSpace ns = outlook.GetNamespace("Mapi");
            object _missing = Type.Missing;

            ns.Logon(_missing, _missing, false, true);

            //Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            Outlook.Recipient recip = (Outlook.Recipient)ns.CreateRecipient("AuditConfirm@mapleusa.com");
            Outlook.MAPIFolder inbox = ns.GetSharedDefaultFolder(recip, Outlook.OlDefaultFolders.olFolderInbox);

            int unread = inbox.UnReadItemCount;
            
            //foreach (Outlook.MailItem mail in inbox.Items)
            //{
            //    string s = mail.Subject;
            //}
            

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
    */
}