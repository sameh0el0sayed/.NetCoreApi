using DotNetCoreApi.Models;
using DotNetCoreApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UsersRepository repository = new UsersRepository();

        [HttpGet(Name = "GetUsers" )]
        public IEnumerable<User> GetUsers()
        {
            return repository.GetAllUsers();
        }

        [HttpGet("/{ID}", Name = "GetUserByID")]
        public ActionResult<User> GetUserByID(int ID)
        {
            return repository.GetUserByID(ID);

        }

        [HttpPost("InsertUser" )]
        public ActionResult<User> InsertUser(User user)
        {
            return repository.InsertUser(user);

        }
        [HttpPost("InsertNormalUser")]
        public ActionResult<User> InsertNormalUser(User user)
        {
            return repository.InsertNormalUser(user);

        }
        [HttpPost("InsertAdminUser")]
        public ActionResult<User> InsertAdminUser(User user)
        {
            return repository.InsertAdminUser(user);
        }
        [HttpPost("UpdateUser")]
        public ActionResult<User> UpdateUser(User user)
        {
            return repository.UpdateUser(user);
        }
        [HttpPost("DeleteUser",Order =5)]
        public ActionResult<User> DeleteUser(int ID)
        {
            return repository.DeleteUser(ID);
        }




    }
}
