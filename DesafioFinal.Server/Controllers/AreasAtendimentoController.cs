using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasAtendimentoController : ControllerBase
    {
        private readonly HospitalContext _context;

        public AreasAtendimentoController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Adiciona uma nova área de atendimento
        /// </summary>
        /// <param name="aa">Área de atendimento a ser adicionado</param>
        /// <returns>Área de atendimento adicionado</returns>
        /// <response code="201">Criado com Sucesso!</response>
        /// <response code="400">Erro ao efetuar o cadastro!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpPost("Adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarAreaAtendimento([FromBody] AreaAtendimento aa)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _context.AreasAtendimento.AddAsync(aa);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarAreaAtendimento),
                    new { id = aa.Id }, aa);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel criar a area de atendimento");
            }
        }

        /// <summary>
        ///     Exibe todas as áreas de atendimento adicionados
        /// </summary>
        /// <returns>Lista de tipos de áreas de atendimento</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirAreaAtendimento()
        {
            List<AreaAtendimento> lstAa = await _context.AreasAtendimento
                .AsNoTracking()
                .Include(aa => aa.TipoAreaAtendimento)
                .ToListAsync();
            return Ok(lstAa);
        }

        /// <summary>
        ///     Seleciona a área de atendimento
        /// </summary>
        /// <param name="id">Indentificador do tipo de área de atendimento a ser selecionada</param>
        /// <returns>Área de atendimento selecionado</returns>
        /// <response code="200">Área de atendimento retornado com sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Indentificador não encontrado!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarAreaAtendimento([FromRoute] int id)
        {
            AreaAtendimento aa = await _context.AreasAtendimento
                .AsNoTracking()
                .Include(aa => aa.TipoAreaAtendimento)
                .FirstOrDefaultAsync(aa => aa.Id == id);
            return aa != null ? Ok(aa) : NotFound();
        }

        /// <summary>
        ///     Altera a área de atendimento
        /// </summary>
        /// <param name="id">Identificador da área de atendimento a ser alterado</param>
        /// <param name="input">Área de atendimento a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="200">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Indentificador não encontrado!</response>
        [HttpPut("Alterar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarAreaAtendimento([FromRoute] int id, [FromBody] AreaAtendimento input)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            AreaAtendimento aa = await _context.AreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(aa => aa.Id == id);

            if (aa != null)
            {
                try
                {
                    aa.Nome = input.Nome;
                    aa.TipoAreaAtendimentoId = input.TipoAreaAtendimentoId;

                    _context.AreasAtendimento.Update(aa);
                    await _context.SaveChangesAsync();
                    return Ok(aa);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound();
        }

        /// <summary>
        ///     Desativa a área de atendimento
        /// </summary>
        /// <param name="id">Indentificador da área de atendimento</param>
        /// <returns>Nada</returns>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Indentificador não encontrado!</response>
        [HttpDelete("Desativar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarAreaAtendimento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            AreaAtendimento aa = await _context.AreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(aa => aa.Id == id);

            if (aa != null)
            {
                try
                {
                    _context.AreasAtendimento.Remove(aa);
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