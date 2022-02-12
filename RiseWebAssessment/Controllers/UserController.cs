using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RiseWebAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await this.dataContext.Users.ToListAsync());
        }

        [HttpGet("GetUserById/{id}")] 
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await this.dataContext.Users.FindAsync(id);
            if(user == null)
            {
                return BadRequest("User not found.");
            }
            return Ok(user);
        }

        [HttpPost("AddUser")] 
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            this.dataContext.Users.AddAsync(user);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Users.ToListAsync());
        }

        [HttpPut("Updateuser")] 
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var user = await this.dataContext.Users.FindAsync(request.Id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Company = request.Company;
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Users.ToListAsync());
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await this.dataContext.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            this.dataContext.Users.Remove(user);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Users.ToListAsync());
        }
    }
}
