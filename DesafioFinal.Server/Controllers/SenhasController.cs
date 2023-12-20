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
                await _context.Senhas.AddAsync(senha);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(ChamarSenha),
                    new { id = senha.Id }, senha);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao tentar efetuar a geração da senha.");
            }
        }

        /// <summary>
        ///     Seleciona a senha gerada
        /// </summary>
        /// <param name="id">Indentificador da senha</param>
        /// <returns>Senha selecionada</returns>
        /// <response code="200">Senha selecionada com sucesso!</response>
        /// <response code="404">Senha não encontrada!</response>
        [HttpGet("Selecionar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChamarSenha([FromRoute] int id)
        {
            Senha senha = await _context.Senhas
                .AsNoTracking()
                .FirstOrDefaultAsync(senha => senha.Id == id);

            if (senha != null)
                return Ok(senha);
            return NotFound("Essa senha não existe! Tente novamente.");
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
        ///     Altera o tipo de prioridade
        /// </summary>
        /// <param name="id">Indentificador</param>
        /// <param name="senhaPatch">Prioridade desejada</param>
        /// <remarks>
        /// **Código:**
        /// ```
        /// [
        ///     {
        ///         "path": "/Prioridade",
        ///         "op": "replace",
        ///         "value": "Prioritaria"    
        ///     }
        /// ]
        /// ```
        /// </remarks>
        /// <returns>Nada</returns>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="404">Indentificador não encontrado!</response>
        /// <response code="400">Erro ao alterar a senha!</response>
        [HttpPatch("Prioridade/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AlterarPrioridade([FromRoute] int id, [FromBody] JsonPatchDocument<Senha> senhaPatch)
        {
            Senha senha = _context.Senhas.FirstOrDefault(senha => senha.Id == id);
            
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
                        Numero = senha.Numero,
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
