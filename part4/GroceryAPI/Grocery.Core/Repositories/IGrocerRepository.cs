using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories
{
    public interface IGrocerRepository
    {
        public Grocer GetGrocer(int id);
        public void SignUp(Grocer supplier);
        public void LogIn(Grocer supplier);
    }
}
