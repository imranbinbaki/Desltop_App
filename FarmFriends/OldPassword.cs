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
    public partial class OldPassword : Form
    {
        public OldPassword()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");

        private void btnDone_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select Count(*) from AdminTable where AdminPassword = '" + OldpasswordTextBox.Text + "'", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows[0][0].ToString() == "1")
            {
                NewPassword ob = new NewPassword();
                ob.Show();
                this.Hide();
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
            sqlConnection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
