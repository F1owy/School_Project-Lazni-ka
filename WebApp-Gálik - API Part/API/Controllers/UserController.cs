using Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public List<User> UserList { get; set; } = new List<User>();

        public UserController()
        {
        }

        [HttpGet(Name = "GetUsers")]
        public List<User> GetAll()
        {
            return new List<User>
            {
                new User {
                    Id = 1,
                    Name = "John Doe",
                    Email = "doe@gmail.com"
                },
                new User {
                    Id = 2,
                    Name = "Jane Doe",
                    Email = "doe@gmail.com"
                }
            };
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public ActionResult<User> Get(int id)
        {
            var user = UserList.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            return user;
        }


        [HttpGet(Name = "AddUser")]

        public async Task<bool> AddUser(User user)
        {
            return true;
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var user = user.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();


            user.Remove(user);
            return NoContent();

        }

        //[HttpGet(Name = "GetUser")]

        //public User? Get(int id)

        //{

        //    return UserList.FirstOrDefault(u => u.Id == id);

        //}

        //[HttpPost(Name = "AddUser")]

        //public void Add(User user)

        //{

        //    UserList.Add(user);

        //}

    }

}

