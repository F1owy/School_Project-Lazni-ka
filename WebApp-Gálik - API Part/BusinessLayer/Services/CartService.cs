using BusinessLayer.Interfaces.Repository;
using BusinessLayer.Interfaces.Services;
using Common.DTO;
using DataLayer.entities;

namespace BusinessLayer.Services
{
    public class CartService : ICartService
{
     private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
 private readonly IProductRepository _productRepository;

        public CartService(
   ICartRepository cartRepository,
      ICartItemRepository cartItemRepository,
       IProductRepository productRepository)
        {
   _cartRepository = cartRepository;
 _cartItemRepository = cartItemRepository;
   _productRepository = productRepository;
        }

        public async Task<CartDTO> GetCartAsync(int userId)
        {
 var cart = await _cartRepository.GetOrCreateCartAsync(userId);
   var items = await _cartItemRepository.GetItemsByCartIdAsync(cart.id);

    var cartDto = new CartDTO
          {
         ItemsCount = items.Sum(i => i.Amount),
      TotalValue = items.Sum(i => i.Amount * i.Product.Price),
            Items = items.Select(i => new CartItemDTO
  {
    ProductId = i.ProductId,
    ProductName = i.Product.Name,
Category = i.Product.Category.ToString(),
           Price = i.Product.Price,
      Quantity = i.Amount
      }).ToList()
    };

 return cartDto;
   }

        public async Task<bool> AddItemAsync(int userId, int productId, int quantity)
{
       var cart = await _cartRepository.GetOrCreateCartAsync(userId);
     var existingItem = await _cartItemRepository.GetByCartAndProductAsync(cart.id, productId);

if (existingItem != null)
 {
      existingItem.Amount += quantity;
  _cartItemRepository.Update(existingItem);
     }
     else
            {
        var product = await _productRepository.GetByIdAsync(productId);
     if (product == null) return false;

     var newItem = new CartItemEntity
       {
      CartId = cart.id,
       ProductId = productId,
       Amount = quantity,
         PublicId = Guid.NewGuid()
  };
     await _cartItemRepository.CreateAsync(newItem);
            }

            await _cartItemRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItemAsync(int userId, int productId)
        {
         var cart = await _cartRepository.GetCartByUserIdAsync(userId);
           if (cart == null) return false;

      var item = await _cartItemRepository.GetByCartAndProductAsync(cart.id, productId);
            if (item == null) return false;

    _cartItemRepository.Delete(item);
     await _cartItemRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(int userId, int productId, int quantity)
        {
 var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        if (cart == null) return false;

            var item = await _cartItemRepository.GetByCartAndProductAsync(cart.id, productId);
    if (item == null) return false;

        if (quantity <= 0)
  {
   _cartItemRepository.Delete(item);
            }
     else
 {
  item.Amount = quantity;
    _cartItemRepository.Update(item);
       }

       await _cartItemRepository.SaveChangesAsync();
            return true;
    }

  public async Task<bool> ClearCartAsync(int userId)
     {
var cart = await _cartRepository.GetCartByUserIdAsync(userId);
     if (cart == null) return false;

    var items = await _cartItemRepository.GetItemsByCartIdAsync(cart.id);
          foreach (var item in items)
    {
     _cartItemRepository.Delete(item);
            }

         await _cartItemRepository.SaveChangesAsync();
    return true;
        }
    }
}
