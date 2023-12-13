using AutoMapper;
using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;

        public AdminController(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                return CreatedAtAction(nameof(SelecionarUsuario),
                    new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao tentar efetuar o cadastro do usuário. Error:\n\t" + 
                    ex.Message);
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
            Usuario user = _context.Usuarios
                .Where(user => user.CargoId == user.CargoId)
                .Include(user => user.Cargo)   
                .FirstOrDefault(user => user.Id == id);
            return user != null ? Ok(user) : NotFound("Esse usuário não existe! Tente Novamente.");
        }

        /// <summary>
        ///     Adiciona um novo cargo
        /// </summary>
        /// <param name="cargo">Cargo a ser adicionado</param>
        /// <returns>Cargo adicionado</returns>
        /// <response code="201">Cargo criado com sucesso</response>
        /// <response code="400">Erro ao efetuar a adição</response>
        [HttpPost("AdicionarCargo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarCargo([FromBody] Cargos cargo)
        {
            try
            {
                _context.Cargos.Add(cargo);
                _context.SaveChanges();
                return CreatedAtAction(nameof(SelecionarCargo),
                    new { num = cargo.Numero }, cargo);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao tentar efetuar a adição do cargo. Error:\n\t" +
                    ex.Message);
            }
        }

        /// <summary>
        ///     Seleciona o cargo
        /// </summary>
        /// <param name="num">Número do cargo especificado</param>
        /// <returns>O cargo com o número correspondente</returns>
        /// <response code="200">Cargo retornado com sucesso</response>
        /// <response code="404">Cargo não encontrado</response>
        [HttpGet("SelecionarCargo/{num}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SelecionarCargo([FromRoute] int num)
        {
            Cargos cargo = _context.Cargos
                .Include(cargo => cargo.Usuarios)
                .FirstOrDefault(cargo => cargo.Numero == num);
            return cargo != null ? Ok(cargo) : NotFound("Esse cargo não existe! Tente Novamente.");
        }
    }
}
