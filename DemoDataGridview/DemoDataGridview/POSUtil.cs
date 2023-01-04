using DemoDataGridview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview
{
    public class POSUtil
    {
        private IOManager iOManager = new IOManager();
        public List<ClsEmployee> LoadEmployee(string employeeFileName)
        {
            List<ClsEmployee> Employees = iOManager.Load<List<ClsEmployee>>(employeeFileName);
            if (Employees.Count == 0)
            {
                Employees = new List<ClsEmployee>();
                for (int i = 1; i <= 10; i++)
                {
                    ClsEmployee emp = new ClsEmployee(i, "employee-" + i, 25, "090909090", "phnom penh", 3000);
                    Employees.Add(emp);
                }
                iOManager.Save(Employees, employeeFileName);
            }
            return Employees;
        }


        public  List<ClsProduct> LoadProduct(string productFileName)
        {
            List<ClsProduct>  Products = iOManager.Load<List<ClsProduct>>(productFileName);
            if (Products == null)
            {
                Products = new List<ClsProduct>();
            }
            return Products;
        }

        public List<ClsCustomer> LoadCustomer(string customerFileName)
        {
            List<ClsCustomer> Customers = iOManager.Load<List<ClsCustomer>>(customerFileName);
            if (Customers.Count == 0)
            {
                Customers = new List<ClsCustomer>();
                for (int i = 1; i <= 10; i++)
                {
                    ClsCustomer cus = new ClsCustomer(i, "customer-" + i, "090909090", "phnom penh");
                    Customers.Add(cus);
                }
                iOManager.Save(Customers, customerFileName);
            }
            return Customers;
        }

        public List<ClsSaleSummaries> LoadSaleSummaries(string filename)
        {
            List<ClsSaleSummaries> saleSummaries = iOManager.Load<List<ClsSaleSummaries>>(filename);
            if (saleSummaries.Count == 0)
                saleSummaries = new List<ClsSaleSummaries>();
            return saleSummaries;
        }
        public List<ClsSaleDetail> LoadSaleDetails(string filename)
        {
            List<ClsSaleDetail> saleDetails = iOManager.Load<List<ClsSaleDetail>>(filename);
            if (saleDetails.Count == 0)
                saleDetails = new List<ClsSaleDetail>();
            return saleDetails;
        }
        public List<ClsStock> LoadStocks(string filename)
        {
            List<ClsStock> stocks = iOManager.Load<List<ClsStock>>(filename);
            if (stocks.Count == 0)
                stocks = new List<ClsStock>();
            return stocks;
        }

        public void InsertStockSampleData(List<ClsProduct> products,string stockFileName)
        {
            List<ClsStock> sampleStocks = new List<ClsStock>();
            foreach(ClsProduct product in products)
            {
                ClsStock stock = new ClsStock();
                stock.ProductId = product.Id;
                stock.Quantity = 100;
                sampleStocks.Add(stock);
            }
            iOManager.Save(sampleStocks, stockFileName);
        }
    }
}
