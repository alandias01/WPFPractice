using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;

namespace ConsoleApplication1
{
    public class NOEC : IEqualityComparer<NoteObject>
    {

        public bool Equals(NoteObject x, NoteObject y)
        {
            if ((x.ID == y.ID) && (x.Age == y.Age)) { return true; }
            else { return false; }
        }

        public int GetHashCode(NoteObject obj)
        {
            return obj.ID.GetHashCode()^obj.Age.GetHashCode();
        }
    }

    //Formal way to implement
    public class MYC:IComparer<NoteObject>
    {
        public int Compare(NoteObject x, NoteObject y)
        {
            if (x.ID > y.ID) { return 1; }
            if (x.ID < y.ID) { return -1; }
            else { return 0; }
        }
    }

    //Quicker way to implement than above
    public class MYC2 : IComparer<NoteObject>
    {
        public int Compare(NoteObject x, NoteObject y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    public class NoteObject : IEquatable<NoteObject>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public NoteObject(string N, int I, int A) { Name = N; ID = I; Age = A; }

        public bool Equals(NoteObject other)
        {
            if (this.ID == other.ID) { return true; }
            else { return false; }
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            Test3();                        

            Console.ReadLine();
            //Console.WriteLine("");
        }

        static void Test1()
        {
            var l1 = new List<NoteObject> { new NoteObject("Alan", 1,2), new NoteObject("Sybil", 9,3), new NoteObject("Ben", 5,6) };

            var l2 = new List<NoteObject> { new NoteObject("Alan", 1,3), new NoteObject("Ben", 5,5) };

            var temp = new List<NoteObject>();

            
            foreach (NoteObject n in l1)
            {
                if (!(l2.Contains(n))) { temp.Add(n); }
            }

            foreach (NoteObject a in temp) { Console.WriteLine(a.ID); };
            Console.ReadLine();
 
        }

        static void Test2()
        {
            var l1 = new List<NoteObject> { new NoteObject("Alan", 1, 2), new NoteObject("Sybil", 9, 3), new NoteObject("Ben", 5, 6) };

            var l2 = new List<NoteObject> { new NoteObject("Alan", 1, 3), new NoteObject("Ben", 5, 5) };
            

            IEnumerable<NoteObject> l3 = l1.Intersect<NoteObject>(l2, new NOEC());
            var l4 = new List<NoteObject>(l3);
            foreach (NoteObject r in l4) { l1.Remove(r); }
            
            foreach (NoteObject a in l1) { Console.WriteLine(a.ID); }


        }

        static void Test3()
        {
            var l1 = new List<NoteObject> { new NoteObject("Alan", 1, 2), new NoteObject("Sybil", 9, 3), new NoteObject("Ben", 5, 6) };

            var l2 = new List<NoteObject> { new NoteObject("Alan", 1, 3), new NoteObject("Ben", 5, 5) };

            l1.Sort(new MYC2());

            foreach (NoteObject n in l1)
            {
                Console.WriteLine(n.ID+" "+n.Name);
            }
 
        }

    } 
}
