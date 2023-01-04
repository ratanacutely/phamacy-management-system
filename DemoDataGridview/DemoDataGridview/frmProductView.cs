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
    public partial class frmProductView : Form
    {
        private List<ClsCategory> Categories = new List<ClsCategory>();
        private List<ClsProduct> Products = new List<ClsProduct>();

        private IOManager iOManager = new IOManager();
        private string fileName = "category";
        private string productFileName = "product";
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            Categories = iOManager.Load<List<ClsCategory>>(fileName);
            if(Categories == null)
            {
                Categories = new List<ClsCategory>();
            }

            Products = iOManager.Load<List<ClsProduct>>(productFileName);
            if(Products != null)
            {
                //dgProduct.DataSource = Products;
                foreach(ClsProduct p in Products)
                {
                    string categoryName = "No name";
                    ClsCategory cate = Categories.Where(c => c.Id == p.Id).FirstOrDefault();
                    if(cate != null)
                    {
                        categoryName = cate.Name;
                    }
                    dgProduct.Rows.Add(p.Id, p.Name, categoryName, p.CostPrice, p.SellingPrice, p.Unit);
                }
            }
            else
            {
                Products = new List<ClsProduct>();
            }
        }
    }
}
