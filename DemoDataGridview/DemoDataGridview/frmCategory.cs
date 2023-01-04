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
    public partial class frmCategory : Form
    {
        private List<ClsCategory> Categories= new List<ClsCategory>();
        private IOManager iOManager = new IOManager();
        private string fileName = "category";
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            Categories = iOManager.Load<List<ClsCategory>>(fileName);
            if(Categories == null )
            {
                Categories= new List<ClsCategory>();
            }

            Clear();
        }

        public int getId()
        {
            ClsCategory cate = Categories.OrderByDescending(c => c.Id).FirstOrDefault();
            if(cate != null )
            {
                return cate.Id + 1;
            }
            return 1;
        }
        private void Clear()
        {
            txtId.Text = getId().ToString();
            txtName.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("please input category name");
                return;
            }

            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            ClsCategory category = new ClsCategory(id, name);
            ClsCategory temp = Categories.Where(c => c.Name == category.Name).FirstOrDefault();
            if(temp == null) 
            {
                Categories.Add(category);

                iOManager.Save(Categories, fileName);
                MessageBox.Show("added!");
                Clear();
            }
            else
            {
                MessageBox.Show("category name already exist");
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            frmCategoryView catView = new frmCategoryView();
            catView.frmCategory = this;
            catView.ShowDialog();
        }

        public void RefreshCategoryById(int categoryId)
        {
            ClsCategory temp = Categories.Where(c => c.Id == categoryId).FirstOrDefault(); ;
            if(temp!= null)
            {
                txtId.Text = temp.Id.ToString();
                txtName.Text = temp.Name;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int catId = int.Parse(txtId.Text);
            ClsCategory cate = Categories.Where(c => c.Id== catId).FirstOrDefault();
            if(cate!= null)
            {
                cate.Name= txtName.Text;
                iOManager.Save(Categories, fileName);
                MessageBox.Show("updated!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int catId = int.Parse(txtId.Text);
            ClsCategory cate = Categories.Where(c => c.Id == catId).FirstOrDefault();
            if (cate != null)
            {
                Categories.Remove(cate);
                iOManager.Save(Categories, fileName);
                MessageBox.Show("removed!");
                Clear();
            }
        }
    }
}
