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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
            ShowPatients();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MedLabDBs;Integrated Security=True");
        private void ShowPatients()
        {
            Con.Open();
            string query = "SELECT * FROM PatientsTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            PatDGV.DataSource = ds.Tables[0];
            PatDGV.ReadOnly = true;


            Con.Close();


        }

        private void ResetValues()
        {
            PatNameTB.Text = "";
            PatAddressTB.Text = "";
            PatPhoneTB.Text = "";
            PatGenCB.SelectedIndex = -1;


        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (PatNameTB.Text == "" || PatAddressTB.Text == "" || PatPhoneTB.Text == "" || PatGenCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO PatientsTbl(PatName,PatGen,PatAddress,PatPhone,PatDOB) VALUES (@PN,@PG,@PA,@PP,@PD)", Con);
                    cmd.Parameters.AddWithValue("@PN", PatNameTB.Text);
                    cmd.Parameters.AddWithValue("@PG", PatGenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", PatAddressTB.Text);
                    cmd.Parameters.AddWithValue("@PP", PatPhoneTB.Text);
                    cmd.Parameters.AddWithValue("@PD", PatDOB.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient saved!");
                    Con.Close();
                    ShowPatients();
                    ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (PatNameTB.Text == "" || PatAddressTB.Text == "" || PatPhoneTB.Text == "" || PatGenCB.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose patient to update!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE PatientsTbl SET PatName = @PN,PatGen = @PG,PatAddress = @PA,PatPhone = @PP,PatDOB = @PD WHERE PatId = @PKey", Con);
                    cmd.Parameters.AddWithValue("@PN", PatNameTB.Text);
                    cmd.Parameters.AddWithValue("@PG", PatGenCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", PatAddressTB.Text);
                    cmd.Parameters.AddWithValue("@PP", PatPhoneTB.Text);
                    cmd.Parameters.AddWithValue("@PD", PatDOB.Value);
                    cmd.Parameters.AddWithValue("@PKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient updated!");
                    Con.Close();
                    ShowPatients();
                    ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;

        private void DelBTN_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Please choose patient to delete!");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM PatientsTbl WHERE PatId = @PKey", Con);
                cmd.Parameters.AddWithValue("@PKey", key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient deleted!");
                Con.Close();
                ShowPatients();
                ResetValues();

            }
        }

        private void PatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTB.Text = PatDGV.SelectedRows[0].Cells[1].Value.ToString();
            PatGenCB.SelectedItem = PatDGV.SelectedRows[0].Cells[2].Value.ToString();
            PatAddressTB.Text = PatDGV.SelectedRows[0].Cells[3].Value.ToString();
            PatPhoneTB.Text = PatDGV.SelectedRows[0].Cells[4].Value.ToString();
            PatDOB.Text = PatDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (PatNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
