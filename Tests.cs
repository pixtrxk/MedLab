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
    public partial class Tests : Form
    {
        public Tests()
        {
            InitializeComponent();
            ShowTests();
            ResetValues();
        }

        SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
        private void ShowTests()
        {
            Con.Open();
            string query = "SELECT * FROM TestsTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            TestDGV.DataSource = ds.Tables[0];
            TestDGV.ReadOnly = true;

            Con.Close();
        }
        private void ResetValues()
        {
            TestNameTB.Text = "";
            TestCostTB.Text = "";
            key = 0;           
        }


        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (TestNameTB.Text == "" || TestCostTB.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TestsTbl(TestName, TestCost) VALUES (@TN,@TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", TestNameTB.Text);
                    cmd.Parameters.AddWithValue("@TC", TestCostTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test saved!");
                    Con.Close();
                    ShowTests();
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
                MessageBox.Show("Please choose test to update!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE TestsTbl SET TestName = @TN, TestCost = @TC WHERE TestCode = @Tkey", Con);
                    cmd.Parameters.AddWithValue("@TN", TestNameTB.Text);
                    cmd.Parameters.AddWithValue("@TC", TestCostTB.Text);
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test saved!");
                    Con.Close();
                    ShowTests();
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
                MessageBox.Show("Please choose test to delete!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM TestsTbl WHERE TestCode = @Tkey", Con);
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test deleted!");
                    Con.Close();
                    ShowTests();
                    ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TestDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TestNameTB.Text = TestDGV.SelectedRows[0].Cells[1].Value.ToString();
            TestCostTB.Text = TestDGV.SelectedRows[0].Cells[2].Value.ToString();

            if(TestNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Laboratorians Obj = new Laboratorians();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Patients Obj = new Patients();
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
