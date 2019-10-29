using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(WiredContext context) : base(context)
        {
        }
    }
}
