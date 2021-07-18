using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close the application
            this.Close();

        }


        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            //clear textbox upon user click
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            //clear textbox upon user click
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';     //hide password that is being typed by user
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            // make sql connection
            SqlConnection con = new SqlConnection();
            string connString = "server=localhost;user=root;database=library;port=3306;password=L@ndsh@rk123";
            MySqlConnection conn = new MySqlConnection(connString);
            SqlCommand cmd = new SqlCommand();


            cmd.Connection = con;
            cmd.CommandText = "select * from library.logintable where username = '" +txtUsername.Text+"' and pass ='" +txtPassword.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            /*
            string connStr = "server=localhost;user=root;database=library;port=3306;password=L@ndsh@rk123";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "select * from library.logintable where username = '" + txtUsername.Text + "' and pass ='" + txtPassword.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            */
            int a = 5;
        }
    }
}
