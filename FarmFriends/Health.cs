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

namespace FarmFriends
{
    public partial class Health : Form
    {
        public Health()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");

        private void FillCowId()
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select Cow_Id from CowInfoTable", sqlConnection);
            SqlDataReader sqlDataReader;
            sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Cow_Id", typeof(int));
            dataTable.Load(sqlDataReader);
            CowIdSelect.ValueMember = "Cow_Id";
            CowIdSelect.DataSource = dataTable;
            sqlConnection.Close();

        }

        private void GetCowName()
        {
            sqlConnection.Open();
            string query = "select * from CowInfoTable where Cow_Id=" + CowIdSelect.SelectedValue.ToString() + "";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                CowNameTextBox.Text = dataRow["Cow_Name"].ToString();
            }
            sqlConnection.Close();
        }

        private void CowIdSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CowIdSelect.SelectedIndex == -1 || CowNameTextBox.Text == "" || DieaseTextBox.Text == "" || CostTextBox.Text == "" || TreatByTextBox1.Text == "" || treatmentTextBox.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into HealthTable values(" + CowIdSelect.SelectedValue.ToString() + ",'" + CowNameTextBox.Text + "','" + DateTimePicker.Value.Date + "','" + DieaseTextBox.Text + "','" + treatmentTextBox.Text + "'," + CostTextBox.Text + ",'" + TreatByTextBox1.Text + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("health Info saved");
                    sqlConnection.Close();
                    populate();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void populate()
        {
            sqlConnection.Open();
            string queryshow = "select * from HealthTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            healthDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        int key = 0;
        private void healthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdSelect.SelectedValue = healthDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTextBox.Text = healthDGV.SelectedRows[0].Cells[2].Value.ToString();
            DateTimePicker.Text = healthDGV.SelectedRows[0].Cells[3].Value.ToString();
            DieaseTextBox.Text = healthDGV.SelectedRows[0].Cells[4].Value.ToString();
            treatmentTextBox.Text = healthDGV.SelectedRows[0].Cells[5].Value.ToString();
            CostTextBox.Text = healthDGV.SelectedRows[0].Cells[6].Value.ToString();
            TreatByTextBox1.Text = healthDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTextBox.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(healthDGV.SelectedRows[0].Cells[0].Value.ToString());


            }
            btnSave.Enabled = false;
        }

        private void clear()
        {
            CowNameTextBox.Text = "";
            DieaseTextBox.Text = "";
            CostTextBox.Text = "";
            TreatByTextBox1.Text = "";
            treatmentTextBox.Text = "";
            key = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please select Report to be deleted");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "delete from HealthTable where Report_Id = " + key + ";";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Report Deleted Successfully");
                    sqlConnection.Close();
                    populate();
                    clear();
                    btnSave.Enabled = true;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CowIdSelect.SelectedIndex == -1 || CowNameTextBox.Text == "" || DieaseTextBox.Text == "" || CostTextBox.Text == "" || TreatByTextBox1.Text == "" || treatmentTextBox.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "update HealthTable set Cow_Id=" + CowIdSelect.SelectedValue.ToString() + ", Cow_Name='" + CowNameTextBox.Text + "',Date='" + DateTimePicker.Value.Date + "',Diease='" + DieaseTextBox.Text + "',Treatment='" + treatmentTextBox.Text + "',Cost=" + CostTextBox.Text + ",Doctor_Name='" + TreatByTextBox1.Text + "' where Report_Id =" + key + ";";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Report Updated Successfully");
                    sqlConnection.Close();
                    populate();
                    clear();
                    btnSave.Enabled = true;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CowInfo Ob = new CowInfo();
            Ob.Show();
            this.Hide();
        }

        private void btnMilkProduction_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void btnBreeding_Click(object sender, EventArgs e)
        {
            Breed Ob = new Breed();
            Ob.Show();
            this.Hide();
        }

        private void btnMilkSales_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            Finance Ob = new Finance();
            Ob.Show();
            this.Hide();
        }

        private void btnOverView_Click(object sender, EventArgs e)
        {
            OverView Ob = new OverView();
            Ob.Show();
            this.Hide();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About Ob = new About();
            Ob.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
