using BusinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
     [Authorize]

    public class AdminController : Controller
    {
  private readonly IProductService _productService;
   private const string AdminPassword = "admin123";
      private const string AdminSessionKey = "IsAdminAuthenticated";

        public AdminController(IProductService productService)
    {
   _productService = productService;
        }

        private bool IsAdminAuthenticated()
        {
       return HttpContext.Session.GetString(AdminSessionKey) == "true";
        }

        [HttpGet]
        public IActionResult Login()
   {
            if (IsAdminAuthenticated())
        return RedirectToAction("Products");
 
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password)
   {
      if (password == AdminPassword)
      {
HttpContext.Session.SetString(AdminSessionKey, "true");
       return RedirectToAction("Products");
          }

         ViewBag.Error = "Nesprávne heslo";
return View();
     }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(AdminSessionKey);
            return RedirectToAction("Login");
     }

        // GET: /Admin/Products
        public async Task<IActionResult> Products()
        {
  if (!IsAdminAuthenticated())
                return RedirectToAction("Login");

            var products = await _productService.GetAllAsync();
            return View(products);
     }

        // GET: /Admin/CreateProduct
 public IActionResult CreateProduct()
 {
            if (!IsAdminAuthenticated())
       return RedirectToAction("Login");

    return View();
  }

    // POST: /Admin/CreateProduct
      [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
  {
     if (!IsAdminAuthenticated())
          return RedirectToAction("Login");

      if (!ModelState.IsValid)
       return View(product);

      await _productService.CreateAsync(product);
       return RedirectToAction("Products");
     }

      // GET: /Admin/EditProduct/5
     public async Task<IActionResult> EditProduct(int id)
       {
            if (!IsAdminAuthenticated())
        return RedirectToAction("Login");

       var product = await _productService.GetByIdAsync(id);
      if (product == null)
       return NotFound();

   return View(product);
        }

        // POST: /Admin/EditProduct
        [HttpPost]
     public async Task<IActionResult> EditProduct(ProductDTO product)
        {
         if (!IsAdminAuthenticated())
         return RedirectToAction("Login");

            if (!ModelState.IsValid)
  return View(product);

            await _productService.UpdateAsync(product);
            return RedirectToAction("Products");
        }

     // POST: /Admin/DeleteProduct/5
     [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
        {
       if (!IsAdminAuthenticated())
     return RedirectToAction("Login");

            await _productService.DeleteAsync(id);
     return RedirectToAction("Products");
        }
    }
}
