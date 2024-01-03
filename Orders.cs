using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Entity
{
    public class Orders
    {
        public int orderID { get; set; }
        public int customerID { get; set; }
        public DateOnly date { get; set; }
        public double totalAmount { get; set; }
    }
}
