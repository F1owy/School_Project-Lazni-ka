using DataLayer.entities;

namespace BusinessLayer.Interfaces.Repository
{
    public interface ICartItemRepository : IBaseRepository<CartItemEntity>
    {
    Task<CartItemEntity?> GetByCartAndProductAsync(int cartId, int productId);
     Task<List<CartItemEntity>> GetItemsByCartIdAsync(int cartId);
  }
}
