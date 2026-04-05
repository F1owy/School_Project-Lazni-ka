using Common.DTO;

namespace BusinessLayer.Interfaces.Services
{
 public interface ICartService
  {
  Task<CartDTO> GetCartAsync(int userId);
      Task<bool> AddItemAsync(int userId, int productId, int quantity);
     Task<bool> RemoveItemAsync(int userId, int productId);
  Task<bool> UpdateQuantityAsync(int userId, int productId, int quantity);
        Task<bool> ClearCartAsync(int userId);
    }
}
