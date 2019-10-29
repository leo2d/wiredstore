using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class AdministratorRepository : Repository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(WiredContext context) : base(context)
        {

        }

        public async Task<Administrator> GetFirstAsync(Expression<Func<Administrator, bool>> predicate)
        {
            return await _context.Administrators
              .FirstOrDefaultAsync(predicate);
        }
    }
}
