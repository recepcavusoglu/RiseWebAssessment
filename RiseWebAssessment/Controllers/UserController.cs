using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpGet("GetUserById/{id}")] 
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = userService.GetUser(id);
            if(user == null)
            {
                return BadRequest("User Couldnt Found");
            }
            return Ok(user);
        }

        [HttpPost("AddUser")] 
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            return Ok(userService.AddUser(user));
        }

        [HttpPut("Updateuser")] 
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var user = userService.UpdateUser(request);
            if(user == request) { return BadRequest("Error while updating"); }
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            userService.DeleteUser(user);
            return Ok("User Deleted");
        }
    }
}
