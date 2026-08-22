using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartHealth.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TestAuthController : ControllerBase
    {
        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok(new { Message = "Hello, You are authenticated!" });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("Admin")]
        public IActionResult AdminOnly()
        {
            return Ok(new { Message = "Hello, This is only for Admin Access" });
        }
    }

}
