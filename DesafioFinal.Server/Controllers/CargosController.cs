using AutoMapper;
using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;

        public CargosController(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<IActionResult> AdicionarCargo([FromBody] Cargos cargo)
        {
            try
            {
                await _context.Cargos.AddAsync(cargo);
                await _context.SaveChangesAsync();
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
        public async Task<IActionResult> SelecionarCargo([FromRoute] int num)
        {
            Cargos cargo = await _context.Cargos
                .Include(cargo => cargo.Usuarios)
                .FirstOrDefaultAsync(cargo => cargo.Numero == num);
            return cargo != null ? Ok(cargo) : NotFound("Esse cargo não existe! Tente Novamente.");
        }
    }
}
