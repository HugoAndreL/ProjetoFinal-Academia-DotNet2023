using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("Login")]
        public IActionResult Logar([FromBody] Login login)
        {
            string token = _jwtAuth.Authenticate(login.Username, login.Password);

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
