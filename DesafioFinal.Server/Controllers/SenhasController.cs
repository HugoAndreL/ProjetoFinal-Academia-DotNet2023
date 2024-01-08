using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenhasController : ControllerBase
    {
        private readonly HospitalContext _context;

        public SenhasController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Gera uma nova senha
        /// </summary>
        /// <param name="senha">Senha a ser adicionado</param>
        /// <returns>Senha adicionado</returns>
        /// <response code="201">Cargo criado com sucesso</response>
        /// <response code="400">Erro ao efetuar a adição</response>
        [HttpPost("Gerar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> GerarSenha([FromBody] Senha senha)
        {
            try
            {
                // Auto preenchendo a ordem
                int order = 1;
                foreach (Senha ordem in _context.Senhas.ToList())
                    order++;

                senha.Ordem = order;
                await _context.Senhas.AddAsync(senha);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(ProximaSenha),
                    new { id = senha.Id }, senha);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        ///     Exibe todos as senhas geradas
        /// </summary>
        /// <returns>Lista de senhas</returns>
        /// <response code="200">Sucesso!</response>
        /// <response code="401">Erro de autorização!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirSenhas()
        {
            List<Senha> lstSenhas = await _context.Senhas
                .AsNoTracking()
                .OrderByDescending(senha => senha.Prioridade)
                .ThenBy(senha => senha.Id)
                .ToListAsync();

            return Ok(lstSenhas);
        }

        /// <summary>
        ///     Seleciona a próxima senha
        /// </summary>
        /// <returns>Senha selecionada</returns>
        /// <response code="200">Senha seguinte selecionada com sucesso!</response>
        /// <response code="404">Senha não encontrada!</response>
        [HttpGet("Proxima")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ProximaSenha()
        {
            Senha senha = await _context.Senhas
                .AsNoTracking()
                .OrderByDescending(senha => senha.Prioridade)
                .ThenBy(senha => senha.Id)
                .FirstAsync();

            _context.Senhas.Remove(senha);
            await _context.HistoricoSenhas.AddAsync(new()
            {
                Prioridade = senha.Prioridade,
            });
            await _context.SaveChangesAsync();
            return Ok(senha);
        }

        /// <summary>
        ///     Rechama a senha
        /// </summary>
        /// <returns>Senha selecionada</returns>
        /// <response code="200">Senha rechamada com sucesso!</response>
        /// <response code="404">Senha não encontrada!</response>
        [HttpGet("Rechamar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecharmarSenha()
        {
            HistoricoSenha senhaRechamada = await _context.HistoricoSenhas
                .AsNoTracking()
                .OrderByDescending(senha => senha.Prioridade)
                .ThenBy(senha => senha.Id)
                .FirstAsync();

            _context.HistoricoSenhas.Remove(senhaRechamada);
            await _context.SaveChangesAsync();
            return Ok(senhaRechamada);
        }

        /// <summary>
        ///     Cancela a senha (Guarda o resultado em outra tabela)
        /// </summary>
        /// <param name="id">Número do identificador</param>
        /// <returns>Nada</returns>
        /// <response code="404">Indentificador não encontrado!</response>
        /// <response code="204">Cancelado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        [HttpDelete("Cancelar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CancelarSenha([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Senha senha = await _context.Senhas
                .AsNoTracking()
                .FirstOrDefaultAsync(senha => senha.Id == id);

            if (senha != null)
            {
                try
                {
                    _context.HistoricoSenhas.AddAsync(new()
                    {
                        Prioridade = senha.Prioridade
                    });
                    _context.Senhas.Remove(senha);
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