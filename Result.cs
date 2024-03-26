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
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace MedLab
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
            GetPatient();
            GetLabor();
            GetTest();
            ShowResults();
            //ResetValues();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=MedLabDBs;Integrated Security=True");
        private void ShowResults()
        {
            Con.Open();
            string query = "SELECT * FROM ResultsTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            ResDGV.DataSource = ds.Tables[0];
            ResDGV.ReadOnly = true;
            Con.Close();
        }
        private void ResetValues()
        {
            PatIdCB.SelectedIndex = -1; 
            LabIdCB.SelectedIndex = -1;
            TestCodeCB.SelectedIndex = -1;
            ResCB.SelectedIndex = -1;
            PatNameTB.Text = "";
            LabNameTB.Text = "";
            TestNameTB.Text = "";
            TestTB.Text = "";
            TestCostTB.Text = "";
            


        }
        private void GetPatient()
        {
            Con.Open();
            string query = "SELECT PatId FROM PatientsTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            PatIdCB.ValueMember = "PatId";
            PatIdCB.DataSource = dt;
            Con.Close();
        }
        private void GetLabor()
        {
            Con.Open();
            string query = "SELECT LabId FROM LaboratoriansTbl";
            SqlCommand cmd = new SqlCommand(query,Con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            LabIdCB.ValueMember = "LabId";
            LabIdCB.DataSource = dt;
            Con.Close();
        }
        private void GetTest()
        {
            Con.Open();
            string query = "SELECT TestCode FROM TestsTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            TestCodeCB.ValueMember = "TestCode";
            TestCodeCB.DataSource = dt;
            Con.Close();
        }
        private void GetPatientName()
        {


            using (SqlCommand cmd = new SqlCommand("SELECT PatName FROM PatientsTbl WHERE PatId = @PatId", Con))
            {
                cmd.Parameters.AddWithValue("@PatId", PatIdCB.SelectedValue.ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                PatNameTB.Text = dt.Rows[0]["PatName"].ToString();
            }
            
                    
        }
        private void GetLaborName()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT LabName FROM LaboratoriansTbl WHERE LabId = @LabId", Con))
            {
                cmd.Parameters.AddWithValue("@LabId", LabIdCB.SelectedValue.ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                LabNameTB.Text = dt.Rows[0]["LabName"].ToString();
            }                        
        }
        private void GetTestName()
        {

            using (SqlCommand cmd = new SqlCommand("SELECT TestName, TestCost FROM TestsTbl WHERE TestCode = @TestCode", Con))
            {
                cmd.Parameters.AddWithValue("@TestCode", TestCodeCB.SelectedValue.ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                TestNameTB.Text = dt.Rows[0]["TestName"].ToString();
                TestCostTB.Text = dt.Rows[0]["TestCost"].ToString();
            }
                           
        }
      
        private void label2_Click(object sender, EventArgs e)
        {

        }

        int key = 0;
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (PatIdCB.SelectedIndex == -1 || LabIdCB.SelectedIndex == -1 || TestCodeCB.SelectedIndex == -1 || ResCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ResultsTbl(PatId, PatName, LaborId, LaborName, TestResult, TestCode, TestCost) VALUES (@PI,@PN, @LI, @LN, @TR, @TCod, @TCos)", Con);
                    cmd.Parameters.AddWithValue("@PI", PatIdCB.SelectedValue);
                    cmd.Parameters.AddWithValue("@PN", PatNameTB.Text);
                    cmd.Parameters.AddWithValue("@LI", LabIdCB.SelectedValue);
                    cmd.Parameters.AddWithValue("@LN", LabNameTB.Text);
                    cmd.Parameters.AddWithValue("@TR", TestTB.Text);
                    cmd.Parameters.AddWithValue("@TCod", TestCodeCB.SelectedValue);
                    cmd.Parameters.AddWithValue("@TCos", TestCostTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Result saved!");
                    Con.Close();
                    ShowResults();
                   // ResetValues();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
      
        private void PatIdCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPatientName();
        }

        private void LabIdCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLaborName();           
        }
              
        private void TestCodeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTestName();         
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            if(TestCodeCB.SelectedIndex == -1 || ResCB.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose both test code and its result");
            }
            else
            {
                TestTB.Text = TestNameTB.Text + " : " + ResCB.SelectedItem.ToString();
            }
        }

        private void ResDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatIdCB.SelectedItem = ResDGV.SelectedRows[0].Cells[1].Value.ToString();
            PatNameTB.Text = ResDGV.SelectedRows[0].Cells[2].Value.ToString();
            LabIdCB.SelectedItem = ResDGV.SelectedRows[0].Cells[3].Value.ToString();
            LabNameTB.Text = ResDGV.SelectedRows[0].Cells[4].Value.ToString();
            TestTB.Text = ResDGV.SelectedRows[0].Cells[5].Value.ToString();
            TestCodeCB.SelectedItem = ResDGV.SelectedRows[0].Cells[6].Value.ToString();
            TestCostTB.Text = ResDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (PatIdCB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ResDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DelBTN_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please choose patient to delete!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ResultsTbl WHERE ResultNum = @RKey", Con);
                    cmd.Parameters.AddWithValue("@RKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Result deleted!");
                    Con.Close();
                    ShowResults();
                    //ResetValues();
                }
                catch(Exception Ex) 
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
    }
}
