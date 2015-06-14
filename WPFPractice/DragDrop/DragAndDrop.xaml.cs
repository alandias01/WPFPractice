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
using System.IO;

namespace WPFPractice
{
    /// <summary>
    /// Interaction logic for DragAndDrop.xaml
    /// </summary>
    public partial class DragAndDrop : Window
    {
        public DragAndDrop()
        {
            InitializeComponent();
        }

        
        private void dg1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else { e.Effects = DragDropEffects.None; }
        }

        private void dg1_Drop(object sender, DragEventArgs e)
        {
            string[] droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            
            List<string> Lines = File.ReadAllLines(droppedFilePaths[0]).ToList();
            List<DropObject> CSVObjects = new List<DropObject>();

            foreach (string line in Lines)
            {
                string[] col = line.Split(",".ToCharArray());
                CSVObjects.Add(new DropObject(col[0], col[1]));
            }

            dg1.ItemsSource = CSVObjects;
            
            //var csv = from line in lines
            //          select (from piece in line
            //                  select piece.Split(',')).ToArray();

            

        }
    }

    public class DropObject
    {
        public string CUSIP { get; set; }
        public string QUANTITY { get; set; }

        public DropObject(string cusip, string quantity)
        {
            CUSIP = cusip;
            QUANTITY = quantity;
        }
    }
}
