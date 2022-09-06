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
    public partial class CowInfo : Form
    {
        public CowInfo()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");

        
        int age = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cowNameTextBox.Text == "" || EarTagTextBox.Text == "" || ColorTextBox.Text == "" || BreedTextBox.Text == "" || WeightTextBox.Text == "" || AgeTextBox.Text == "" || FieldNameTextBox.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into CowInfoTable values('" + cowNameTextBox.Text + "','" + EarTagTextBox.Text + "','" + ColorTextBox.Text + "','" + BreedTextBox.Text + "'," + age + ",'" + WeightTextBox.Text + "','" + FieldNameTextBox.Text + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cow Info Saved Successfully");
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
            string queryshow = "select * from CowInfoTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            cowDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }


        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DateTimePicker.Value.Date).Days) / 365;

        }

        private void DateTimePicker_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DateTimePicker.Value.Date).Days) / 365;
            //age = Convert.ToInt32((DOBTb.Value.Date - DateTime.Today.Date).Days)/365;
            AgeTextBox.Text = "" + age;
        }

        private void clear()
        {
            cowNameTextBox.Text = "";
            EarTagTextBox.Text = "";
            ColorTextBox.Text = "";
            BreedTextBox.Text = "";
            WeightTextBox.Text = "";
            AgeTextBox.Text = "";
            FieldNameTextBox.Text = "";
            cowNameTextBox.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
        }

        int key = 0;
        private void cowDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cowNameTextBox.Text = cowDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTextBox.Text = cowDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTextBox.Text = cowDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTextBox.Text = cowDGV.SelectedRows[0].Cells[4].Value.ToString();
            WeightTextBox.Text = cowDGV.SelectedRows[0].Cells[6].Value.ToString();
            FieldNameTextBox.Text = cowDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (cowNameTextBox.Text == "")
            {
                key = 0;
                age = 0;
            }
            else
            {
                key = Convert.ToInt32(cowDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(cowDGV.SelectedRows[0].Cells[5].Value.ToString());

            }
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please select the cow to be deleted");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "delete from CowInfoTable where Cow_Id = " + key + ";";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cow Deleted Successfully");
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
            if (cowNameTextBox.Text == "" || EarTagTextBox.Text == "" || ColorTextBox.Text == "" || BreedTextBox.Text == "" || WeightTextBox.Text == "" || AgeTextBox.Text == "" || FieldNameTextBox.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "update CowInfoTable set Cow_Name='" + cowNameTextBox.Text + "',Ear_Tag='" + EarTagTextBox.Text + "',Color='" + ColorTextBox.Text + "',Breed='" + BreedTextBox.Text + "',Age='" + age + "',Weight_At_Birth='" + WeightTextBox.Text + "',Field_Name='" + FieldNameTextBox.Text + "'where Cow_Id=" + key + ";";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cow Info Updated Successfully");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
