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
            if(userService.UserExist(id))
            {
                return Ok(userService.GetUser(id));               
            }
            return BadRequest("User Couldnt Found");
        }

        [HttpPost("AddUser")] 
        public async Task<ActionResult<List<string>>> AddUser(UserDto userDto)
        {
            if (userService.UserExist(userDto.Id))
            {
                return BadRequest("User Already Exist");                
            }
            userService.AddUser(userDto);
            return Ok("User Added");
        }

        [HttpPut("UpdateUser")] 
        public async Task<ActionResult<List<UserDto>>> UpdateUser(UserDto request)
        {
            var user = userService.UpdateUser(request);
            if(user == null) { return BadRequest("Error. User couldnt found"); }
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            if (userService.UserExist(id))
            {
                userService.DeleteUser(id);
                return Ok("User Deleted");                
            }
            return BadRequest("User not found.");
        }

        [HttpPut("DeactivateUser/{id}")]
        public async Task<ActionResult<UserDto>> ChangeUserStatus(int id)
        {
            if (userService.UserExist(id))
            {
                userService.ChangeUserStatus(id);
                return Ok("User Active Status Changed");
            }            
            return BadRequest("User not found.");
        }

        [HttpGet("GetAllActiveUsers")]
        public async Task<ActionResult<List<UserDto>>> GetAllActiveUsers()
        {
            var users = await userService.GetAllActiveUsers();
            return Ok(users);
        }
        [HttpGet("UserExist/{id}")]
        public async Task<ActionResult> UserExist(int id)
        {
            var exist = userService.UserExist(id);
            if (exist)
            {
                return Ok("User exist");
            }
            else
            {
                return Ok("User couldnt found");
            }
        }
        [HttpGet("GetUserWithContact/{id}")]
        public async Task<ActionResult<UserWithContactDto>> GetUserWithContact(int id)
        {
            if (userService.UserExist(id))
            {
                return Ok(userService.GetUserWithContact(id));
            }
            return BadRequest("User Couldnt Found");
        }
    }
}
