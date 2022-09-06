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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EmpNameTextBox.Text == "" || GenderSelect.SelectedIndex == -1 || PhoneTextBox.Text == "" || AddressTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into EmployeeTable values('" + EmpNameTextBox.Text + "','" + DateTimePicker.Value.Date + "','" + GenderSelect.SelectedItem.ToString() + "','" + PhoneTextBox.Text + "','" + AddressTextBox.Text + "','" + PasswordTextBox.Text + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved Successfully");
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
            string queryshow = "select * from EmployeeTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            empDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        int key = 0;
        private void empDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTextBox.Text = empDGV.SelectedRows[0].Cells[1].Value.ToString();
            DateTimePicker.Text = empDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderSelect.SelectedItem = empDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTextBox.Text = empDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTextBox.Text = empDGV.SelectedRows[0].Cells[5].Value.ToString();
            PasswordTextBox.Text = empDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (EmpNameTextBox.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(empDGV.SelectedRows[0].Cells[0].Value.ToString());


            }
            btnSave.Enabled = false;
        }

        private void clear()
        {
            PhoneTextBox.Text = "";
            EmpNameTextBox.Text = "";
            AddressTextBox.Text = "";
            GenderSelect.SelectedIndex = -1;
            key = 0;
            PasswordTextBox.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please select the Employee to be deleted");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "delete from EmployeeTable where Emp_Id = " + key + ";";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
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
            if (EmpNameTextBox.Text == "" || GenderSelect.SelectedIndex == -1 || PhoneTextBox.Text == "" || AddressTextBox.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "update EmployeeTable set Name='" + EmpNameTextBox.Text + "',DOB='" + DateTimePicker.Value.Date + "',Gender='" + GenderSelect.SelectedItem.ToString() + "',Phone='" + PhoneTextBox.Text + "',Address='" + AddressTextBox.Text + "',Password='" + PasswordTextBox.Text + "' where Emp_Id=" + key + ";";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
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

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
