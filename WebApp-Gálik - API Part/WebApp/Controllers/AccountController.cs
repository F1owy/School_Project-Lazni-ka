using System.Security.Claims;
using BusinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
      private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
   _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
  {
 return View();
        }

   [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
   {
if (!ModelState.IsValid)
 return View(model);

var user = await _userService.LoginAsync(model);
    if (user != null)
        {
                var claims = new List<Claim>
    {
        new(ClaimTypes.Email, user.Email),
        new(ClaimTypes.Name, user.Name),
        new(ClaimTypes.NameIdentifier, user.PublicId.ToString()),
    };
                var claimsIdentity = new ClaimsIdentity(claims, "Auth");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };
                await HttpContext.SignInAsync("Auth", new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Home");
      }

   ModelState.AddModelError("", "Nesprávny email alebo heslo");
return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Auth");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
      public IActionResult Register()
    {
         return View();
        }

  [HttpPost]
      public async Task<IActionResult> Register(RegisterDTO model)
  {
  if (!ModelState.IsValid)
    return View(model);

   return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
  return RedirectToAction("Index", "Home");
        }
    }
}
