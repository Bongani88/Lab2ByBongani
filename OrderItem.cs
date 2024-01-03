using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Entity
{
    public class OrderItem
    {
        public int orderItemID { get; set; }
        public int orderID { get; set; }
        public int productID { get; set; }
        public double unitPrice { get; set; }
    }
}
