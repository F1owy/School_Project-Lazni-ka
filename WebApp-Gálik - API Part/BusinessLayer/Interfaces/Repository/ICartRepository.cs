using DataLayer.entities;

namespace BusinessLayer.Interfaces.Repository
{
    public interface ICartRepository : IBaseRepository<CartEntity>
    {
   Task<CartEntity?> GetCartByUserIdAsync(int userId);
        Task<CartEntity> GetOrCreateCartAsync(int userId);
  }
}
