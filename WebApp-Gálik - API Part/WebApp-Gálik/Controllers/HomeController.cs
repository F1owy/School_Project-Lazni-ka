using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using BusinessLayer.Interfaces.Services;
using DataLayer;
using DataLayer.entities;
using Lukas_Liscak_IVD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lukas_Liscak_IVD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<UserDTO> userList { get; set; } = new List<UserDTO>();
        private readonly AppDbContext db;
        public readonly IUserService _userService;

        public HomeController(AppDbContext context, IUserService userservice)
        {
            db = context;
            _userService = userservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Users()
        {
            var userList = await _userService.GetAllUsersAsync();
            return View(userList);
        }

        public IActionResult formCreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(UserDTO user)
        {
            var ifDone = await _userService.CreateAsync(user);
            if (ifDone == false)
                return NotFound();
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> Update(UpdateUserDTO updateModel)
        {
            var ifDone = await _userService.UpdateAsync(updateModel);
            if (ifDone == false)
                return NotFound();
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> DeleteUser(Guid userPublicId)
        {
            var ifDone = await _userService.DeleteAsync(userPublicId);
            if (ifDone == false)
                return NotFound();

            return RedirectToAction("Users");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
