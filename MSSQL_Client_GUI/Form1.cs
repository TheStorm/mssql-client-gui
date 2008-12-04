using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MSSQL_Client_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            SQL.Connect(tb_IP.Text, tb_Port.Text);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            SQL.Disconnect(tb_IP.Text, tb_Port.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = tb_IP.Text + "," + tb_Port.Text;
            SqlConnectionStringBuilder sqlbuilder = new SqlConnectionStringBuilder();
            sqlbuilder.DataSource = connstring;
            sqlbuilder.InitialCatalog = "de2_projekt_lagerverwaltung";
            sqlbuilder.UserID = "sa";
            sqlbuilder.Password = "sa";
            SqlConnection sql = new SqlConnection(sqlbuilder.ConnectionString);

            string Select = "Select Bezeichnung FROM Artikel";
            SqlDataAdapter da = new SqlDataAdapter(Select,sql);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            /*for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                //Console.WriteLine("{0,-35} {1} ", row[0], row[1]);
                textBox1.AppendText(row[0].ToString());
            }*/
            foreach (DataRow row1 in tbl.Rows)
            {
                //Console.WriteLine("{0,-35}{1}", row["ProductName"], row["UnitPrice"]);
                textBox1.AppendText(row1["Bezeichnung"].ToString());
                textBox1.AppendText("\r\n");
            }
        }

        private void tb_IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Port_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } 

    }
}
