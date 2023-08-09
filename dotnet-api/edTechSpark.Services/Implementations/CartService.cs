using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using edTechSpark.Services.Interfaces;

namespace edTechSpark.Services.Implementations
{
    public class CartService : Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepo;
        public CartService(ICartRepository cartRepo): base(cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public bool SaveCart(Cart cart)
        {
            return _cartRepo.SaveCart(cart);
        }
    }
}
