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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public void SignUp(Supplier supplier)
        {
            _supplierRepository.SignUp(supplier);
        }
        public int LogIn(Supplier supplier)
        {
            return _supplierRepository.LogIn(supplier);
        }
        public List<Supplier> GetAllSupplier()
        {
            return _supplierRepository.GetAllSupplier();
        }
        public Supplier GetSupplierById(int id)
        {
            return _supplierRepository.GetSupplierById(id);
        }
    }
}
