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
using System.Data.Common;
using System.Data.OleDb;
using System.Reflection;
using System.Drawing;
using System.Drawing.Printing;


namespace ConsoleApplication1
{
    //Create a person with an arm object that if normal, 5 fingers, retard has 6

    public class Program
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

            



            Console.ReadLine();

        }

        public DateTime GetLastTradeDate()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) { return DateTime.Today.AddDays(-3); }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) { return DateTime.Today.AddDays(-2); }
            else { return DateTime.Today.AddDays(-1); }

        }
    }

    public class Vertex
    {
        public bool IsInTree { get; set; }
        public string Label { get; set; }
        
        public Vertex(string label)
        {
            this.Label = label;
            IsInTree = false;
        } 
    }

    public class DistPar
    {
        public int Distance { get; set; }  //Distance from start to this vertex
        public int ParentVert { get; set; } //current parent of this vertex
        
        public DistPar(int distance,int parentVert )
        { 
            Distance = distance; 
            ParentVert = parentVert; 
        }
    }

    public class Graph
    {
        private List<Vertex> Vertices = new List<Vertex>();
        private int[,] AdjMatrix;
        private int INFINITY = 1000000;

        public Graph(int width, int height)
        {
            AdjMatrix = new int[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    AdjMatrix[i, j] = INFINITY; //replaces 0

        }
        public void AddVertex(string label)
        {
            Vertices.Add(new Vertex(label));
        }

        public void AddEdge(int start, int end, int weight)
        {
            AdjMatrix[start, end] = weight;
        }
    }


}




