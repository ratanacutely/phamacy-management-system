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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuCategory_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.Show();
        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            product.Show();
        }

        private void menuPOS_Click(object sender, EventArgs e)
        {
            frmPOS pos = new frmPOS();
            pos.WindowState = FormWindowState.Maximized;
            pos.Show();
        }
    }
}
