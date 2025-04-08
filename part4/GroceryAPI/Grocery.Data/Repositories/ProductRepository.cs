using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context ) { 
            _context = context;
        }
        public void AddProduct(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p=>p.ProductName.Equals(product.ProductName));
            if (existingProduct != null)
            {
                throw new Exception("product already exists!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.Include(s=>s.Supplier). ToList();
               
        }
        public Product GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                return product;
            }
            return null;
        }
    }
}
