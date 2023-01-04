using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataGridview.Model
{
    public class ClsCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClsCategory() { }
        public ClsCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
