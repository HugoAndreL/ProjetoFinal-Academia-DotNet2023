﻿using AutoMapper;
using DesafioFinal.Server.Data;
using DesafioFinal.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;

        public UsuarioController(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Cadastra um novo usuário
        /// </summary>
        /// <param name="user">Usuário a ser adicionado</param>
        /// <returns>Usuário adicionado</returns>
        /// <response code="201">Criado com Sucesso!</response>
        /// <response code="400">Erro ao efetuar o cadastro!</response>
        [HttpPost("CadastrarUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar o cadastro do usuário.");

            try
            {
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(SelecionarUsuario),
                    new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro interno ao tentar efetuar o cadastro do usuário.\n" +
                    "Error:\n\t" +
                    ex.Message);
            }
        }

        /// <summary>
        ///     Exibe todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Sucesso!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExibirUsuarios()
        {
            List<Usuario> lstUsuarios = await _context.Usuarios
                .AsNoTracking()
                .Include(user => user.Cargo)
                .ToListAsync();
            return Ok(lstUsuarios);
        }

        /// <summary>
        ///     Seleciona o usuário através de seu numero de identificação
        /// </summary>
        /// <param name="id">Numero de identificação da pessoa a ser selecionada</param>
        /// <returns>Usuário selecionado</returns>
        /// <response code="200">Usuário retornado com sucesso!</response>
        /// <response code="404">Erro ao selecionar o usuário!</response>
        [HttpGet("SelecionarUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SelecionarUsuario([FromRoute] int id)
        {
            Usuario user = await _context.Usuarios
                .AsNoTracking()
                .Include(user => user.Cargo)   
                .FirstOrDefaultAsync(user => user.Id == id);
            return user != null ? Ok(user) : NotFound("Esse usuário não existe! Tente Novamente.");
        }

        /// <summary>
        ///     Altera o usuário através de seu numero de identificação
        /// </summary>
        /// <param name="id">Indetificador do Usuário a ser alterado</param>
        /// <param name="usuario">Usuário alterado</param>
        /// <returns>Nada</returns>
        /// <response code="404">Identificador não encontrado!</response>
        /// <response code="204">Alterado com sucesso!</response>
        /// <response code="400">Erro ao efetuar a alteração!</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditarUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a alteração do usuário.");

            var user = await _context.Usuarios.FirstOrDefaultAsync(user => user.Id == id);

            if (user != null)
            {
                try
                {
                    // Mapeando de maneira rapida usando automapper
                    user.Nome = usuario.Nome;
                    user.Email = usuario.Email;
                    user.CargoId = usuario.CargoId;

                    _context.Usuarios.Update(user);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar o cadastro do usuário.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Pessoa não encontrada!");
        }

        /// <summary>
        ///     Remove o usuário (Guarda o resultado em outra tabela)
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns>Nada</returns>
        /// <response code="404">Identificador não encontrado!</response>
        /// <response code="204">Removido com sucesso!</response>
        /// <response code="400">Erro ao efetuar a exclusão!</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreu um erro ao tentar efetuar a exclusão do usuário.");

            Usuario user = await _context.Usuarios.FirstOrDefaultAsync(user => user.Id == id);

            if (user != null)
            {
                try
                {
                    _context.Usuarios.Remove(user);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest("Ocorreu um erro interno ao tentar efetuar o cadastro do usuário.\n" +
                        "Erro:\n\t" + ex.Message);
                }
            }
            return NotFound("Usuário não encontrada!");
        }
    }
}
