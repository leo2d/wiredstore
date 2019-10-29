using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class CartItemRepository : Repository<CartItem>, ICartIemRepository
    {
        public CartItemRepository(WiredContext context) : base(context)
        {
        }
    }
}
