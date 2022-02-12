using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseWebAssessment.Model.DTO;
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
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpGet("GetUserById/{id}")] 
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = userService.GetUser(id);
            if(user == null)
            {
                return BadRequest("User Couldnt Found");
            }
            return Ok(user);
        }

        [HttpPost("AddUser")] 
        public async Task<ActionResult<List<UserDto>>> AddUser(UserDto userDto)
        {
            var user = userService.GetUser(userDto.Id);
            if (user == null)
            {
                userService.AddUser(userDto);
                return Ok("User Added");
            }
            return BadRequest("User Already Exist");
        }

        [HttpPut("UpdateUser")] 
        public async Task<ActionResult<List<UserDto>>> UpdateUser(UserDto request)
        {
            var user = userService.UpdateUser(request);
            if(user == request) { return BadRequest("Error while updating"); }
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
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
        public async Task<ActionResult<UserDto>> DeactivateUser(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            userService.DeactivateUser(id);
            return Ok("User Deleted");
        }

        [HttpGet("GetAllActiveUsers")]
        public async Task<ActionResult<List<UserDto>>> GetAllActiveUsers()
        {
            var users = await userService.GetAllActiveUsers();
            return Ok(users);
        }
    }
}
