using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        /// <response code="201">Cargo criado com sucesso</response>
        /// <response code="400">Erro ao efetuar a adição</response>
        [HttpPost("AdicionarCargo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionarCargo([FromBody] Cargos cargo)
        {
            try
            {
                await _context.Cargos.AddAsync(cargo);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarCargo),
                    new { num = cargo.Numero }, cargo);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao tentar efetuar a adição do cargo. Error:\n\t" +
                    ex.Message);
            }
        }


        /// <summary>
        ///     Exibe todos os cargos adicionados
        /// </summary>
        /// <returns>Lista de cargos</returns>
        /// <response code="200">Sucesso!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirCargo()
        {
            List<Cargos> lstCargos = await _context.Cargos
                .AsNoTracking()
                .Include(cargo => cargo.Usuarios)
                .ToListAsync();
            return Ok(lstCargos);
        }

        /// <summary>
        ///     Seleciona o cargo adicionado
        /// </summary>
        /// <param name="num">Número de identificação do cargo</param>
        /// <returns>Cargo selecionado</returns>
        /// <response code="200">Cargo selcionado com sucesso!</response>
        /// <response code="404">Cargo não encontrado!</response>
        [HttpGet("Selecionado/{num}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarCargo([FromRoute] int num)
        {
            Cargos cargo = await _context.Cargos
                .Include(cargo => cargo.Usuarios)
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Numero == num);

            if (cargo != null)
                return Ok(cargo);
            return NotFound("Esse cargo não existe! Tente novamente.");
        }

        /// <summary>
        ///     Altera o cargo através de seu numero de identificação
        /// </summary>
        /// <param name="num">Número de indetificação do cargo a ser alterado</param>
        /// <param name="input">Cargo a ser alterado</param>
        /// <returns>Nada</returns>
        /// <response code="404">Identificador não encontrado!</response>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        [HttpPut("{num}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarUsuario([FromRoute] int num, [FromBody] Cargos input)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a alteração do cargo.");

            Cargos cargo = await _context.Cargos
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Numero == num);

            if (cargo != null)
            {
                try
                {
                    cargo.Nome = input.Nome;

                    _context.Cargos.Update(cargo);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar a alteração do cargo.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Cargo não encontrado!");
        }

        /// <summary>
        ///     Desativa o cargo (Guarda o resultado em outra tabela)
        /// </summary>
        /// <param name="num">Número de identificador do cargo</param>
        /// <returns>Nada</returns>
        /// <response code="404">Número de identificação não encontrado!</response>
        /// <response code="204">Desativdo com sucesso!</response>
        /// <response code="400">Erro ao efetuar a dasativação!</response>
        [HttpDelete("{num}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DesativarCargo([FromRoute] int num)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a desativação do cargo.");

            Cargos cargo = await _context.Cargos
                .AsNoTracking()
                .FirstOrDefaultAsync(cargo => cargo.Numero == num);

            if (cargo != null)
            {
                try
                {
                    _context.Cargos.Remove(cargo);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar o cadastro do cargo.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Cargo não encontrado!");
        }
    }
}
