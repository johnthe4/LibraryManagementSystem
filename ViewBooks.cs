using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            //hide panel2 until being used
            panel2.Visible = false;
            //show newbook table from database in data grid
            //make sql connection
            try
            {
                //create sql connection
                Console.WriteLine("Connecting");
                string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();

                //create command
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = myConn;

                //check sql version
                Console.WriteLine($"MySQL version : {myConn.ServerVersion}");

                //write and execute query
                cmd.CommandText = "select * from newbook";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //fill gridview with table from addBook
                dataGridView1.DataSource = ds.Tables[0];

                //close connection
                myConn.Close();
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        int bid;        //book id of selected book in dataGridView1
        Int64 rowid;    //row id of selected index in dataGridView1
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;  //bring up second panel

            try
            {
                //create sql connection
                Console.WriteLine("Connecting");
                string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();

                //create command
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = myConn;

                //write and execute query
                cmd.CommandText = "select * from newbook where bid="+bid+"";    //query to select book from addBook 
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                //fill textboxes with data from table
                txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtBAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
                txtBPublication.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
                txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();

                //close connection
                myConn.Close();
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //confirm user wants to save data
            if (MessageBox.Show("Data will be Updated. Confirm?","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                //get values from all textboxes
                String bName = txtBName.Text;
                String bAuthor = txtBAuthor.Text;
                String publication = txtBPublication.Text;
                String pDate = txtPDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                //make sql connection
                try
                {
                    //create sql connection
                    Console.WriteLine("Connecting");
                    string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    myConn.Open();

                    //create command
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = myConn;

                    //write and execute query to update selected files with values from textboxes
                    cmd.CommandText = "update newbook set bName = '"+bName+"',bAuthor = '"+bAuthor+"',bPubl = '"+publication+"',bPDate = '"+pDate+
                        "',bPrice ="+price+",bQuant = "+quan+" where bid = "+rowid+"";
                    cmd.ExecuteNonQuery();

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");

                    //refresh dataGridView
                    ViewBooks_Load(sender, e);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if(txtBookName.Text != "")
            {
                try
                {
                    //create sql connection
                    Console.WriteLine("Connecting");
                    string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    myConn.Open();

                    //create command
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = myConn;

                    //write and execute query
                    cmd.CommandText = "select * from newbook where bName Like '"+txtBookName.Text+"%'";    //query to search table addBook by bName
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //fill gridview with table from addBook
                    dataGridView1.DataSource = ds.Tables[0];

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                try
                {
                    //create sql connection
                    Console.WriteLine("Connecting");
                    string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    myConn.Open();

                    //create command
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = myConn;

                    //write and execute query
                    cmd.CommandText = "select * from newbook";    //query to select book from addBook 
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //fill gridview with table from addBook
                    dataGridView1.DataSource = ds.Tables[0];

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clear search box and hide panel 2
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //confirm user wants to save data
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //make sql connection
                try
                {
                    //create sql connection
                    Console.WriteLine("Connecting");
                    string myConnection = "datasource=127.0.0.1;port=3306;database=library;username=newuser;password=newuser";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    myConn.Open();

                    //create command
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = myConn;

                    //write and execute query to delete selected row
                    cmd.CommandText = "delete from newbook where bid ="+rowid+"";
                    cmd.ExecuteNonQuery();

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");

                    //refresh dataGridView
                    ViewBooks_Load(sender, e);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
