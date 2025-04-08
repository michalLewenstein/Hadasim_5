using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int minQuantityOrder { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
