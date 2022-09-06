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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "" || UserNameTextBox.Text == "")
            {
                MessageBox.Show("Please Select The Role");
            }
            else
            {
                if (RoleIdSelect.SelectedIndex > -1)
                {
                    if (RoleIdSelect.SelectedItem.ToString() == "Admin")
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("Select Count(*) from AdminTable where AdminName = '" + UserNameTextBox.Text + "' and AdminPassword = '" + passwordTextBox.Text + "'", sqlConnection);
                        DataTable dataTable1 = new DataTable();
                        sqlDataAdapter1.Fill(dataTable1);
                        if (dataTable1.Rows[0][0].ToString() == "1")
                        {
                            Employee ob = new Employee();
                            ob.Show();
                            this.Hide();
                            sqlConnection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong admin Name and Password");
                        }
                        sqlConnection.Close();
                    }
                    else
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select Count(*) from EmployeeTable where Name = '" + UserNameTextBox.Text + "' and Password = '" + passwordTextBox.Text + "'", sqlConnection);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows[0][0].ToString() == "1")
                        {
                            CowInfo ob = new CowInfo();
                            ob.Show();
                            this.Hide();
                            sqlConnection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong User Name and Password");
                        }
                        sqlConnection.Close();
                    }

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UserNameTextBox.Text = "";
            passwordTextBox.Text = "";
            RoleIdSelect.SelectedIndex = -1;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            OldPassword login = new OldPassword();
            login.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
