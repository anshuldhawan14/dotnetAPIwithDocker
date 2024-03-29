using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Models;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        public UserController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userDbContext.Users;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user= await _userDbContext.Users.FindAsync(userId);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userDbContext.Users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            _userDbContext.Users.Update(user);
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var user = await _userDbContext.Users.FindAsync(userId);
            _userDbContext.Users.Remove(user);
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
