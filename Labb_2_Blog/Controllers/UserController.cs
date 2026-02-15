using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> updateUser(int id, UpdateUserDTO dto)
        {
            var update = await _userService.UpdateUserAsync(id, dto);

            if (!update)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteUser(int id)
        {
            var user = await _userService.DeleteUserAsync(id);

            if (!user)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost("register")]

        public async Task<IActionResult> registerNewUser(RegisterUserDTO dto)
        {
            var ok = await _userService.RegisterNewUserAsync(dto);

            if (!ok)
            {
                return BadRequest("The information you wrote is already used by someone");
            }

            return Ok();
        }

        [HttpPost("login")]

        public async Task<IActionResult> logIn(LoginDTO dto)
        {
            var loggedInUser = await _userService.LoginUserAsync(dto.UserName, dto.Password);

            if (loggedInUser == null)
            {
                return Unauthorized("Wrong Password and/or Username");
            }

            return Ok();
        }
    }
}
