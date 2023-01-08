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
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            POSManager mgt = POSManager.GetInstance();
            if(mgt.Products != null)
            {
                //dgProduct.DataSource = Products;
                foreach(ClsProduct p in mgt.Products)
                {
                    string categoryName = "No name";
                    ClsCategory cate = mgt.Categories.Where(c => c.Id == p.CategoryId).FirstOrDefault();
                    if(cate != null)
                    {
                        categoryName = cate.Name;
                    }
                    dgProduct.Rows.Add(p.Id, p.Name, categoryName, p.CostPrice, p.SellingPrice, p.Unit);
                }
            }
        }
    }
}
