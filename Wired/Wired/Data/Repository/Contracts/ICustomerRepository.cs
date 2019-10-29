using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetFirstAsync(Expression<Func<Customer, bool>> predicate);
        Task<bool> FindAnyAsync(Expression<Func<Customer, bool>> predicate);
    }
}
