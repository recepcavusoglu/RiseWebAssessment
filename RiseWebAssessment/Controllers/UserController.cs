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
            if(userService.GetUser(user.Id) == null)
            {
                return Ok(userService.AddUser(user));
            }
            return BadRequest("User Already Exist");
        }

        [HttpPut("UpdateUser")] 
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
            userService.DeleteUser(id);
            return Ok("User Deleted");
        }

        [HttpPut("DeactivateUser/{id}")]
        public async Task<ActionResult<User>> DeactivateUser(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            userService.DeactivateUser(id);
            return Ok("User Deleted");
        }

        [HttpGet("GetAllActiveUsers/{id}")]
        public async Task<ActionResult<List<User>>> GetAllActiveUsers()
        {
            return Ok(GetAllActiveUsers());
        }
    }
}
