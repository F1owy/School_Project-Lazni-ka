using BusinessLayer.Interfaces.Repository;
using BusinessLayer.Interfaces.Services;
using Common.DTO;
using DataLayer.entities;
using DataLayer.Enums;

namespace BusinessLayer.Services
{
    public class ProductService : IProductService
  {
        private readonly IProductRepository _productRepository;

      public ProductService(IProductRepository productRepository)
  {
     _productRepository = productRepository;
      }

   public async Task<List<ProductDTO>> GetAllAsync()
 {
     var products = await _productRepository.GetAllUsersAsync();
            return products.Select(MapToDto).ToList();
        }

   public async Task<ProductDTO?> GetByIdAsync(int id)
 {
   var product = await _productRepository.GetByIdAsync(id);
return product != null ? MapToDto(product) : null;
        }

     public async Task<List<ProductDTO>> GetByCategoryAsync(int category)
        {
     var products = await _productRepository.GetByCategoryAsync(category);
    return products.Select(MapToDto).ToList();
     }

    public async Task<bool> CreateAsync(ProductDTO dto)
     {
          var entity = new ProductEntity
   {
     PublicId = Guid.NewGuid(),
  Name = dto.Name,
         Description = dto.Description,
         Price = dto.Price,
       Category = (CategoryEnum)dto.Category,
   StockAmount = dto.StockAmount
            };

          await _productRepository.CreateAsync(entity);
          await _productRepository.SaveChangesAsync();
    return true;
        }

      public async Task<bool> UpdateAsync(ProductDTO dto)
        {
            var entity = await _productRepository.GetByIdAsync(dto.Id);
         if (entity == null) return false;

          entity.Name = dto.Name;
      entity.Description = dto.Description;
   entity.Price = dto.Price;
           entity.Category = (CategoryEnum)dto.Category;
         entity.StockAmount = dto.StockAmount;

   _productRepository.Update(entity);
 await _productRepository.SaveChangesAsync();
    return true;
   }

    public async Task<bool> DeleteAsync(int id)
     {
           var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null) return false;

   _productRepository.Delete(entity);
          await _productRepository.SaveChangesAsync();
           return true;
 }

  private ProductDTO MapToDto(ProductEntity entity)
     {
      return new ProductDTO
     {
      Id = entity.id,
 Name = entity.Name,
    Description = entity.Description,
   Price = entity.Price,
    Category = (int)entity.Category,
      CategoryName = entity.Category.ToString(),
     StockAmount = entity.StockAmount
      };
       }
    }
}
