using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core
{
    public interface IDataContext
    {
        List<Supplier> Suppliers { get; set; }
        List<Grocer> Grocers { get; set; }
        List<Product> Products { get; set; }
        List<Order> Orders { get; set; }
    }
}
