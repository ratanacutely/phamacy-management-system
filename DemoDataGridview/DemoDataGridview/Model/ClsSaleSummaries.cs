using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsSaleSummaries
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public double TotalPrice { get; set; }

        public ClsSaleSummaries() { }
        public ClsSaleSummaries(int invoiceId, int customerId, int employeeId, double totalPrice)
        {
            InvoiceId = invoiceId;
            CustomerId = customerId;
            EmployeeId = employeeId;
            TotalPrice = totalPrice;
        }
    }
}
