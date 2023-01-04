using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsSaleDetail
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

        public ClsSaleDetail() { }
        public ClsSaleDetail(int invoiceId, int productId, int quantity, double price, double totalPrice)
        {
            InvoiceId = invoiceId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }
    }
}
