using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly HospitalContext _context;

        public UsuariosController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Cadastra um novo usuário
        /// </summary>
        /// <param name="user">Usuário a ser adicionado</param>
        /// <returns>Usuário adicionado</returns>
        /// <response code="201">Criado com Sucesso!</response>
        /// <response code="400">Erro ao efetuar o cadastro!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario user)
        {   
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                // Gerando a senha do usuario
                // Hugo Andre Lucena
                string[] nome = user.Nome.ToLower().Split();
                // hugo andre lucena
                // nome[0] = hugo
                // nome[2] = lucena
                // Hugo Andre Lucena = 3 Hugo Andre = 2 Hugo = 1
                user.Senha = $"Hospital@{nome[0]}.{nome[nome.Length - 1]}";

                Login login = new()
                {
                    Username = user.Nome,
                    Password = user.Senha,
                };

                await _context.Logins.AddAsync(login);
                await _context.SaveChangesAsync();

                user.LoginId = login.Id;

                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(SelecionarUsuario),
                    new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///     Exibe todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirUsuarios()
        {
            List<Usuario> lstUsuarios = await _context.Usuarios
                .AsNoTracking()
                .Include(user => user.Cargo)
                .Include(user => user.Login)
                .ToListAsync();

            return Ok(lstUsuarios);
        }

        /// <summary>
        ///     Seleciona o usuário através de seu numero de Indentificador
        /// </summary>
        /// <param name="id">Numero de Indentificador da pessoa a ser selecionada</param>
        /// <returns>Usuário selecionado</returns>
        /// <response code="200">Usuário retornado com sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Erro ao selecionar o usuário!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarUsuario([FromRoute] int id)
        {
            Usuario user = await _context.Usuarios
                .AsNoTracking()
                .Include(user => user.Cargo)
                .Include(user => user.Login)
                .FirstOrDefaultAsync(user => user.Id == id);

            return user != null ? Ok(user) : NotFound();
        }

        /// <summary>
        ///     Altera o usuário através de seu numero de Indentificador
        /// </summary>
        /// <param name="id">Indetificador do Usuário a ser alterado</param>
        /// <param name="input">Usuário a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="200">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpPut("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarUsuario([FromRoute] int id, [FromBody] Usuario input)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Usuario user = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);
            
            Login log = await _context.Logins
                .AsNoTracking()
                .FirstOrDefaultAsync(log => log.Id == user.LoginId);

            if (user != null)
            {
                try
                {
                    user.Nome = input.Nome;
                    user.Email = input.Email;
                    user.CargoId = input.CargoId;
                    user.Senha = input.Senha;

                    log.Username = user.Nome;
                    log.Password = user.Senha;

                    _context.Logins.Update(log);
                    _context.Usuarios.Update(user);
                    await _context.SaveChangesAsync();
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        /// <summary>
        ///     Desativa o usuário (Guarda o resultado em outra tabela)
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns>Nada</returns>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpDelete("Desativar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Usuario user = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);

            Login log = await _context.Logins
                .AsNoTracking()
                .FirstOrDefaultAsync(log => log.Id == user.LoginId);

            if (user != null)
            {
                try
                {
                    await _context.HistoricoUsuarios.AddAsync(new()
                    {
                        Nome = user.Nome,
                        Email = user.Email
                    });

                    _context.Logins.Remove(log);

                    _context.Usuarios.Remove(user);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }
    }
}