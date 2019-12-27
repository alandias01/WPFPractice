using System;
using System.Text;
using System.IO;

namespace WPFPractice.Unsorted
{
    public class EncodingAndBytes
    {
        public EncodingAndBytes()
        {
            this.EncodeString();
        }

        private void EncodeString()
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

        private void EncodeString2()
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