using System;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;  //show taskbar when maximized
            this.WindowState = FormWindowState.Maximized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        //int to restrict how many new forms can be open
        public static int restrictAbs = 0;
        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restrictAbs == 0)
            {
                restrictAbs++;
                //open AddBooks form
                AddBooks abs = new AddBooks();
                abs.Show();
            }
            else
            {
                MessageBox.Show("Form is already open.");
            }
            
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open ViewBooks form
            ViewBooks vb = new ViewBooks();
            vb.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void viewStudentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInformation vst = new ViewStudentInformation();
            vst.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks();
            ib.Show();
        }
    }
}
