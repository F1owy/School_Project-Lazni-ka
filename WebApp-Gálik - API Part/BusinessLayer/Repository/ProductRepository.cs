using BusinessLayer.Interfaces.Repository;
using DataLayer;
using DataLayer.entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
 public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
  {
    private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
  {
     _context = context;
        }

    public async Task<ProductEntity?> GetByIdWithImagesAsync(int id)
      {
   return await _context.Products
    .Include(p => p.Images)
    .FirstOrDefaultAsync(p => p.id == id);
        }

  public async Task<List<ProductEntity>> GetByCategoryAsync(int category)
 {
      return await _context.Products
  .Where(p => (int)p.Category == category)
      .ToListAsync();
   }
  }
}
