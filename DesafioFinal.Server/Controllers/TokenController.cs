﻿using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinal.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IJWTAuthManager _jwtAuth;
        private readonly HospitalContext _context;

        public TokenController(IJWTAuthManager jwtAuth, HospitalContext context)
        {
            _jwtAuth = jwtAuth;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Logar([FromBody] Login login)
        {
            string token = _jwtAuth.Authenticate(login.Username, login.Password, _context);

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