using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Grocery.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public List<Product> GetAllProduct()
        {
            return _productRepository.GetAllProduct();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
