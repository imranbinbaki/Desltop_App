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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            FillEmpId();
            populateExp();
            populateIncome();
        }


        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");
        private void FillEmpId()
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select Emp_Id from EmployeeTable", sqlConnection);
            SqlDataReader sqlDataReader;
            sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Emp_Id", typeof(int));
            dataTable.Load(sqlDataReader);
            EmpIdSelect.ValueMember = "Emp_Id";
            EmpIdSelect.DataSource = dataTable;
            sqlConnection.Close();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PurposeSelect.SelectedIndex == -1 || AmountTextBox.Text == "" || EmpIdSelect.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into ExpenseTable values('" + DateTimePicker.Value.Date + "','" + PurposeSelect.SelectedItem.ToString() + "'," + AmountTextBox.Text + "," + EmpIdSelect.SelectedValue.ToString() + ")";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Saved Successfully");
                    sqlConnection.Close();
                    populateExp();
                    clearExp();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void clearExp()
        {
            AmountTextBox.Text = "";
        }

        private void populateExp()
        {
            sqlConnection.Open();
            string queryshow = "select * from ExpenseTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            expenseDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        private void populateExpFilter()
        {
            sqlConnection.Open();
            string queryshow = "select * from ExpenseTable where Exp_Date='" + FilterDateTimePicker.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            expenseDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        private void FilterDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            populateExpFilter();
        }

        private void RefreshBox_Click(object sender, EventArgs e)
        {
            populateExp();
        }

        private void BtnInSave_Click(object sender, EventArgs e)
        {
            if (InPurposeSelect.SelectedIndex == -1 || InAmount.Text == "" || EmpIdSelect.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into IncomeTable values('" + InDateTimePicker.Value.Date + "','" + InPurposeSelect.SelectedItem.ToString() + "'," + InAmount.Text + "," + EmpIdSelect.SelectedValue.ToString() + ")";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Income Saved Successfully");
                    sqlConnection.Close();
                    populateIncome();
                    clearIncome();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void clearIncome()
        {
            InPurposeSelect.SelectedIndex = -1;
            InAmount.Text = "";
        }
        private void populateIncome()
        {
            sqlConnection.Open();
            string queryshow = "select * from IncomeTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }
        private void populateIncomeFilter()
        {
            sqlConnection.Open();
            string queryshow = "select * from IncomeTable where IncDate='" + IncomeDatetime.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        private void IncomeDatetime_ValueChanged(object sender, EventArgs e)
        {
            populateIncomeFilter();
        }

        private void InRefresh_Click(object sender, EventArgs e)
        {
            populateIncome();
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

        private void btnHealth_Click(object sender, EventArgs e)
        {
            Health Ob = new Health();
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
