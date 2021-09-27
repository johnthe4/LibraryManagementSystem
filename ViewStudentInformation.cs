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
            if(txtSearchEnrollment.Text != "")
            {
                Image image = Image.FromFile("D:/College/C# Tut Projects/LibraryManagementSystem/Images/search1.gif");
                pictureBox1.Image = image;
            }
            else
            {
                Image image = Image.FromFile("D:/College/C# Tut Projects/LibraryManagementSystem/Images/search.gif");
                pictureBox1.Image = image;
            }
        }
    }
}
