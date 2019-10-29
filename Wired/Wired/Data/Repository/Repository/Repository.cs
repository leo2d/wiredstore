using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;

namespace Wired.Data.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WiredContext _context;

        public Repository(WiredContext context)
        {
            _context = context;
        }

        protected async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().Where(predicate).ToListAsync();
            return result.Count();
        }

        public async Task Create(T entity)
        {
            _context.Add(entity);
            await SaveAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            await SaveAsync();
        }
    }
}
