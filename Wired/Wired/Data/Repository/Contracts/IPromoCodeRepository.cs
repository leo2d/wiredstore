using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Contracts
{
    public interface IPromoCodeRepository : IRepository<PromoCode>
    {
        Task<PromoCode> FindOne(Expression<Func<PromoCode, bool>> predicate);
    }
}
