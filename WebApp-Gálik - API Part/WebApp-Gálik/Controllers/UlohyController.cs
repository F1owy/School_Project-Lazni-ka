using Lukas_Liscak_IVD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lukas_Liscak_IVD.Controllers
{
    public class UlohyController : Controller
    {
        public List<UserDTO> UserList { get; set; } = new List<UserDTO>();
        public IActionResult Uloha1()
        {
            return View();
        }
        public IActionResult Uloha2()
        {
            return View();
        }

        /*public IActionResult Uloha4()
        {
            var userList = new List<User>()
            {
                new User()
            {
                Name = "John",
                Surname = "Doe",
                Email = "john@test.test"
            },
            new User()
            {
                Name = "Jane",
                Surname = "Smith",
                Email = "jane@test.test"
            },
            new User()
            {
                Name = "Michael",
                Surname = "Brown",
                Email = "michael@test.test"
            },
            new User()
            {
                Name = "Emily",
                Surname = "Johnson",
                Email = "emily@test.test"
            },
            new User()
            {
                Name = "David",
                Surname = "Wilson",
                Email = "david@test.test"
            }

            };
            return View(userList);
        }
        public IActionResult Uloha5()
        {
            var userList = new List<User>()
            {
                new User()
            {
                Name = "John",
                Surname = "Doe",
                Email = "john@test.test"
            },
            new User()
            {
                Name = "Jane",
                Surname = "Smith",
                Email = "jane@test.test"
            },
            new User()
            {
                Name = "Michael",
                Surname = "Brown",
                Email = "michael@test.test"
            },
            new User()
            {
                Name = "Emily",
                Surname = "Johnson",
                Email = "emily@test.test"
            },
            new User()
            {
                Name = "David",
                Surname = "Wilson",
                Email = "david@test.test"
            }

            };
            return View(userList);
            
        }*/
        public IActionResult Uloha6()
        {
            return View();
        }
        public IActionResult Uloha7()
        {
            return View();
        }
        public IActionResult Uloha8()
        {
            return View();
        }
        public IActionResult Uloha9()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string name, string surname, string email, string password,
                                      string phone, string address, int age, List<string> todo)
        {
            var user = new UserDTO
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = email,
                Password = password,
                Address = address,
                Age = age,
                ToDo = todo
            };

            UserList.Add(user);

            return View("Zobraz", UserList);
        }

        [HttpGet]
        public IActionResult Zobraz()
        {
            return View(UserList);
        }

    }
}
