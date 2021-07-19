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
            try
            {
                Console.WriteLine("Connecting");
                string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand
                    ("select * from logintable where username = '"+txtUsername.Text+"' and pass = '"+txtPassword.Text+"'", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                Console.WriteLine("Done");

                if(ds.Tables[0].Rows.Count != 0)
                {
                    //username and password valid
                    this.Hide();
                    Dashboard dash = new Dashboard();   //open dashboard 
                    dash.Show();
                }
                else
                {
                    //show error if username and password doesnt match database
                    MessageBox.Show("Wrong Username or Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
