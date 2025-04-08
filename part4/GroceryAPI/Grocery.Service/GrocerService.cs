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
    public class GrocerService : IGrocerService
    {
        private readonly IGrocerRepository _grocerRepository;
        public GrocerService(IGrocerRepository grocerRepository)
        {
            _grocerRepository = grocerRepository;
        }
        public Grocer GetGrocer(int id)
        {
            return _grocerRepository.GetGrocer(id);
        }
        public void SignUp(Grocer grocer)
        {
            _grocerRepository.SignUp(grocer);
        }
        public void LogIn(Grocer grocer)
        {
            _grocerRepository.LogIn(grocer);
        }

    }
}
