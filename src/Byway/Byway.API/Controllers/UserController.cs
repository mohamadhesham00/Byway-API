using Byway.Application.DTOs.User;
using Byway.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Byway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : APIControllerBase
    {
        private readonly IUserService _userService = userService;

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            return HandleResult(result);
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            return HandleResult(result);

        }

        // GET: api/user/me
        //[HttpGet("me")]
        //public async Task<IActionResult> Me()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (userId == null)
        //        return Unauthorized();

        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //        return NotFound();

        //    return Ok(new
        //    {
        //        user.Id,
        //        user.UserName,
        //        user.Email
        //    });
        //}
    }

}
