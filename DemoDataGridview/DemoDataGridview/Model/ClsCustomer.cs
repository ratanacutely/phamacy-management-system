using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsCustomer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ClsCustomer(int iD, string name, string phone, string address)
        {
            ID = iD;
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}
