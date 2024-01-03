using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Entity
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stockQuantity { get; set; }
    }
}
