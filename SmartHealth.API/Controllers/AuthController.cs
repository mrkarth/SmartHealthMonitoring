using Microsoft.AspNetCore.Mvc;
using SmartHealth.API.DTOs.Authentication;
using SmartHealth.API.Services.Interfaces;

namespace SmartHealth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);

            return Ok(response);
            //turn Ok(request);
        }
    }
}
