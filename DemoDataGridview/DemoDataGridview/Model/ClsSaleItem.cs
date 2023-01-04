using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsSaleItem
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public String Unit { get; set; }

        public ClsSaleItem() { }
        public ClsSaleItem(string productName, double price, int quantity, double totalPrice, string unit)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            TotalPrice = totalPrice;
            Unit = unit;
        }
    }
}
