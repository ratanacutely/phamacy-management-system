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
    public partial class frmSaleView : Form
    {
        //load sale summaries
        private string saleSummariesFileName = "sale";
        private List<ClsSaleSummaries> SaleSummaries = new List<ClsSaleSummaries>();
        
        //customer
        private string customerFileName = "customer";
        private List<ClsCustomer> Customers = new List<ClsCustomer>();

        //employee
        private string employeeFileName = "employee";
        private List<ClsEmployee> Employees = new List<ClsEmployee>();

        public frmPOS pos;

        private POSUtil util = new POSUtil();
        public frmSaleView()
        {
            InitializeComponent();
        }

        private void frmSaleView_Load(object sender, EventArgs e)
        {
            SaleSummaries = util.LoadSaleSummaries(saleSummariesFileName);
            Customers = util.LoadCustomer(customerFileName);
            Employees = util.LoadEmployee(employeeFileName);

            foreach (ClsSaleSummaries s in SaleSummaries)
            {
                int invoiceId = s.InvoiceId;
                string customerName = GetCustomerName(s.CustomerId);
                string employeeName = GetEmployeeName(s.EmployeeId);
                double totalPrice = s.TotalPrice;

                dgvSaleHistory.Rows.Add(invoiceId, customerFileName, employeeFileName, totalPrice);
            }
        }

        private string GetCustomerName(int id)
        {
            ClsCustomer cus = Customers.Where( c => c.ID == id).FirstOrDefault();
            if(cus!=null)
                return cus.Name;
            return "";
        }

        private string GetEmployeeName(int id)
        {
            ClsEmployee emp = Employees.Where(e => e.Id == id).FirstOrDefault();
            if(emp != null) 
                return emp.Name;
            return "";
        }

        private void dgvSaleHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvSaleHistory.SelectedRows.Count > 0)
            {
                int invoiceId = (int)dgvSaleHistory.SelectedRows[0].Cells[0].Value;
                pos.RefreshPosUI(invoiceId);
                this.Close();
            }
        }
    }
}
