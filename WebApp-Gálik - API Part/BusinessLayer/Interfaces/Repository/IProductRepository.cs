using DataLayer.entities;

namespace BusinessLayer.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<ProductEntity?> GetByIdWithImagesAsync(int id);
 Task<List<ProductEntity>> GetByCategoryAsync(int category);
  }
}
