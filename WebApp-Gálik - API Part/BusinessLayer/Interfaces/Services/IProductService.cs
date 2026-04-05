using Common.DTO;

namespace BusinessLayer.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<List<ProductDTO>> GetByCategoryAsync(int category);
        Task<bool> CreateAsync(ProductDTO product);
  Task<bool> UpdateAsync(ProductDTO product);
        Task<bool> DeleteAsync(int id);
}
}
