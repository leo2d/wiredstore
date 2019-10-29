using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Wired.Data.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<T> GetById(int id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<int> Count(Expression<Func<T, bool>> predicate);
    }
}
