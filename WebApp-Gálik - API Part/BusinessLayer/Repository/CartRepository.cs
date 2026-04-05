using BusinessLayer.Interfaces.Repository;
using DataLayer;
using DataLayer.entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
 public class CartRepository : BaseRepository<CartEntity>, ICartRepository
    {
  private readonly AppDbContext _context;

  public CartRepository(AppDbContext context) : base(context)
     {
    _context = context;
      }

        public async Task<CartEntity?> GetCartByUserIdAsync(int userId)
  {
 return await _context.Carts
          .Include(c => c.Items)
          .ThenInclude(i => i.Product)
  .FirstOrDefaultAsync(c => c.UserId == userId);
  }

   public async Task<CartEntity> GetOrCreateCartAsync(int userId)
  {
  var cart = await GetCartByUserIdAsync(userId);
            if (cart == null)
      {
       cart = new CartEntity
    {
          UserId = userId,
    PublicId = Guid.NewGuid()
  };
           await CreateAsync(cart);
 await SaveChangesAsync();
            }
   return cart;
        }
 }
}
