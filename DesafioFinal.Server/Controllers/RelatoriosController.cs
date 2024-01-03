using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly HospitalContext _context;

        public RelatoriosController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Gera um CSV
        /// </summary>
        /// <param name="id">Identificador do Relatório</param>
        /// <returns>CSV Criado</returns>
        /// <response code="200">Arquivo gerado!</response>
        /// <response code="404">Dados para o relatório não encontrado!</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GerarCSV([FromRoute] int id)
        {
            Relatorio rel = await _context.Relatorios.FirstOrDefaultAsync(rel => rel.Id == id);
            
            if (rel != null)
            {
                StreamWriter writer = new($@"C:\workspace\DesafioFinal\CSVs\{rel.Nome}.csv");
                writer.WriteLine("Tempo de Espera; Taxa de Utilizacao (Guiche); Taxa de Utilizacao (Triagem); Taxa de Utilizacao (Consultorio)");
                writer.WriteLine($"{rel}");
                writer.Close();

                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        ///     Adiciona um novo relatório
        /// </summary>
        /// <param name="rel">Relatório a ser adicionado</param>
        /// <returns>Relatório adicionado</returns>
        /// <response code="201">Relatório criado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a adição!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpPost("Adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostRelatorio([FromBody] Relatorio rel)
        {
            try
            {
                rel.Nome = $"{rel.Nome}{rel.DataRelatorio.Replace("/", "-")}";
                await _context.Relatorios.AddAsync(rel);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarRelatorio),
                    new { id = rel.Id }, rel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///     Exibe todos os relatórios adicionados
        /// </summary>
        /// <returns>Lista de relatórios</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirRelatorio()
        {
            List<Relatorio> lstRels = await _context.Relatorios
                .AsNoTracking()
                .ToListAsync();
            return Ok(lstRels);
        }

        /// <summary>
        ///     Seleciona o relatório adicionado
        /// </summary>
        /// <param name="id">Indentificador do relatório</param>
        /// <returns>Relatório selecionado</returns>
        /// <response code="200">Relatório selecionado com sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        /// <response code="404">Indentificador não encontrado!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarRelatorio([FromRoute] int id)
        {
            Relatorio rel = await _context.Relatorios
                .AsNoTracking()
                .FirstOrDefaultAsync(rel => rel.Id == id);

            if (rel != null)
                return Ok(rel);
            return NotFound();
        }
    }
}
