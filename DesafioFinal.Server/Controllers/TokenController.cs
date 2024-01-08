using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        /// <summary>
        ///     Efetua o Login
        /// </summary>
        /// <param name="log">Login requerido</param>
        /// <returns>Token criado</returns>
        /// <response code="200">Token criado!</response>
        /// <response code="401">Username/Password incorrétos!</response>
        /// <response code="404">Username/Password não encontrados!</response>
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Logar([FromBody] Login log)
        {
            Login login = _context.Logins.FirstOrDefault(login => login.Username == log.Username && login.Password == log.Password);
            if (login != null)
            {
                if (login.Token.IsNullOrEmpty())
                {
                    login.Token = _jwtAuth.Authenticate(log.Username, log.Password, _context);
                    _context.Logins.Update(login);
                    _context.SaveChanges();

                    return Ok(login);
                }

                return BadRequest();
            }
            return Unauthorized();
        }

        /// <summary>
        ///     Confere as permissões do usuario logado
        /// </summary>
        /// <returns>Lista de permissões</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="404">Login não encontrado</response>
        [AllowAnonymous]
        [HttpGet("ConferirPermissoes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFuncionalidadeByToken()
        {
            Login log = await _context.Logins
                .FirstOrDefaultAsync(log => log.Token.Length > 0);
            if (log != null)
            {
                Usuario user = await _context.Usuarios
                    .FirstOrDefaultAsync(user => user.LoginId == log.Id);
                Cargo cargo = await _context.Cargos
                    .AsNoTracking()
                    .Include(cargo => cargo.Funcionalidades)
                    .FirstOrDefaultAsync(cargo => cargo.Id == user.CargoId);
                List<Funcionalidade> funcs = await _context.Funcionalidades
                    .AsNoTracking()
                    .Where(func => func.CargoId == cargo.Id)
                    .ToListAsync();

                return Ok(funcs);
            }
            return NotFound();
        }

        /// <summary>
        ///     Seleciona o usuário logado
        /// </summary>
        /// <returns>Usuario logado</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="404">Login não encontrado</response>
        [AllowAnonymous]
        [HttpGet("ConferirUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuarioByToken()
        {
            Login log = await _context.Logins
                .FirstOrDefaultAsync(log => log.Token.Length > 0);
            if (log == null)
                return NotFound();
            Usuario user = await _context.Usuarios
                .FirstOrDefaultAsync(user => user.LoginId == log.Id);

            if (log != null)
                return Ok(user);
            return NotFound();
        }

        /// <summary>
        ///     Efetua logout
        /// </summary>
        /// <returns>Nada</returns>
        /// <response code="204">Sucesso!</response>
        /// <response code="400">Erro ao efetuar o logout!</response>
        [AllowAnonymous]
        [HttpPatch("Logout")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Logout([FromBody] JsonPatchDocument<Login> input)
        {
            Login log = await _context.Logins.FirstOrDefaultAsync(log => log.Token.Length > 0);

            if (log != null)
            {
                log.Token = null;

                input.ApplyTo(log, ModelState);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            return BadRequest();
        }
    }
}