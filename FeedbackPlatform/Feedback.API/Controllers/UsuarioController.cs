using FeedbackApp.Application.DTOs.Requests.Usuario;
using FeedbackApp.Application.DTOs.Responses.Usuario;
using FeedbackApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FeedbackApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        [SwaggerOperation(
            Summary = "Registrar novos usuários.",
            Description = "Cadastro de novos usuários na aplicação.",
            OperationId = "RegistroUsuario")]
        public async Task<IActionResult> Registrar([FromBody] RegistroRequest request)
        {
            try
            {
                UsuarioResponse response = await _usuarioService.RegistrarAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPost("login")]
        [SwaggerOperation(
            Summary = "Realizar login de usuários.",
            Description = "Autenticação de usuários na aplicação.",
            OperationId = "LoginUsuario")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                UsuarioResponse response = await _usuarioService.LoginAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar usuários.",
            Description = "Retorna uma lista de todos os usuários registrados na aplicação.",
            OperationId = "ListarUsuarios")]
        public async Task<IActionResult> ListarUsuarios()
        {
            IEnumerable<UsuarioResponse> usuarios = await _usuarioService.ListarUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(
            Summary = "Obter usuário por ID",
            Description = "Retorna os detalhes de um usuário específico pelo ID.",
            OperationId = "ObterUsuarioPorId")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            UsuarioResponse? usuario = await _usuarioService.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound(new { erro = "Usuário não encontrado." });

            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(
            Summary = "Atualizar usuário",
            Description = "Atualiza os dados de um usuário existente. Apenas os campos enviados serão modificados.",
            OperationId = "AtualizarUsuario")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarUsuarioRequest request)
        {
            try
            {
                UsuarioResponse response = await _usuarioService.AtualizarAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(
            Summary = "Remover usuário",
            Description = "Remove um usuário da aplicação pelo ID.",
            OperationId = "RemoverUsuario")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                await _usuarioService.RemoverAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
