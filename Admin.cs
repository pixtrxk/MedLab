using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedLab
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            if(AdminPasswordTB.Text == "")
            {
                MessageBox.Show("Enter the password!");
            }
            else if(AdminPasswordTB.Text == "admin111")
            {
                Laboratorians Obj = new Laboratorians();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin password is wrong!");
            }
        }
    }
}
