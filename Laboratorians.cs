using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedLab
{
    public partial class Laboratorians : Form
    {
        public Laboratorians()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MedLabDBs;Integrated Security=True");

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if(LabNameTB.Text == "" || LabAddressTB.Text == "" || LabPhoneTB.Text == ""  || LabQualCB.SelectedIndex == -1 || LabGenCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            } else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO LaboratoriansTbl(LabName,LabGen,LabAddress,LabQual,LabPhone,LabDOB) VALUES (@LN,@LG,@LA,@LQ,@LP,@LD)",Con);
                    cmd.Parameters.AddWithValue("@LN", LabNameTB.Text);
                    cmd.Parameters.AddWithValue("@LG", LabGenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LA", LabAddressTB.Text);
                    cmd.Parameters.AddWithValue("@LQ", LabQualCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LP", LabPhoneTB.Text);
                    cmd.Parameters.AddWithValue("@LD", LabDOB.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Laboratorian saved!");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);                    
                }
            }

        }
    }
}
