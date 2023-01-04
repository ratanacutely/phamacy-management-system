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
    public partial class frmCategoryView : Form
    {
        private List<ClsCategory> Categories = new List<ClsCategory>();
        private IOManager iOManager = new IOManager();
        private string fileName = "category";

        public frmCategory frmCategory;
        public frmCategoryView()
        {
            InitializeComponent();
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            Categories = iOManager.Load<List<ClsCategory>>(fileName);
            if (Categories == null)
            {
                Categories = new List<ClsCategory>();
            }

            dgCategory.DataSource = Categories;
        }

        private void dgCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgCategory.SelectedRows.Count > 0)
            {
                int categoryId = (int)dgCategory.SelectedRows[0].Cells[0].Value;
                frmCategory.RefreshCategoryById(categoryId);
                this.Close();
            }
        }
    }
}
