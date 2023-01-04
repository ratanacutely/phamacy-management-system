using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double CostPrice { get; set; }   
        public double SellingPrice { get; set; }
        public string Unit { get;set; }

        public ClsProduct() { }
        public ClsProduct(int id, string name, int categoryId, double costPrice, double sellingPrice, string unit)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            CostPrice = costPrice;
            SellingPrice = sellingPrice;
            Unit = unit;
        }
    }
}
