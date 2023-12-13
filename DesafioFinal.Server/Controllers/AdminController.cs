using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly HospitalContext _context;

        public AdminController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Cadastra um novo usuário
        /// </summary>
        /// <param name="user">Usuário a ser adicionado</param>
        /// <returns>Usuário adicionado</returns>
        /// <response code="201">Criado com Sucesso</response>
        /// <response code="400">Erro ao efetuar o cadastro</response>
        [HttpPost("CadastrarUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CadastrarUsuario([FromBody] Usuario user)
        {
            try
            {
                _context.Usuarios.Add(user);
                _context.SaveChanges();
                return CreatedAtAction(nameof(SelecionarUsuario), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao tentar efetuar a adição do usuário. Error: " + ex.Message);
            }
        }

        /// <summary>
        ///     Seleciona o usuário através de seu numero de identificação
        /// </summary>
        /// <param name="id">Numero de identificação da pessoa a ser selecionada</param>
        /// <returns>Usuário selecionado</returns>
        /// <response code="200">Usuário retornado com sucesso</response>
        /// <response code="404">Erro ao selecionar o usuário</response>
        [HttpGet("SelecionarUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SelecionarUsuario([FromRoute] int id)
        {
            Usuario user = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (user != null)
                return Ok(user);
            return NotFound("Esse usuário não existe! Tente Novamente.");
        }

        [HttpPost("AdicionarCargo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarCargo([FromBody] Cargos cargo)
        {
            try
            {
                _context.Cargos.Add(cargo);
                _context.SaveChanges();
                return CreatedAtAction(nameof(SelecionarCargo), new { num = cargo.Numero }, cargo);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao tentar efetuar a adição do usuário. Error: " + ex.Message);
            }
        }

        [HttpGet("SelecionarCargo/{num}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SelecionarCargo([FromRoute] int num)
        {
            Cargos cargo = _context.Cargos.FirstOrDefault(c => c.Numero == num);
            if (cargo != null)
                return Ok(cargo);
            return NotFound("Esse cargo não existe! Tente Novamente.");
        }
    }
}
