using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories
{
    public interface ISupplierRepository
    {
        public void SignUp(Supplier supplier);
        public int LogIn(Supplier supplier);
        public List<Supplier> GetAllSupplier();
        public Supplier GetSupplierById(int id);

    }
}
