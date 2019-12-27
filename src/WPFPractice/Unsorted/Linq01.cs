using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace WPFPractice.Unsorted
{
    public class Product { public int X { get; set; } public int Y { get; set; } }

    public class MyComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y) { if ((x.X == y.X)) { return true; } else { return false; } }
        public int GetHashCode(Product obj) { return obj.X.GetHashCode(); }
    }

    public class Linq01
    {
        public Linq01()
        {
            LinqSample l = new LinqSample();
            l.Linq10();
            
            Console.ReadLine();
        }
    }

    public class LinqSample
    {
        XElement samplexml; 
        List<Product> SampleList;

        public LinqSample()
        {            
            samplexml = XElement.Load("sample.xml");
            SampleList = new List<Product>() { new Product() { X = 3, Y = 4 }, new Product() { X = 5, Y = 6 }, new Product() { X = 7, Y = 8 }, new Product() { X = 9, Y = 10 } };
        }

        #region Linq
        public void Linq01()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var lownums = from n in numbers where n < 5 select n;
            foreach (var x in lownums) { Console.WriteLine(x); }
        }

        public void Linq02()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var textNums = from n in numbers select strings[n];
                        
            foreach (var s in textNums) { Console.WriteLine(s); }

        }

        //Creates anonymous type and adds the attribute Price
        public void Linq03()
        {
            List<Product> products = new List<Product> 
            { new Product() { X = 1, Y = 2 }, new Product() { X = 3, Y = 4 }, new Product() { X = 5, Y = 6 } };
            
            var prod = from p in products select new { p.X, p.Y, Price=p.X+p.Y};

            foreach (var d in prod) { Console.WriteLine(d.X+" "+d.Y+" "+d.Price); }
        }

        //Like a double foreach.  Compares each element in array 1 to each element in array 2
        public void Linq04()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs =from a in numbersA 
                       from b in numbersB
                       where a < b
                       select new { a, b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs) { Console.WriteLine(pair.a + " is less than " + pair.b); }
        }

        //Get Distinct Values
        public void Linq05()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };
            var UniqueNums = factorsOf300.Distinct();
            foreach (var a in UniqueNums) { Console.WriteLine(a); }
        }
        
        public void Linq06()
        {
            List<Product> products = new List<Product> { new Product() { X = 7, Y = 2 }, new Product() { X = 3, Y = 4 }, new Product() { X = 5, Y = 6 } };
            var b = from n in products orderby n.X select n.X;
            foreach (var a in b) { Console.WriteLine(a); }
        }

        //Union of unique numbers
        public void Linq07()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            foreach (var n in uniqueNumbers) { Console.WriteLine(n); }
        }

        //intersection of objects using IEqualityComparer
        public void Linq08()
        {
            List<Product> products1 = new List<Product> { new Product() { X = 7, Y = 2 }, new Product() { X = 3, Y = 4 }, new Product() { X = 5, Y = 6 } };
            List<Product> products2= new List<Product> { new Product() { X = 5, Y = 6 }, new Product() { X = 12, Y = 34 }, new Product() { X = 1, Y = 2 } };

            IEnumerable<Product> combine = products1.Intersect(products2, new MyComparer());
            foreach (var a in combine) { Console.WriteLine(a.X+" "+a.Y); }            
        }

        public void Linq09()
        {
            //create list of anony obj
            //Create list with data from another list

            List<int> a = new List<int>();
            a.AddRange(new List<int> { 3, 4, 5, 6, 7 });

            foreach (var b in a) { Console.WriteLine(b); }

            var c = a.Select(x => new { first = x }).ToList();
            foreach (var d in c) { Console.WriteLine(d.first); }
        }

        public void Linq10()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            holder h = new holder();
            

            IEnumerable<holder> a = from i in strings where i.Length > 4 select new holder { up=i};
                        
        }

        public void Linq11()
        {
            string[] files = Directory.GetFiles(@"c:\");

            var a = from i in files where Regex.IsMatch(i, "alan", RegexOptions.IgnoreCase) select i;
            //foreach (string file in files) { Console.WriteLine(Path.GetFileName(file)); }
            foreach (string f in a) { Console.WriteLine(f); }
        }

        public void Linq12()
        {
            var ADPList = new List<ADPData> { new ADPData("1", 2), new ADPData("1", 3), new ADPData("1", 4), new ADPData("2", 3), new ADPData("2", 4), new ADPData("3", 5), new ADPData("3", 6) };

            var DTCList = new List<ADPData> { new ADPData("1", 5), new ADPData("1", 5), new ADPData("2", 3), new ADPData("2", 3), new ADPData("2", 2), new ADPData("3", 11) };


            var GrpADPList = ADPList.GroupBy(x => x.Ctpy);
            var GrpDTCList = DTCList.GroupBy(x => x.Ctpy);

            foreach (var A in GrpADPList)
            {
                foreach (var B in GrpDTCList)
                {
                    if (A.Key == B.Key)
                    {
                        Console.WriteLine(A.Key);
                        Console.WriteLine("--" + A.Sum(x => x.Amt));
                        Console.WriteLine("--" + B.Sum(x => x.Amt));
                    }
                }


            }

            /*
            foreach (var A in GrpADPList)
            {
                Console.WriteLine(A.Key);
                Console.WriteLine(A.Sum(x => x.Amt));                
            }
            */

        }



        #endregion

        #region Anonymous Methods
        public void Anony01()        
        {
            var c = new
            {
                First = "Alan",
                Last = "Dias",
                Age = 29
            };

            //We can use this to do some databinding
            var l = new List<object>
            {
                new {First="Alan", Last="Dias"},
                new {First="Jon", Last="Doe"}
            };
            Console.WriteLine(c.First);
        }

        public void Anony02()
        {
            Thread t=new Thread(delegate() 
                {
                    Console.WriteLine("Hello");
                });

            t.Start();
        }

        delegate int del(int e);
        public void Anony03()
        {
            del d=delegate(int e) { return e+1; };
            Console.WriteLine(d(3));
        }
        #endregion

        #region Lambda Expressions

        public void MainThreadMethod(int i) { Console.WriteLine(i); }
        public void Lambda01()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };


            Thread t = new Thread(()=>
            {
                foreach (int i in numbers)
                {
                    Console.WriteLine(i); //Regular
                    MainThreadMethod(i);  //Communicating with main Thread
                }
            });

            t.Start();
        }

        public void Lambda02()
        {
            del d = (int e) => { return e + 1; };
            Console.WriteLine(d(3)); 
        }
        
        delegate bool del02(int x, int y);
        public void Lambda03()
        {
            del02 d = (x, y) => x == y; 
            if(d(3,3)){Console.WriteLine("It's a Match");}
        }

        
        public void Lambda04() 
        {
            
        }


        public void Lambda05()
        {

        }

        public void Lambda06()
        {

        }

        #endregion

        #region Linq to XML

        public void Linq2XML01()
        {
            //var a = xml.ToString(); Console.WriteLine(a);
            foreach (XElement itemElement in samplexml.Elements())
            {
                string name = itemElement.Element("name").Value;
                decimal unitPrice = Convert.ToDecimal(itemElement.Element("unitPrice").Value);
                Console.WriteLine(name+" "+unitPrice);
            }

            /* Output
             * Blue Ball 4.95
             * Orange Octagon 14.95             
             */
        }
        
        public void Linq2XML02() 
        {
            XElement doc = new XElement("Inventory",
                new XElement("Book", new XAttribute("Count", "True"),
                    new XElement("color", "Red"),
                    new XElement("Pages", "3")
                    )
                    );
            var a = doc.ToString();
            Console.WriteLine(a);
            doc.Save("tmp.xml");

            /*This is whats in the file.  The output to screen doesn't show the declaration <?xml version="1.0" encoding="utf-8"?>
             * 
             *  <?xml version="1.0" encoding="utf-8"?>
                <Inventory>
                  <Book Count="True">
                    <color>Red</color>
                    <Pages>3</Pages>
                  </Book>
                </Inventory>
             *             
             */
            

        }

        public void Linq2XML03() 
        {
            XElement xml = new XElement("Products", 
                from c in SampleList select new XElement("Product",
                    new XElement("X", c.X),
                    new XElement("Y", c.Y)
                    )
                    );

            Console.WriteLine(xml);

            /*
             <Products>
                  <Product>
                    <X>3</X>
                    <Y>4</Y>
                  </Product>
                  <Product>
                    <X>5</X>
                    <Y>6</Y>
                  </Product>
                  <Product>
                    <X>7</X>
                    <Y>8</Y>
                  </Product>
                  <Product>
                    <X>9</X>
                    <Y>10</Y>
                  </Product>
            </Products>
             */

        }//Reading a collection and creating xml

        public void Linq2XML04()
        {

        }

        public void Linq2XML05()
        {

        }

        #endregion

    }

    public class holder { public string up { get; set; } public string down { get; set; } } 
}