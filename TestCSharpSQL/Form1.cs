using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TestCSharpSQL
{
    public partial class Form1 : Form
    {

        //    public static string myConnectionString = "server=45.32.189.13;uid=rommeladmin;" +
        //"pwd=sql2303;database=equipment2;convert zero datetime=True";
        public static string myConnectionString =   "server=127.0.0.1;" +
                                                    "uid=root;" +
                                                    "pwd=;" +
                                                    "database=nvbsystem;" +
                                                    "convert zero datetime=True";

        public Form1()
        {
            InitializeComponent();
            //LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataGridView(object sender, EventArgs e)
        {
            var b = sender as Button;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            try
            {

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tblperformancetest";
                //MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //adap.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[2].DefaultView;

                //to get column use reader[x]

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[1].ToString() == b.Text)
                    {
                        Label l = new Label();
                        l.Text = reader[1].ToString();
                        
                        flowLayoutPanel1.Controls.Add(l);
                    }
                    if (reader[3].ToString() == "1")
                    {
                        ComboBox cmbox = new ComboBox();
                        cmbox.Items.Add("PASS");
                        cmbox.Items.Add("FAIL");
                        cmbox.Items.Add("N/A");
                        flowLayoutPanel2.Controls.Add(cmbox);
                    }
                    else if (reader[3].ToString() == "2")
                    {
                        TextBox usrinput = new TextBox();
                        flowLayoutPanel2.Controls.Add(usrinput);
                    }
                }


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Clone();
                }
            }


        }

        //private void LoadData()
        //{
        //    MySqlConnection conn = new MySqlConnection(myConnectionString);
        //    conn.Open();
        //    try
        //    {
               
        //        MySqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "SELECT * FROM tblperformancetest";
        //        //MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //        //DataSet ds = new DataSet();
        //        //adap.Fill(ds);
        //        //dataGridView1.DataSource = ds.Tables[0].DefaultView;

        //        //to get column use reader[x]

        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            if (reader[2].ToString() == "1000022")
        //            {
        //                Label b = new Label();
        //                b.Text = reader[5].ToString();
        //                flowLayoutPanel1.Controls.Add(b);
        //            }
        //        }

                
        //    }
        //    catch (MySql.Data.MySqlClient.MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //        {
        //            conn.Clone();
        //        }
        //    }
        //}


    }
}
