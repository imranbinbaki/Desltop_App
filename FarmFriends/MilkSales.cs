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
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            FillEmpId();
            populate();
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

        private void QuantityTextBox_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(PriceTextBox.Text) * Convert.ToInt32(QuantityTextBox.Text);
            TotalTextBox1.Text = "" + total;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EmpIdSelect.SelectedIndex == -1 || PriceTextBox.Text == "" || ClientNameTextBox.Text == "" || PhoneTextBox.Text == "" || QuantityTextBox.Text == "" || TotalTextBox1.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    string query = "insert into MilkSalesTable values('" + DateTimePicker.Value.Date + "'," + PriceTextBox.Text + ",'" + ClientNameTextBox.Text + "','" + PhoneTextBox.Text + "'," + EmpIdSelect.SelectedValue.ToString() + "," + QuantityTextBox.Text + "," + TotalTextBox1.Text + ")";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Milk Sold Successfully");
                    sqlConnection.Close();
                    populate();
                    SaveTransaction();
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
            string queryshow = "select * from MilkSalesTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryshow, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalesDGV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        }

        private void clear()
        {
            PriceTextBox.Text = "";
            QuantityTextBox.Text = "";
            ClientNameTextBox.Text = "";
            PhoneTextBox.Text = "";
            TotalTextBox1.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void SalesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrintText.Text = "";
            PrintText.Text = "                          Farm Friends\n\n" + "                           Sales Details                           " + "\n --------------------------------------------------------------" + "\n\n\n             Customer Name : " + SalesDGV.SelectedRows[0].Cells[3].Value.ToString() + "\n             Phone : " + SalesDGV.SelectedRows[0].Cells[4].Value.ToString() + "\n             Today's Price : " + SalesDGV.SelectedRows[0].Cells[2].Value.ToString() + "\n             Quantity : " + SalesDGV.SelectedRows[0].Cells[6].Value.ToString() + "Ltrs" + "\n             Total : " + SalesDGV.SelectedRows[0].Cells[7].Value.ToString() + " Taka" + "\n\n\n-------------------Thanks for coming-------------------";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(PrintText.Text + "\n", new Font("Averia", 18, FontStyle.Regular), Brushes.Black, new Point(95, 80));
            // e.Graphics.DrawString( "\n\t"+"thanks", new Font("Averia", 15, FontStyle.Bold), Brushes.Red, new Point(200, 300));
        }

        private void SaveTransaction()
        {

            {
                try
                {
                    string Sales = "sales";
                    sqlConnection.Open();
                    string query = "insert into IncomeTable values('" + DateTimePicker.Value.Date + "','" + Sales + "'," + TotalTextBox1.Text + "," + EmpIdSelect.SelectedValue.ToString() + ")";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Income Saved Successfully");
                    sqlConnection.Close();
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
