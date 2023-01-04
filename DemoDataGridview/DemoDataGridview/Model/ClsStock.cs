using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsStock
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ClsStock() { }
        public ClsStock(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
