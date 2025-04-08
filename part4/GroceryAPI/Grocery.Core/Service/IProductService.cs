using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Service
{
    public interface IProductService
    {
        public void AddProduct(Product product);
        public List<Product> GetAllProduct();
        public Product GetProductById(int id);
    }
}
