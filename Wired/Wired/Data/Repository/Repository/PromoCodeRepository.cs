using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class PromoCodeRepository : Repository<PromoCode>, IPromoCodeRepository
    {
        public PromoCodeRepository(WiredContext context) : base(context)
        {
        }

        public async Task<PromoCode> FindOne(Expression<Func<PromoCode, bool>> predicate)
        {
            return await _context.PromoCodes.SingleOrDefaultAsync(predicate);
        }
    }
}
