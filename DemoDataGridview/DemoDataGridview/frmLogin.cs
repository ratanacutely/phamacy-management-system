using DemoDataGridview.Model;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            POSManager mgt = POSManager.GetInstance();
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            ClsEmployee emp = mgt.Employees.Where(ee => ee.Name == username).FirstOrDefault();
            if(emp != null)
            {
                POSManager.GetInstance().employee = emp;
                main.Show();
                this.Close();
            }
            
        }
    }
}
