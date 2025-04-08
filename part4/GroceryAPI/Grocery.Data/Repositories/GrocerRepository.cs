using Grocery.Core.Models;
using Grocery.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.Repositories
{
    public class GrocerRepository : IGrocerRepository
    {
        private readonly DataContext _context;
        public GrocerRepository(DataContext context)
        {
            _context = context;
        }
        public Grocer GetGrocer(int id)
        {
            var grocer = _context.Grocers.Find(id);
            if (grocer != null)
            {
                return grocer;
            }
            throw new Exception("grocer not exisit");
        }
        public void SignUp(Grocer grocer)
        {
            var existingGrocer = _context.Grocers
                .FirstOrDefault(g => g.Name == grocer.Name);
            if (existingGrocer != null)
            {
                throw new Exception("grocer already exists!");
            }
            _context.Grocers.Add(grocer);
            _context.SaveChanges();

        }

        public void LogIn(Grocer grocer)
        {
            var existingGrocer = _context.Grocers
                .FirstOrDefault(g => g.Name == grocer.Name);
            if (existingGrocer == null)
            {
                throw new Exception("grocer not exists!");
            }
            var cheackGrocer = _context.Grocers.FirstOrDefault(s =>s.Phon.Equals(existingGrocer.Phon));
            if (cheackGrocer == null)
            {
                throw new Exception("the phon is uncorrect!");
            }

        }
    }
}

