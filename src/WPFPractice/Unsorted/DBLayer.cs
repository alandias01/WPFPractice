using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace WPFPractice.Unsorted
{
    public class DBLayer
    {
        public DBLayer()
        {
            /*
            List<balObject> bo = new List<balObject>();
            balDA bd = new balDA();
            //bd.LoadAll(bo);

            bd.Insert2(new balObject("",700));
            //bd.Update(new balObject("1014", 500));
            */

            List<WordsObject> WO = new List<WordsObject>();
            WordsDA da = new WordsDA();
            da.LoadAll(WO);
            foreach (WordsObject w in WO)
                Console.WriteLine(w.Word);
        }
    }

    public class balDA
    {
        string CmdStr = @"Data Source=.\SQLEXPRESS; database=AlanTest;Trusted_Connection=Yes; ";

        public void LoadAll(ICollection<balObject> list)
        {
            //Change to SP if required
            string LoadAllSQL = "SELECT * FROM bal";

            using (SqlConnection conn = new SqlConnection(CmdStr))
            {
                SqlCommand cmd = new SqlCommand(LoadAllSQL, conn);
                //cmd.CommandType=CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("","");

                SqlDataReader rdr = null;
                try
                {
                    conn.Open();
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        list.Add(new balObject(rdr));
                    }
                }

                catch (SqlException Ex)
                { throw; }

                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
            }
        }

        public void LoadSingle(balObject bo)
        {
            //Change to SP if required
            string SQL = "SELECT * FROM bal";
            int Result = 0;

            using (SqlConnection conn = new SqlConnection(CmdStr))
            {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                //cmd.CommandType=CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("","");

                try
                {
                    conn.Open();
                    Result = (int)cmd.ExecuteScalar();
                }

                catch (SqlException Ex)
                {
                    throw;
                }
            }
        }

        public void Insert(balObject obj)
        {
            //Change to SP if required
            string InsertSQL = "INSERT INTO bal (cpty,quantity) VALUES (@cpty, @quantity)";

            using (SqlConnection conn = new SqlConnection(CmdStr))
            {
                SqlCommand cmd = new SqlCommand(InsertSQL, conn);
                //cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cpty", CheckNull(obj.cpty));
                cmd.Parameters.AddWithValue("@quantity", CheckNull(obj.quantity));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException Ex)
                { throw; }
            }
        }

        public void Insert2(balObject obj)
        {
            //Change to SP if required
            string InsertSQL = "INSERT INTO bal (cpty,quantity) VALUES (@cpty, @quantity)";

            using (SqlConnection conn = new SqlConnection(CmdStr))
            {
                SqlCommand cmd = new SqlCommand(InsertSQL, conn);
                //cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cpty", (object)obj.cpty ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@quantity", (object)obj.quantity ?? DBNull.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException Ex)
                { throw; }
            }
        }

        public void Update(balObject obj)
        {
            //Change to SP if required
            string UpdateSQL = "UPDATE bal SET cpty=@cpty, quantity=@quantity where cpty=@cpty";

            using (SqlConnection conn = new SqlConnection(CmdStr))
            {
                SqlCommand cmd = new SqlCommand(UpdateSQL, conn);
                //cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cpty", obj.cpty);
                cmd.Parameters.AddWithValue("@quantity", obj.quantity);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException Ex)
                {
                    /**/
                }
            }
        }

        public void InsertIntoAccess2007()
        {
            //Access 2000-2003
            //string CmdStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\tmp.mdb";

            //Access 2007
            string CmdStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\temp\tmp.accdb";

            string InsertSQL = "INSERT INTO Positions (BookName,Ctpy) VALUES (@BookName, @Ctpy)";

            using (OleDbConnection conn = new OleDbConnection(CmdStr))
            {
                OleDbCommand cmd = new OleDbCommand(InsertSQL, conn);
                //cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookName", "MP269");
                cmd.Parameters.AddWithValue("@Ctpy", "0235");

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (OleDbException Ex)
                {
                    throw;
                }
            }
        }

        //If string is empty, it will set to NULL
        public object CheckNull(object X)
        {
            if (X is string)
            {
                if (string.IsNullOrEmpty((string)X))
                {
                    return DBNull.Value;
                }
                else return X;
            }

            else if (X == null)
            {
                return DBNull.Value;
            }

            else return X;
        }
    }

    public class balObject
    {
        public balObject(SqlDataReader rdr)
        {
            this.cpty = rdr["cpty"] == DBNull.Value ? this.cpty : (string)rdr["cpty"];
            this.quantity = rdr["quantity"] == DBNull.Value ? this.quantity : (int)rdr["quantity"];
        }

        public balObject(string c, int q)
        {
            this.cpty = c;
            this.quantity = q;
        }

        public string cpty { get; set; }
        public int? quantity { get; set; }
    }

    //MySql 
    public class WordsObject
    {
        public string Word { get; protected set; }
        public string Definition { get; protected set; }

        public WordsObject(MySqlDataReader row)
        {
            this.Word = row["word"] == DBNull.Value ? this.Word : (string)row["word"];
            this.Definition = row["definition"] == DBNull.Value ? this.Word : (string)row["definition"];
        }
    }

    public class WordsDA
    {
        public void LoadAll(ICollection<WordsObject> WO)
        {
            string cstr = "Server=localhost;Database=gre;Uid=root;Pwd=nsxr;";
            string sql = "SELECT * FROM words";

            using (MySqlConnection conn = new MySqlConnection(cstr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = null;

                try
                {
                    conn.Open();
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        WO.Add(new WordsObject(rdr));
                    }
                }
                catch (MySqlException e) { throw; }

                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
            }
        }
    }
}