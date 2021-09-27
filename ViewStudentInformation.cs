using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearchEnrollment_TextChanged(object sender, EventArgs e)
        {
            // change image in picturebox1 when txtSearchEnrollment textBox is being used
            if(txtSearchEnrollment.Text != "")
            {
                lblView.Visible = false;
                Image image = Image.FromFile("D:/College/C# Tut Projects/LibraryManagementSystem/Images/search1.gif");
                pictureBox1.Image = image;

                //search database for the enrollment number in txtSearchEnrollment
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

                    //write and execute query
                    cmd.CommandText = "select * from newstudent where enroll LIKE '"+txtSearchEnrollment.Text+"%' ";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //fill gridview with table from newstudent
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
                lblView.Visible = true;
                Image image = Image.FromFile("D:/College/C# Tut Projects/LibraryManagementSystem/Images/search.gif");
                pictureBox1.Image = image;

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

                    //write and execute query
                    cmd.CommandText = "select * from newstudent where enroll LIKE '" + txtSearchEnrollment.Text + "%' ";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //fill gridview with table from newstudent
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

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            //hide panel2 until being used
            panel2.Visible = false;
            //show newstudent table from database in data grid
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

                //write and execute query
                cmd.CommandText = "select * from newstudent";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //fill gridview with table from newstudent
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

        int bid;            //stores the student id
        Int64 rowid;        //stores selected rowID
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            //show panel 2 to edit information
            panel2.Visible = true;

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

                //write and execute query
                cmd.CommandText = "select * from newstudent where stuid = "+bid+"";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //fill text boxes with information from table ds
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtEnrollment.Text = ds.Tables[0].Rows[0][2].ToString();
                txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                txtSContact.Text = ds.Tables[0].Rows[0][5].ToString();
                txtSEmail.Text = ds.Tables[0].Rows[0][6].ToString();

                //close connection
                myConn.Close();
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //save changes to database
            String sname = txtSName.Text;
            String enroll = txtEnrollment.Text;
            String department = txtDepartment.Text;
            String semester = txtSemester.Text;
            Int64 contact = Int64.Parse(txtSContact.Text);
            String email = txtSEmail.Text;

            //confirm user wants to save changes
            if(MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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

                    //write and execute query
                    cmd.CommandText = "update newstudent set sname='"+ sname + "',enroll='"+ enroll + "',dep='"+department+"',sem='"+semester+
                        "',contact='"+contact+"',email='"+email+"' where stuid =" +rowid+"";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                //update gridview
                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //confirm user wants to save changes
            if (MessageBox.Show("Data will be deleted. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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

                    //write and execute query
                    cmd.CommandText = "delete from newStudent where stuid = "+rowid+"";
                    cmd.ExecuteNonQuery();

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                //update gridview
                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //refresh the screen
            ViewStudentInformation_Load(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved data will be lost.","Are you sure",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }
    }
}
