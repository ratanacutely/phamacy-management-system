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
    public partial class frmPOS : Form
    {


        private IOManager iOManager = new IOManager();
        private POSUtil util = new POSUtil();
        public frmPOS()
        {
            InitializeComponent();
        }


        private POSManager mgt;
        private void frmPOS_Load(object sender, EventArgs e)
        {
            mgt = POSManager.GetInstance();

            foreach (ClsProduct p in mgt.Products)
                cmbProduct.Items.Add(p.Name);
            foreach(ClsCustomer c in mgt.Customers)
                cmbCustomer.Items.Add(c.Name);
            foreach(ClsEmployee c in mgt.Employees)
                cmbEmployee.Items.Add(c.Name);

            //util.InsertStockSampleData(Products, stockFileName);

            ClearAll();
        }

        private int GetInvoiceId()
        {
            ClsSaleSummaries sale = mgt.SaleSummaries.OrderByDescending(s => s.InvoiceId).FirstOrDefault();
            if(sale != null)
                return sale.InvoiceId + 1;
            return 1;
        }
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proName = cmbProduct.Text;
            ClsProduct prod = mgt.Products.Where(p => p.Name == proName).FirstOrDefault();
            if (prod != null)
            {
                int defaultUnit = 1;
                txtCostPrice.Text = prod.SellingPrice.ToString();
                lblUnit.Text = prod.Unit.ToString();
                txtQuantity.Text = defaultUnit.ToString();
                txtTotalPrice.Text = (prod.SellingPrice * defaultUnit).ToString();

                ClsStock stock = mgt.Stocks.Where(s => s.ProductId == prod.Id).FirstOrDefault();
                if(stock != null)
                    lblStock.Text = stock.Quantity.ToString();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
                return;

            int qty = int.Parse(txtQuantity.Text);
            string proName = cmbProduct.Text;
            ClsProduct prod = mgt.Products.Where(p => p.Name == proName).FirstOrDefault();
            if (prod != null)
            {
                double totalPrice = qty * prod.SellingPrice;
                txtTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void Clear()
        {
            cmbProduct.Text = "";
            txtCostPrice.Text = "0";
            txtQuantity.Text = "0";
            txtTotalPrice.Text = "0";
            lblUnit.Text = "";
            lblStock.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private List<ClsSaleItem> Sales = new List<ClsSaleItem>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClsSaleItem item = new ClsSaleItem();

            //if(!new ValidSaleItem().isValid(cmbProduct.Text,txtQuantity.Text))
            //{
            //    return;
            //}

            item.ProductName = cmbProduct.Text;
            item.Price = double.Parse(txtCostPrice.Text);
            item.Quantity = int.Parse(txtQuantity.Text);
            item.TotalPrice = double.Parse(txtTotalPrice.Text);
            item.Unit = lblUnit.Text;

            Sales.Add(item);
            AddToDataGridView();
            Clear();
        }

        private void AddToDataGridView()
        {
            dgvItem.Rows.Clear();
            int no = 1;
            foreach(ClsSaleItem item in Sales)
            {
                dgvItem.Rows.Add(no,
                                item.ProductName,
                                item.Quantity,
                                item.Price,
                                item.TotalPrice,
                                item.Unit);
                no++;
            }
        }

        private void Remove()
        {
            if (dgvItem.SelectedRows.Count > 0)
            {
                string prodName = dgvItem.SelectedRows[0].Cells[1].Value.ToString();
                for (int i = 0; i < Sales.Count; i++)
                {
                    ClsSaleItem sale = Sales[i];
                    if (sale.ProductName == prodName)
                    {
                        Sales.Remove(sale);
                    }
                }

                AddToDataGridView();
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void dgvItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Remove();
        }


        private void ClearAll()
        {
            cmbCustomer.Text = "";
            //cmbEmployee.Text = "";
            if(mgt.employee != null)
            {
                cmbEmployee.Text = mgt.employee.Name;
            }

            Clear();
            dgvItem.Rows.Clear();
            Sales.Clear();

            txtInvoiceId.Text = GetInvoiceId().ToString();
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dgvItem.Rows.Count <= 0)
            {
                MessageBox.Show("please add some items");
            }

            //save sale summaries
            ClsSaleSummaries sale = new ClsSaleSummaries();
            sale.InvoiceId = GetInvoiceId();
            sale.EmployeeId= GetEmployeeId();
            sale.CustomerId= GetCustomerId();
            sale.TotalPrice = GetTotalPrice();
            mgt.SaleSummaries.Add(sale);
            iOManager.Save(mgt.SaleSummaries, mgt.saleSummariesFileName);

            //save sale detail
            foreach(ClsSaleItem item in Sales)
            {
                ClsSaleDetail sd = new ClsSaleDetail();
                sd.InvoiceId = sale.InvoiceId;
                sd.ProductId = GetProductId(item.ProductName);
                sd.Quantity = item.Quantity;
                sd.Price = item.Price;
                sd.TotalPrice = item.TotalPrice;
                mgt.SaleDetails.Add(sd);
            }
            iOManager.Save(mgt.SaleDetails, mgt.saleDetailFileName);

            //update stock
            foreach(ClsSaleItem item in Sales)
            {
                int productId = GetProductId(item.ProductName);
                ClsStock stock = mgt.Stocks.Where(s => s.ProductId == productId).FirstOrDefault();
                if (stock != null)
                    stock.Quantity -= item.Quantity;
            }
            iOManager.Save(mgt.Stocks, mgt.stockFileName);

            MessageBox.Show("saved!");
            ClearAll();
        }

        private int GetProductId(string name)
        {
            ClsProduct prod = mgt.Products.Where( p => p.Name == name).FirstOrDefault();
            if (prod != null)
                return prod.Id;
            return -1;
        }
        private double GetTotalPrice()
        {
            double totalPriceAllProduct = 0;
            foreach(ClsSaleItem item in Sales)
            {
                totalPriceAllProduct += item.TotalPrice;
            }
            return totalPriceAllProduct;
        }
        private int GetEmployeeId()
        {
            ClsEmployee emp = mgt.Employees.Where(e => e.Name == cmbEmployee.Text).FirstOrDefault();
            if(emp != null)
                return emp.Id;
            return -1;
        }
        private int GetCustomerId()
        {
            ClsCustomer cus = mgt.Customers.Where(c => c.Name== cmbCustomer.Text).FirstOrDefault();
            if (cus != null)
                return cus.ID;
            return -1;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmSaleView view = new frmSaleView();
            view.pos = this;
            view.ShowDialog();
        }

        public void RefreshPosUI(int invoiceId)
        {
            ClearAll();
            var sds = mgt.SaleDetails.Where(sd => sd.InvoiceId == invoiceId);
            if(sds !=null)
            {
                foreach(var sd in sds)
                {
                    ClsSaleItem item = new ClsSaleItem();
                    item.ProductName = GetProductName(sd.ProductId);
                    item.Quantity = sd.Quantity;
                    item.Price= sd.Price;
                    item.TotalPrice = sd.TotalPrice;
                    item.Unit = GetProductUnit(sd.ProductId);
                    Sales.Add(item);
                }
            }
            AddToDataGridView();
        }

        private string GetProductUnit(int id)
        {
            ClsProduct prod = mgt.Products.Where(p => p.Id == id).FirstOrDefault();
            if (prod != null)
                return prod.Unit;
            return "";
        }
        private string GetProductName(int id)
        {
            ClsProduct prod = mgt.Products.Where(p => p.Id == id).FirstOrDefault();
            if (prod != null)
                return prod.Name;
            return "";
        }
    }
}
