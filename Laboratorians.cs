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
            ShowLabors();
        }
        SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
        private void ShowLabors()
        {
            Con.Open();
            string query = "SELECT * FROM LaboratoriansTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            LabDGV.DataSource = ds.Tables[0];
            LabDGV.ReadOnly = true;
   


            Con.Close();
            

        }

        private void ResetValues()
        {
            LabNameTB.Text = "";
            LabAddressTB.Text = "";
            LabPhoneTB.Text = "";
            LabQualCB.SelectedIndex = -1;
            LabGenCB.SelectedIndex = -1;
            key = 0;
            

        }
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if(LabNameTB.Text == "" || LabAddressTB.Text == "" || LabPhoneTB.Text == ""  || LabQualCB.SelectedIndex == -1 || LabGenCB.SelectedIndex == -1 || PassTB.Text == "")
            {
                MessageBox.Show("Missing information");
            } else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO LaboratoriansTbl(LabName,LabGen,LabAddress,LabQual,LabPhone,LabDOB, LabPass) VALUES (@LN,@LG,@LA,@LQ,@LP,@LD,@LPa)",Con);
                    cmd.Parameters.AddWithValue("@LN", LabNameTB.Text);
                    cmd.Parameters.AddWithValue("@LG", LabGenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LA", LabAddressTB.Text);
                    cmd.Parameters.AddWithValue("@LQ", LabQualCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LP", LabPhoneTB.Text);
                    cmd.Parameters.AddWithValue("@LD", LabDOB.Value);
                    cmd.Parameters.AddWithValue("@LPa", PassTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Laboratorian saved!");
                    Con.Close();
                    ShowLabors();
                    ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);                    
                }
            }

        }
        int key = 0;
        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please choose laboratorian to update!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE LaboratoriansTbl SET LabName = @LN,LabGen = @LG,LabAddress = @LA,LabQual = @LQ,LabPhone = @LP,LabDOB = @LD, @LabPass = @LPa WHERE LabId = @LKey", Con);
                    cmd.Parameters.AddWithValue("@LN", LabNameTB.Text);
                    cmd.Parameters.AddWithValue("@LG", LabGenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LA", LabAddressTB.Text);
                    cmd.Parameters.AddWithValue("@LQ", LabQualCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@LP", LabPhoneTB.Text);
                    cmd.Parameters.AddWithValue("@LD", LabDOB.Value);
                    cmd.Parameters.AddWithValue("@LPa", PassTB.Text);
                    cmd.Parameters.AddWithValue("@LKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Laboratorian updated!");
                    Con.Close();
                    ShowLabors();
                    ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private void DelBTN_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please choose laboratorian to delete!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM LaboratoriansTbl WHERE LabId = @LKey", Con);
                    cmd.Parameters.AddWithValue("@LKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Laboratorian deleted!");
                    Con.Close();
                    ShowLabors();
                    ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void LabDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LabNameTB.Text = LabDGV.SelectedRows[0].Cells[1].Value.ToString();
            LabGenCB.SelectedItem = LabDGV.SelectedRows[0].Cells[2].Value.ToString();
            LabAddressTB.Text = LabDGV.SelectedRows[0].Cells[3].Value.ToString();
            LabQualCB.SelectedItem = LabDGV.SelectedRows[0].Cells[4].Value.ToString();
            LabPhoneTB.Text = LabDGV.SelectedRows[0].Cells[5].Value.ToString();
            LabDOB.Text = LabDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (LabNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LabDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Patients Obj = new Patients();
            Obj.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Tests Obj = new Tests();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Result Obj = new Result();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
