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
        ///     Cadastra uma nova área de atendimento
        /// </summary>
        /// <param name="aa">Área de atendimento a ser adicionado</param>
        /// <returns>Área de atendimento adicionado</returns>
        /// <response code="201">Criado com Sucesso!</response>
        /// <response code="400">Erro ao efetuar o cadastro!</response>
        [HttpPost("Cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarAreaAtendimento([FromBody] AreaAtendimento aa)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a adição do tipo de área de atendimento.");

            try
            {
                await _context.AreasAtendimento.AddAsync(aa);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarAreaAtendimento),
                    new { num = aa.Numero }, aa);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro interno ao tentar efetuar a adição do tipo de área de atendimento.\n" +
                    "Error:\n\t" +
                    ex.Message);
            }
        }

        /// <summary>
        ///     Exibe todas as áreas de atendimento adicionados
        /// </summary>
        /// <returns>Lista de tipos de áreas de atendimento</returns>
        /// <response code="200">Sucesso!</response>
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
        ///     Seleciona a área de atendimento através de seu número de indentificação 
        /// </summary>
        /// <param name="num">Número de indentificação  do tipo de área de atendimento a ser selecionada</param>
        /// <returns>Área de atendimento selecionado</returns>
        /// <response code="200">Área de atendimento retornado com sucesso!</response>
        /// <response code="404">Número de indentificação não encontrado!</response>
        [HttpGet("Selecionar/{num}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarAreaAtendimento([FromRoute] int num)
        {
            AreaAtendimento aa = await _context.AreasAtendimento
                .AsNoTracking()
                .Include(aa => aa.TipoAreaAtendimento)
                .FirstOrDefaultAsync(aa => aa.Numero == num);
            return aa != null ? Ok(aa) : NotFound("Esse tipo de área de atendimento não existe! Tente Novamente.");
        }

        /// <summary>
        ///     Altera a área de atendimento através de seu número de indentificação
        /// </summary>
        /// <param name="num">Número da área de atendimento a ser alterado</param>
        /// <param name="input">Área de atendimento a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="404">Número de identificação não encontrado!</response>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        [HttpPut("Alterar/{num}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarAreaAtendimento([FromRoute] int num, [FromBody] AreaAtendimento input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a alteração da área de atendimento.");

            AreaAtendimento aa = await _context.AreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(aa => aa.Numero == num);

            if (aa != null)
            {
                try
                {

                    _context.AreasAtendimento.Update(aa);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar a alteração da área de atendimento.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Área de atendimento não encontrado!");
        }

        /// <summary>
        ///     Desativa a área de atendimento
        /// </summary>
        /// <param name="num">Número de indentificação da área de atendimento</param>
        /// <returns>Nada</returns>
        /// <response code="404">Número de indentificação não encontrado!</response>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        [HttpDelete("Desativar/{num}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarAreaAtendimento([FromRoute] int num)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a desativação da área de atendimento.");

            AreaAtendimento aa = await _context.AreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(aa => aa.Numero == num);

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
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar a desativação de área de atendimento.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Área de atendimento não encontrada!");
        }
    }
}
