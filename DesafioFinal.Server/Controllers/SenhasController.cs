using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        /// <returns>Cargo adicionado</returns>
        /// <response code="201">Cargo criado com sucesso</response>
        /// <response code="400">Erro ao efetuar a adição</response>
        [HttpPost("Gerar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> GerarSenha([FromBody] Senha senha)
        {
            try
            {
                // Auto preenchendo a ordem e o id
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

            if (senha != null)
            {
                _context.Senhas.Remove(senha);
                await _context.HistoricoSenhas.AddAsync(new()
                {
                    Prioridade = senha.Prioridade,
                });
                await _context.SaveChangesAsync();
                return Ok(senha);
            }
            return NotFound("Essa senha não existe! Tente novamente.");
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
            if (senhaRechamada != null)
            {
                _context.HistoricoSenhas.Remove(senhaRechamada);
                await _context.SaveChangesAsync();
                return Ok(senhaRechamada);
            }
            return NotFound();
        }

        /// <summary>
        ///     Altera a ordem
        /// </summary>
        /// <param name="id">Indentificador</param>
        /// <param name="senhaPatch">Ordem desejada</param>
        /// <remarks>
        /// **Código:**
        /// ```
        /// [
        ///     {
        ///         "path": "/Ordem",
        ///         "op": "replace",
        ///         "value": 2
        ///     }
        /// ]
        /// ```
        /// </remarks>
        /// <returns>Nada</returns>
        /// <response code="204">Alterado com Sucesso!</response>
        [HttpPatch("Ordem/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AlterarOrdem([FromRoute] int id, [FromBody] JsonPatchDocument<Senha> senhaPatch)
        {
            Senha senha = await _context.Senhas.FirstOrDefaultAsync(senha => senha.Id == id);

            if (senha != null)
            {
                senhaPatch.ApplyTo(senha, ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound("Essa senha não existe! Tente novamente.");
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
                return BadRequest("Ocorreu um erro ao tentar efetuar a desativação da senha.");

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
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar cancelar a senha.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Senha não encontrado!");
        }


    }
}
