using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SL.Data;

namespace WPFPractice.TreeViewControl
{
    /// <summary>
    /// Interaction logic for WPFTree.xaml
    /// </summary>
    public partial class WPFTree : Window
    {
        public WPFTree()
        {           
            InitializeComponent();
            DataStore.GetData(treeView1);
        }
    }

    public class Book
    {
        public string BookName { get; set; }
        public List<Ctpy> Ctpys = new List<Ctpy>();

    }
    public class Ctpy
    {
        public string CtpyName { get; set; }
        public List<PositionView> Positions = new List<PositionView>();
    }


    public class DataStore
    {
        public static void GetData(TreeView TV)
        {
            List<Book> BList = new List<Book>();

            using (SLEntities SLE = new SLEntities())
            {
                var expr1 = from i in SLE.PositionViews group i by new { i.CtpyCode, i.DatabaseName };

                var expr2 = from j in expr1 group j by j.Key.DatabaseName;


                foreach (var expr3 in expr2)
                {
                    Book b = new Book();
                    b.BookName = expr3.Key;

                    foreach (var expr4 in expr3)
                    {
                        Ctpy c = new Ctpy();
                        c.CtpyName = expr4.Key.CtpyCode;

                        foreach (var expr5 in expr4)
                        {
                            c.Positions.Add(expr5);
                        }
                        b.Ctpys.Add(c);
                    }
                    BList.Add(b);
                }
            }

            foreach (Book b in BList)
            {
                TreeViewItem TVBookName = new TreeViewItem();
                TVBookName.Header = b.BookName;
                foreach (Ctpy c in b.Ctpys)
                {
                    TreeViewItem TVCtpyName = new TreeViewItem();
                    TreeViewItem TVPosition = new TreeViewItem();
                    TVCtpyName.Items.Add(TVPosition);

                    TVCtpyName.Header = c.CtpyName;
                    DataGrid dg = new DataGrid();
                    dg.ItemsSource = c.Positions;
                    TVPosition.Header = dg;
                    TVBookName.Items.Add(TVCtpyName);
                }

                TV.Items.Add(TVBookName);
            }


        }
    }
}
