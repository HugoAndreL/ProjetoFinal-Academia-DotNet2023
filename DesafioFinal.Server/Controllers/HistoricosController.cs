using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricosController : ControllerBase
    {
        private readonly HospitalContext _context;

        public HistoricosController(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Exibe todos os usuário que foram desativados
        /// </summary>
        /// <returns>Lista de usuários desativados</returns>
        /// <response code="200">Sucesso!</response>
        [HttpGet("Usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirHistoricoUsuarios()
        {
            List<HistoricoUsuario> lstUsuarios = await _context.HistoricoUsuarios
                .AsNoTracking()
                .ToListAsync();
            return Ok(lstUsuarios);
        }

        /// <summary>
        ///     Exibe todos os cargos que foram desativados
        /// </summary>
        /// <returns>Lista de cargos desativados</returns>
        /// <response code="200">Sucesso!</response>
        [HttpGet("Cargos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirHistoricoCargos()
        {
            List<HistoricoCargo> lstCargos = await _context.HistoricoCargos
                .AsNoTracking()
                .ToListAsync();
            return Ok(lstCargos);
        }

        /// <summary>
        ///     Exibe todos as senhas que foram canceladas
        /// </summary>
        /// <returns>Lista de senhas canceladas</returns>
        /// <response code="200">Sucesso!</response>
        [HttpGet("Senhas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirHistoricoSenhas()
        {
            List<HistoricoSenha> lstSenhas = await _context.HistoricoSenhas
                .AsNoTracking()
                .OrderByDescending(lstSenha => lstSenha.Prioridade)
                .ThenBy(lstSenha => lstSenha.Id)
                .ToListAsync();
            return Ok(lstSenhas);
        }
    }
}
