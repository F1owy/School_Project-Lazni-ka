using BusinessLayer.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int? category)
        {
            var products = category.HasValue
                ? await _productRepository.GetByCategoryAsync(category.Value)
                : await _productRepository.GetAllUsersAsync();

            ViewBag.Category = category;
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdWithImagesAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
