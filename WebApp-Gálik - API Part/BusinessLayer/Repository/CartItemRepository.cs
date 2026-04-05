using BusinessLayer.Interfaces.Repository;
using DataLayer;
using DataLayer.entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
  public class CartItemRepository : BaseRepository<CartItemEntity>, ICartItemRepository
    {
  private readonly AppDbContext _context;

    public CartItemRepository(AppDbContext context) : base(context)
        {
     _context = context;
        }

        public async Task<CartItemEntity?> GetByCartAndProductAsync(int cartId, int productId)
 {
  return await _context.CartItems
      .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
      }

      public async Task<List<CartItemEntity>> GetItemsByCartIdAsync(int cartId)
        {
         return await _context.CartItems
        .Include(ci => ci.Product)
  .Where(ci => ci.CartId == cartId)
     .ToListAsync();
 }
  }
}
