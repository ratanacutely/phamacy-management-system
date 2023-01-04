using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDataGridview
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = count;
            count++;
            if(count >= 100)
            {
                timer1.Stop();
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }
    }
}
