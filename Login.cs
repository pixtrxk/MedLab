using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MedLab
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
        private void LoginBTN_Click(object sender, EventArgs e)
        {
            if(UsernameTB.Text == "" || PasswordTB.Text == "")
            {
                MessageBox.Show("Please enter both username and password");
            }
            else
            {
                Con.Open();
                string query = "SELECT COUNT(*) FROM LaboratoriansTbl WHERE LabName = @LN AND LabPass = @LP";
                SqlDataAdapter adapter = new SqlDataAdapter(query,Con);
                adapter.SelectCommand.Parameters.AddWithValue("@LN", UsernameTB.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@LP", PasswordTB.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Patients Obj = new Patients();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }

                Con.Close();
            }
        }
                
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminWdw_Click(object sender, EventArgs e)
        {
            Admin Obj = new Admin();
            Obj.Show();
            this.Hide();
        }
    }
}
