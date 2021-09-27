using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryManagementSystem
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("Confirm?","Alert",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //clear all textboxes
            txtName.Clear();
            txtEnrollement.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check textboxes for null values
            if(txtName.Text!= "" && txtEnrollement.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtContact.Text != "" && txtEmail.Text != "" )
            {
                //get values from textboxes
                String name = txtName.Text;
                String enroll = txtEnrollement.Text;
                String department = txtDepartment.Text;
                String sem = txtSemester.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

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

                    //write and execute query to save student info
                    cmd.CommandText = "insert into newstudent (sname,enroll,dep,sem,contact,email) values " +
                        "('"+name+"','"+enroll+"','"+department+"','"+sem+"',"+contact+",'"+email+"')";
                    cmd.ExecuteNonQuery();

                    //close connection
                    myConn.Close();
                    Console.WriteLine("Done");

                    MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
