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

        public CargosController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Adiciona um novo cargo
        /// </summary>
        /// <param name="cargo">Cargo a ser adicionado</param>
        /// <returns>Cargo adicionado</returns>
        /// <response code="201">Cargo criado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a adição!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpPost("Adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarCargo([FromBody] Cargo cargo)
        {
            try
            {
                await _context.Cargos.AddAsync(cargo);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarCargo),
                    new { id = cargo.Id }, cargo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///     Exibe todos os cargos adicionados
        /// </summary>
        /// <returns>Lista de cargos</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirCargos()
        {
            List<Cargo> lstCargos = await _context.Cargos
                .AsNoTracking()
                .Include(cargo => cargo.Usuarios)
                .ToListAsync();
            return Ok(lstCargos);
        }

        /// <summary>
        ///     Seleciona o cargo adicionado
        /// </summary>
        /// <param name="id">Indentificador do cargo</param>
        /// <returns>Cargo selecionado</returns>
        /// <response code="200">Cargo selecionado com sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Cargo não encontrado!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarCargo([FromRoute] int id)
        {
            Cargo cargo = await _context.Cargos
                .Include(cargo => cargo.Usuarios)
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Id == id);

            if (cargo != null)
                return Ok(cargo);
            return NotFound();
        }

        /// <summary>
        ///     Altera o cargo
        /// </summary>
        /// <param name="id">Indentificador do cargo a ser alterado</param>
        /// <param name="input">Cargo a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpPut("Alterar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarCargo([FromRoute] int id, [FromBody] Cargo input)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Cargo cargo = await _context.Cargos
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Id == id);

            if (cargo != null)
            {
                try
                {
                    cargo.Nome = input.Nome;

                    _context.Cargos.Update(cargo);
                    await _context.SaveChangesAsync();
                    return Ok(cargo);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return NotFound("Cargo não encontrado!");
        }

        /// <summary>
        ///     Desativa o cargo (Guarda o resultado em outra tabela)
        /// </summary>
        /// <param name="id">Identificador do cargo</param>
        /// <returns>Nada</returns>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        /// <response code="401">Erroautorização!</response>
        /// <response code="404">Indentificador não encontrado!</response>
        [HttpDelete("Desativar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarCargo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a desativação do cargo.");

            Cargo cargo = await _context.Cargos
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Id == id);

            if (cargo != null)
            {
                try
                {
                    _context.HistoricoCargos.AddAsync(new()
                    {
                        Nome = cargo.Nome,
                    });
                    _context.Cargos.Remove(cargo);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return NotFound("Cargo não encontrado!");
        }
    }
}