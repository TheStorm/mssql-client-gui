/*
 * **********************************
 * Autor: Sebastian Danninger       *
 * Projektbeginn: WS 08/09          *
 * Codingbeginn: 04/12/2008         *
 * Copyright: Sebastian Danninger   *
 * **********************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace MSSQL_Client_GUI
{
    class SQL
    {
        public static void Connect(string host, string port)
        {
            try
            {
                string connstring = host + "," + port;
                SqlConnectionStringBuilder sqlbuilder = new SqlConnectionStringBuilder();
                sqlbuilder.DataSource = connstring;
                sqlbuilder.InitialCatalog = "de2_projekt_lagerverwaltung";
                sqlbuilder.UserID = "sa";
                sqlbuilder.Password = "sa"; 
                SqlConnection sql = new SqlConnection(sqlbuilder.ConnectionString);
                if (sql.State == ConnectionState.Closed)
                {
                    sql.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        public static void Disconnect(string host, string port)
        {
            try
            {
                string connstring = host + "," + port;
                SqlConnectionStringBuilder sqlbuilder = new SqlConnectionStringBuilder();
                sqlbuilder.DataSource = connstring;
                sqlbuilder.InitialCatalog = "de2_projekt_lagerverwaltung";
                sqlbuilder.UserID = "sa";
                sqlbuilder.Password = "sa";
                SqlConnection sql = new SqlConnection(sqlbuilder.ConnectionString);
                if (sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /*public static void SELECT(string Select)
        {
            SqlDataAdapter da = new SqlDataAdapter(Select);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                Console.WriteLine("{0,-35} {1} ", row[0], row[1]);
            }
            Console.ReadLine();
        }*/
    }
}
