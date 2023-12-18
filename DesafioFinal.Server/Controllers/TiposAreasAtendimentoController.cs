﻿using DesafioFinal.Server.Data;
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
        [HttpPost("Adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarTipoAreaAtendimento([FromBody] TipoAreaAtendimento taa)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a adição do tipo de área de atendimento.");

            try
            {
                await _context.TiposAreasAtendimento.AddAsync(taa);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarTipoAreaAtendimento),
                    new { cod = taa.COD }, taa);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro interno ao tentar efetuar a adição do tipo de área de atendimento.\n" +
                    "Error:\n\t" +
                    ex.Message);
            }
        }

        /// <summary>
        ///     Exibe todos os tipos de áreas de atendimento adicionados
        /// </summary>
        /// <returns>Lista de tipos de áreas de atendimento</returns>
        /// <response code="200">Sucesso!</response>
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
        /// <param name="cod">Código do tipo de área de atendimento a ser selecionada</param>
        /// <returns>Tipo de área de atendimento selecionado</returns>
        /// <response code="200">Tipo de área de atendimento retornado com sucesso!</response>
        /// <response code="404">Código não encontrado!</response>
        [HttpGet("Selecionar/{cod}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarTipoAreaAtendimento([FromRoute] int cod)
        {
            TipoAreaAtendimento taa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .Include(taa => taa.AreasAtendimento)
                .FirstOrDefaultAsync(taa => taa.COD == cod);
            return taa != null ? Ok(taa) : NotFound("Esse tipo de área de atendimento não existe! Tente Novamente.");
        }

        /// <summary>
        ///     Altera o tipo de área de atendimento através de seu código
        /// </summary>
        /// <param name="cod">Código do tipo de área de atendimento a ser alterado</param>
        /// <param name="input">Tipo de área de atendimento a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="404">Código não encontrado!</response>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        [HttpPut("Alterar/{cod}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarTipoAreaAtendimento([FromRoute] int cod, [FromBody] TipoAreaAtendimento input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a alteração do tipo de área de atendimento.");

            TipoAreaAtendimento taa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(taa => taa.COD == cod);

            if (taa != null)
            {
                try
                {
                    taa.Nome = input.Nome;

                    _context.TiposAreasAtendimento.Update(taa);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar a alteração do Tipo de área de atendimento.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Tipo de área de atendimento não encontrado!");
        }

        /// <summary>
        ///     Desativa o Tipo de área de atendimento
        /// </summary>
        /// <param name="cod">Código do Tipo de área de atendimento</param>
        /// <returns>Nada</returns>
        /// <response code="404">Código não encontrado!</response>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        [HttpDelete("Desativar/{cod}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarTipoAreaAtendimento([FromRoute] int cod)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a desativação do tipo de área de atendimento.");

            TipoAreaAtendimento taa = await _context.TiposAreasAtendimento
                .AsNoTracking()
                .FirstOrDefaultAsync(taa => taa.COD == cod);

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
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar o cadastro do Tipo de área de atendimento.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Tipo de área de atendimento não encontrada!");
        }
    }
}