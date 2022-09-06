using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmFriends
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
        int start_pos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            start_pos += 1;
            CircleProgressBar1.Value = start_pos;
            if (CircleProgressBar1.Value == 100)
            {
                CircleProgressBar1.Value = 0;
                timer1.Stop();
                Login cow = new Login();
                cow.Show();
                this.Hide();
            }

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
