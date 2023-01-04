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
    public partial class frmProduct : Form
    {
        private List<ClsCategory> Categories = new List<ClsCategory>();
        private List<ClsProduct> Products = new List<ClsProduct>();

        private IOManager iOManager = new IOManager();
        private string fileName = "category";
        private string productFileName = "product";

        public frmProduct()
        {
            InitializeComponent();
        }



        private void frmProduct_Load(object sender, EventArgs e)
        {
            Categories = iOManager.Load<List<ClsCategory>>(fileName);
            if (Categories == null)
            {
                Categories = new List<ClsCategory>();
            }

            foreach(ClsCategory category in Categories)
            {
                cmbCategory.Items.Add(category.Name);
            }

            Products = iOManager.Load<List<ClsProduct>>(productFileName);
            if(Products == null)
            {
                Products = new List<ClsProduct>();
            }

            Clear();
        }

        private int getId()
        {
            ClsProduct product = Products.OrderByDescending(x => x.Id).FirstOrDefault();
            if(product != null)
            {
                return product.Id + 1;
            }
            return 1;
        }
        private void Clear()
        {
            txtId.Text = getId().ToString();
            txtName.Text = "";
            cmbCategory.Text = "";
            txtCostPrice.Text = "0";
            txtSellingPrice.Text= "0";
            txtUnit.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            int categoryId = -1;
            string categoryName = cmbCategory.Text;
            ClsCategory cate = Categories.Where(c => c.Name == categoryName).FirstOrDefault();
            if(cate != null)
            {
                categoryId = cate.Id;
            }
            double costPrice = double.Parse(txtCostPrice.Text);
            double sellingPrice = double.Parse(txtSellingPrice.Text);
            string unit = txtUnit.Text;

            ClsProduct product = new ClsProduct(id,name,categoryId,costPrice, sellingPrice,unit);
            Products.Add(product);
            iOManager.Save(Products, productFileName);
            MessageBox.Show("product added!");
            Clear();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            //txtName.Text = "";
            //txtName.ForeColor = Color.Black;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            //txtName.Text = "Product Name";
            //txtName.ForeColor = Color.DarkGray;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmProductView pView = new frmProductView();
            pView.ShowDialog();
        }
    }
}
