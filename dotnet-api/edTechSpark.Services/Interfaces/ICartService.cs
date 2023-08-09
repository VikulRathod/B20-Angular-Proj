using edTechSpark.Core.Entities;

namespace edTechSpark.Services.Interfaces
{
    public interface ICartService: IService<Cart>
    {
        bool SaveCart(Cart cart);
    }
}
