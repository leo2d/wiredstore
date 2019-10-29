using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Contracts
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Task<Administrator> GetFirstAsync(Expression<Func<Administrator, bool>> predicate);
    }
}
