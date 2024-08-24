using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccount account, ILogger<AccountController> logger)
        {
            _account = account;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDto registerDto)
        {
            try
            {
                var user = await _account.Register(registerDto);
                if (user == null)
                {
                    return BadRequest("Registration failed.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering a new user.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _account.Login(loginDto);
                if (user == null)
                {
                    return BadRequest("Login failed.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                var result = await _account.Logout();
                if (!result)
                {
                    return BadRequest("Logout failed.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging out.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
