using edTechSpark.Core;
using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edTechSpark.Repositories.Implementations
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }

        public CartRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public bool SaveCart(Cart cart)
        {
            cart.CreatedDate = DateTime.Now;
            dbContext.Carts.Add(cart);
            dbContext.SaveChanges();
            return true;
        }
    }
}
