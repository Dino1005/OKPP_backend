using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController()
        {
           userService = new UserService();
        }

        [Authorize(Roles = "user, admin")]
        [Route("users")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await userService.GetAllUsersAsync();

            if(users != null && users.Any())
            {
                return Ok(users);
            }

            return BadRequest("No users found.");
        }

        [Authorize(Roles = "user, admin")]
        [Route("users({id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var user = await userService.GetUserByIdAsync(id);

            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("User not found.");
        }
    }
}