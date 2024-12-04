using Microsoft.AspNetCore.Mvc;
using StructSureBackend.Models;

namespace StructSureBackend.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public RegisterController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest(new { message = "User already exists." });
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User registered successfully.", userId = user.UserId });
        }
    }

    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LoginController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }

            return Ok(new { message = "Login successful." });
        }
    }

}
