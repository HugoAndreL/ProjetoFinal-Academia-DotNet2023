using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposAreasAtendimentoController : ControllerBase
    {
        private readonly HospitalContext _context;

        public TiposAreasAtendimentoController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Cadastra um novo tipo de área de atendimento
        /// </summary>
        /// <param name="taa">Tipo de área de atendimento a ser adicionado</param>
        /// <returns>Tipo de área de atendimento adicionado</returns>
        /// <response code="201">Criado com Sucesso!</response>
        /// <response code="400">Erro ao efetuar o cadastro!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpPost("Adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarTipoAreaAtendimento([FromBody] TipoAreaAtendimento taa)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _context.TiposAreasAtendimento.AddAsync(taa);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarTipoAreaAtendimento),
                    new { id = taa.Id }, taa);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///     Exibe todos os tipos de áreas de atendimento adicionados
        /// </summary>
        /// <returns>Lista de tipos de áreas de atendimento</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirTipoAreaAtendimento()
        {
            List<TipoAreaAtendimento> lstTaa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .Include(taa => taa.AreasAtendimento)
                .ToListAsync();
            return Ok(lstTaa);
        }

        /// <summary>
        ///     Seleciona o tipo de área de atendimento através de seu código
        /// </summary>
        /// <param name="id">Identificador da área de atendimento a ser selecionada</param>
        /// <returns>Tipo de área de atendimento selecionado</returns>
        /// <response code="200">Tipo de área de atendimento retornado com sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarTipoAreaAtendimento([FromRoute] int id)
        {
            TipoAreaAtendimento taa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .Include(taa => taa.AreasAtendimento)
                .FirstOrDefaultAsync(taa => taa.Id == id);
            return taa != null ? Ok(taa) : NotFound();
        }

        /// <summary>
        ///     Altera o tipo de área de atendimento através de seu código
        /// </summary>
        /// <param name="id">Identificador do tipo de área de atendimento a ser alterado</param>
        /// <param name="input">Tipo de área de atendimento a ser alterado</param>
        /// <returns>Tipo de área de atendimento alterado</returns>
        /// <response code="200">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpPut("Alterar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarTipoAreaAtendimento([FromRoute] int id, [FromBody] TipoAreaAtendimento input)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            TipoAreaAtendimento taa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(taa => taa.Id == id);

            if (taa != null)
            {
                try
                {
                    taa.Nome = input.Nome;

                    _context.TiposAreasAtendimento.Update(taa);
                    await _context.SaveChangesAsync();
                    return Ok(taa);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        /// <summary>
        ///     Desativa o tipo de área de atendimento
        /// </summary>
        /// <param name="id">Identificador do tipo de área de atendimento</param>
        /// <returns>Nada</returns>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Identificador não encontrado!</response>
        [HttpDelete("Desativar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarTipoAreaAtendimento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            TipoAreaAtendimento taa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(taa => taa.Id == id);

            if (taa != null)
            {
                try
                {
                    _context.TiposAreasAtendimento.Remove(taa);
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