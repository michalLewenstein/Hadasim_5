using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext _context;
        public SupplierRepository(DataContext context)
        {
            _context = context;
        }
        public void SignUp(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers
                .FirstOrDefault(s => s.RepresentativeName == supplier.RepresentativeName);
            if (existingSupplier != null)
            {
                throw new Exception("supplier already exists!");
            }
            else
            {
                var newSupplier = new Supplier
                {
                    CompanyName = supplier.CompanyName,
                    Phone = supplier.Phone,
                    RepresentativeName = supplier.RepresentativeName,
                    Products = supplier.Products.Select(p => new Product
                    {
                        ProductName = p.ProductName,
                        ProductPrice = p.ProductPrice,
                        minQuantityOrder = p.minQuantityOrder,
                        SupplierId = supplier.Id
                    }).ToList()
                };
            }
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
           
        }

        public int LogIn(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers
                .FirstOrDefault(s => s.RepresentativeName == supplier.RepresentativeName);
            if (existingSupplier == null)
            {
                throw new Exception("supplier not exists!");
            }
            var cheackSupplier  = _context.Suppliers.FirstOrDefault(s=>
            s.RepresentativeName.Equals(existingSupplier.RepresentativeName)&&
            s.Phone.Equals(existingSupplier.Phone));
            if(cheackSupplier == null)
            {
                throw new Exception("one or more of the details are worng!");
            }
          return cheackSupplier.Id;
        }
        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.Include(p=> p.Products).ToList();
                          
        }
        public Supplier GetSupplierById(int id)
        {
           var supplier = _context.Suppliers.Find(id);
           if (supplier != null)
            {
                return supplier;
            }
            return null;
        }
    }
}
