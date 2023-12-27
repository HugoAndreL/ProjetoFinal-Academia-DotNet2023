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
                return BadRequest("Ocorreu um erro ao tentar efetuar o cadastro do usuário.");

            try
            {
                string[] nome = user.Nome.ToLower().Split();
                user.Senha = $"Hospital@{nome[0]}.{nome[nome.Length - 1]}";

                Login login = new()
                {
                    Username = user.Nome,
                    Password = user.Senha,
                };
                await _context.Logins.AddAsync(login);
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(SelecionarUsuario),
                    new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                .FirstOrDefaultAsync(user => user.Id == id);
            return user != null ? Ok(user) : NotFound("Usuário não encontrado!");
        }

        /// <summary>
        ///     Altera o usuário através de seu numero de Indentificador
        /// </summary>
        /// <param name="id">Indetificador do Usuário a ser alterado</param>
        /// <param name="input">Usuário a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpPut("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarUsuario([FromRoute] int id, [FromBody] Usuario input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a alteração do usuário.");

            Usuario user = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);

            if (user != null)
            {
                try
                {
                    user.Nome = input.Nome;
                    user.Email = input.Email;
                    user.CargoId = input.CargoId;
                    user.Senha = input.Senha;

                    Login login = new()
                    {
                        Username = user.Nome,
                        Password = user.Senha
                    };

                    _context.Logins.Update(login);
                    _context.Usuarios.Update(user);
                    await _context.SaveChangesAsync();
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar a alteração do usuário.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Usuário não encontrado!");
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
                return BadRequest("Ocorreu um erro ao tentar efetuar a desativação do usuário.");

            Usuario user = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);

            if (user != null)
            {
                try
                {
                    await _context.HistoricoUsuarios.AddAsync(new()
                    {
                        Nome = user.Nome,
                        Email = user.Email
                    });
                    _context.Usuarios.Remove(user);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar o cadastro do usuário.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Usuário não encontrado!");
        }
    }
}
