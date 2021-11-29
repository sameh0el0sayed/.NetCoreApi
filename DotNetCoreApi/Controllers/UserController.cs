using DotNetCoreApi.Models;
using DotNetCoreApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Controllers
{
     public class UserController : Controller
    {
        UsersRepository repository = new UsersRepository();

        [HttpGet("", Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return repository.GetAllUsers();
        }

        [HttpGet("/{ID}", Name = "GetUserByID")]
        public ActionResult<User> GetUserByID(int ID)
        {
            return repository.GetUserByID(ID);

        }

        [HttpPost("", Name = "InsertUser")]
        public ActionResult<User> InsertUser(User user)
        {
            return repository.InsertUser(user);

        }

    }
}
