using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinal.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTAuthManager _jwtAuth;
        private readonly HospitalContext _context;

        public AuthController(JWTAuthManager jwtAuth, HospitalContext context)
        {
            _jwtAuth = jwtAuth;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Logar([FromBody] Login login)
        {
            Login log = _context.Logins.FirstOrDefault(log => log.Username == login.Username && log.Password == login.Password);
            string token = _jwtAuth.Authenticate(log.Username, log.Password);

            if (token != null)
                return Ok(token);

            return Unauthorized();
        }

        [HttpPatch("AutoAtribuir/{id}")]
        public async Task<IActionResult> AutoAtribuir()
        {
            return NoContent();
        }
    }
}
