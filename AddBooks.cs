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

namespace LibraryManagementSystem
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }


        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void AddBooks_FormClosed(object sender, FormClosedEventArgs e)
        {
            //change number of forms open 
            Dashboard.restrictAbs = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check to see if any text boxes is null
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtBookPrice.Text != "" && txtQuantity.Text != "")
            {

                String bName = txtBookName.Text;
                String bAuthor = txtAuthor.Text;
                String bPublication = txtPublication.Text;
                String pDate = dateTimePicker1.Text;
                Int64 bPrice = Int64.Parse(txtBookPrice.Text);
                Int64 bQuantity = Int64.Parse(txtQuantity.Text);

                // make sql connection
                try
                {
                    //create sql connection
                    Console.WriteLine("Connecting");
                    string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    myConn.Open();

                    //create cmd
                    var cmd = new MySqlCommand();
                    cmd.Connection = myConn;

                    //check sql version
                    Console.WriteLine($"MySQL version : {myConn.ServerVersion}");

                    //write and execute query
                    cmd.CommandText = "insert into newBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuant) " +
                        "values ('" + bName + "','" + bAuthor + "','" + bPublication + "','" + pDate + "'," + bPrice + "," + bQuantity + ")";
                    cmd.ExecuteNonQuery();

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");
                    MessageBox.Show("Data Save.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clear all text boxes
                    txtBookName.Clear();
                    txtAuthor.Clear();
                    txtPublication.Clear();
                    txtBookPrice.Clear();
                    txtQuantity.Clear();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Empty field not allowed!","Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close this form
            if (MessageBox.Show("This will delete your unsaved data.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
                //change number of forms open 
                Dashboard.restrictAbs = 0;
            }
        }
    }
}
