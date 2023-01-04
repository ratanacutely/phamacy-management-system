using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public float Salary { get; set; }
        public ClsEmployee() { }
        public ClsEmployee(int id, string name, int age, string phone, string address, float salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Address = address;
            Salary = salary;
        }
    }
}
