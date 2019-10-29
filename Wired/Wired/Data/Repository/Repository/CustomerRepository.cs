using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WiredContext context) : base(context)
        {

        }

        public async Task<Customer> GetFirstAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customers
              .FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> FindAnyAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customers
              .AnyAsync(predicate);
        }
    }
}
