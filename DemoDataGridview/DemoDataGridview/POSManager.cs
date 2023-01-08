using DemoDataGridview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview
{
    //singleton parttern
    public class POSManager
    {
        private static POSManager instance = null;

        public ClsEmployee employee;

        private POSManager() { }

        public static POSManager GetInstance()
        {
            if(instance == null)
            {
                instance = new POSManager();
                instance.Init();
            }
            return instance;
        }

        //category
        public string categoryfileName = "category";
        public List<ClsCategory> Categories = new List<ClsCategory>();

        //product
        public string productFileName = "product";
        public List<ClsProduct> Products = new List<ClsProduct>();

        //customer
        public string customerFileName = "customer";
        public List<ClsCustomer> Customers = new List<ClsCustomer>();

        //employee
        public string employeeFileName = "employee";
        public List<ClsEmployee> Employees = new List<ClsEmployee>();

        //sale-summaries
        public string saleSummariesFileName = "sale";
        public List<ClsSaleSummaries> SaleSummaries = new List<ClsSaleSummaries>();

        //sale-details
        public string saleDetailFileName = "sale_detail";
        public List<ClsSaleDetail> SaleDetails = new List<ClsSaleDetail>();

        //stock
        public string stockFileName = "stock";
        public List<ClsStock> Stocks = new List<ClsStock>();

        public IOManager iOManager = new IOManager();
        public POSUtil util = new POSUtil();

        private void Init()
        {
            Categories = iOManager.Load<List<ClsCategory>>(categoryfileName);

            Products = util.LoadProduct(productFileName);
            Customers = util.LoadCustomer(customerFileName);
            Employees = util.LoadEmployee(employeeFileName);

            SaleSummaries = util.LoadSaleSummaries(saleSummariesFileName);
            SaleDetails = util.LoadSaleDetails(saleDetailFileName);
            Stocks = util.LoadStocks(stockFileName);
        }
    }
}
