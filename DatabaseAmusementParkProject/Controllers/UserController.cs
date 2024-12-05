using DatabaseAmusementParkProject.Entities;
using Microsoft.AspNetCore.Mvc;
using DatabaseAmusementParkProject.Service; // Import UserService
using System;
using System.Threading.Tasks;

namespace DatabaseAmusementParkProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        // Inject UserService into the controller
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST: api/User/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserIfUniqueAsync([FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Username cannot be empty.");
            }

            // Use the UserService to create the user if the username is unique
            var user = await _userService.CreateUserIfUniqueAsync(username);

            return Ok(user); // Return the created or existing user
        }
    }
}
