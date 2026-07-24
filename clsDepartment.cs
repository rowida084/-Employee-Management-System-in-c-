using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Models
{
    internal class clsDepartment
    {
        public string name {  get; set; }
        public int id { get; set; }

      public  clsDepartment(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
