using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionalidadesController : ControllerBase
    {
        private readonly HospitalContext _context;

        public FuncionalidadesController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Adiciona uma nova funcionalidade
        /// </summary>
        /// <param name="funcionalidade">Funcionalidade a ser adicionada</param>
        /// <returns>Funcionalidade adicionada</returns>
        /// <response code="201">Funcionalidade criada com sucesso!</response>
        /// <response code="400">Erro ao efetuar a adição!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpPost("Adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarFuncionalidade([FromBody] Funcionalidade funcionalidade)
        {
            try
            {
                await _context.Funcionalidades.AddAsync(funcionalidade);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarFuncionalidade),
                    new { id = funcionalidade.Id }, funcionalidade);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///     Exibe todas as funcionalidades adicionadas
        /// </summary>
        /// <returns>Lista de funcionalidades</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirFuncionalidades()
        {
            List<Funcionalidade> lstFuncionalidades = await _context.Funcionalidades
                .Include(funcs => funcs.Cargo)
                .AsNoTracking()
                .ToListAsync();
            return Ok(lstFuncionalidades);
        }

        /// <summary>
        ///     Seleciona a funcionalidade
        /// </summary>
        /// <param name="id">Indentificador da funcionalidade</param>
        /// <returns>Funcionalidade selecionada</returns>
        /// <response code="200">Funcionalidade selecionada com sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Funcionalidade não encontrada!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarFuncionalidade([FromRoute] int id)
        {
            Funcionalidade funcionalidade = await _context.Funcionalidades
                .Include(func => func.Cargo)
                .AsNoTracking()
                .FirstOrDefaultAsync(funcionalidade => funcionalidade.Id == id);

            if (funcionalidade != null)
                return Ok(funcionalidade);
            return NotFound();
        }

        /// <summary>
        ///     Associa funcionalidade a algum cargo
        /// </summary>
        /// <param name="id">Indentificador da funcionalidade a ser associado</param>
        /// <param name="input">Identificador da associação</param>
        /// <returns>Funcionalidade alterada</returns>
        /// <response code="200">Associado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a associação!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpPatch("Associar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AssociarFuncionalidade([FromRoute] int id, [FromBody] JsonPatchDocument<Funcionalidade> input)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Funcionalidade func = await _context.Funcionalidades
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Id == id);

            if (func != null)
            {
                try
                {
                    input.ApplyTo(func, ModelState);

                    _context.Funcionalidades.Update(func);
                    await _context.SaveChangesAsync();
                    return Ok(func);
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
