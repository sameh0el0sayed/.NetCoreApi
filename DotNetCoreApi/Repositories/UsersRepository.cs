using DotNetCoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApi.Repositories
{
    public class UsersRepository : ControllerBase
    {
        Test_dbContext _DbContext;
 
        public UsersRepository(Test_dbContext DbContext )
        {
            _DbContext = DbContext;
 
        }
        public UsersRepository()
        {
            _DbContext = new Test_dbContext();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = (_DbContext.Users.ToList());

            if (users.Count>0)
            {
                return users;
            }
            else
            {
                return Enumerable.Empty<User>();    
            }
            
        }
        public ActionResult<User> GetAllAdmins()
        {
            var user= (_DbContext.Users.Where(w=>w.Role==2).FirstOrDefault());

            if (user is null)
            {
                return NotFound();
            }
            else
            {
                return user; 
            }
        }
        public ActionResult<User> GetUserByID(int id)
        {
            var user = (_DbContext.Users.Where(w => w.Id == id).FirstOrDefault());

            if (user is null)
            {
                return BadRequest();
            }
            else
            {
                return user;
            }
        }
        public ActionResult<User> InsertUser(User _user)
        {
            try
            {
                _DbContext.Users.Add(_user);
                _DbContext.SaveChanges();
                return _user;
            }
            catch (Exception)
            { 
                return BadRequest();
            }
            
        }
        //Add normal user
        public ActionResult<User> InsertNormalUser(User _user)
        {
            try
            {

                _user.Role = 1;
                _DbContext.Users.Add(_user);
                _DbContext.SaveChanges();
                return _user;
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //Add Admin user
        public ActionResult<User> InsertAdminUser(User _user)
        {
            
            try
            {
                _user.Role = 2;
                _DbContext.Users.Add(_user);
                _DbContext.SaveChanges();
                return _user;
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        public ActionResult<User> UpdateUser( User _user)
        {
            var UpdateUser = _DbContext.Users.Where(u => u.Id == _user.Id).FirstOrDefault();
            if (UpdateUser != null) {
                UpdateUser.Fullname = _user.Fullname;
                UpdateUser.Username = _user.Username;
                UpdateUser.Password = _user.Password;
                UpdateUser.Role = _user.Role; 
                _DbContext.Users.Update(UpdateUser);
                _DbContext.SaveChanges(); 
                return UpdateUser; 
            }
            else
            {
                return BadRequest();
            }


        }
        public ActionResult<User> DeleteUser(int id)
        {
            var DeleteUser = _DbContext.Users.Where(u => u.Id == id).FirstOrDefault();
            if (DeleteUser != null)
            { 
                _DbContext.Users.Remove(DeleteUser);
                _DbContext.SaveChanges();   
                return DeleteUser;

            }
            else
            {
                return BadRequest();
            } 
        }
        //login unit to save data on cookies 
        public ActionResult<User> AdminLogin(string username,string password)
        {
            var user = _DbContext.Users.Where(u => u.Username == username && u.Password == password && u.Role == 2).FirstOrDefault();
            if (user != null)  { return user; } else  { return BadRequest(); }
        }
         
    }
}
