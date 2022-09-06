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
    public partial class OverView : Form
    {
        public OverView()
        {
            InitializeComponent();
            Finance();
            Systemization();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=IMRAN\SQLEXPRESS; Initial Catalog=FarmFriends; Integrated Security=True;");
        private void Finance()
        {
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select sum(Amount) from IncomeTable", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            IncomeLabel.Text = "TK. " + dataTable.Rows[0][0].ToString();

            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select sum(Amount) from ExpenseTable", sqlConnection);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
            ExpLabel.Text = "TK. " + dataTable1.Rows[0][0].ToString();

            int income, expense;
            double balance;
            income = Convert.ToInt32(dataTable.Rows[0][0].ToString());
            expense = Convert.ToInt32(dataTable1.Rows[0][0].ToString());
            balance = income - expense;
            BalanceLabel.Text = "TK. " + balance;

            int profit;
            profit = (int)((balance * 100) / income);
            ProfitProgress.Text = "" + profit + "%";
            ProfitCircleBar.Value = (int)profit;
            sqlConnection.Close();
        }

        private void Systemization()
        {
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select count(*) from CowInfoTable", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            CowNumLbl.Text = dataTable.Rows[0][0].ToString();

            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select sum(Total_Milk) from MilkProductionTable", sqlConnection);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter1.Fill(dataTable1);
           // MilkLabel.Text = dataTable1.Rows[0][0].ToString() + " Ltrs.";

            SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("select sum(Quantity) from MilkSalesTable;", sqlConnection);
            DataTable dataTable5 = new DataTable();
            sqlDataAdapter5.Fill(dataTable5);
            //MilkLabel.Text = dataTable5.Rows[0][0].ToString() + " Ltrs.";

            double stock;
            int totalMilk = Convert.ToInt32(dataTable1.Rows[0][0].ToString());
            int quantity = Convert.ToInt32(dataTable5.Rows[0][0].ToString());
            stock = totalMilk - quantity;
            MilkLabel.Text = "Ltrs = " + stock;

            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select count(*) from EmployeeTable", sqlConnection);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            EnumLabel.Text = dataTable2.Rows[0][0].ToString();

            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("select Max(Amount) from IncomeTable", sqlConnection);
            DataTable dataTable3 = new DataTable();
            sqlDataAdapter3.Fill(dataTable3);
            SalesLbl.Text = "Tk " + dataTable3.Rows[0][0].ToString();

            SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("select Max(Amount) from ExpenseTable", sqlConnection);
            DataTable dataTable4 = new DataTable();
            sqlDataAdapter4.Fill(dataTable4);
            topexpense.Text = "Tk " + dataTable4.Rows[0][0].ToString();

            sqlConnection.Close();
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

        private void btnFinance_Click(object sender, EventArgs e)
        {
            Finance Ob = new Finance();
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
