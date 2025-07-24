using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            IEnumerable<UsuarioResponse> usuarios = await _usuarioService.ListarUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            UsuarioResponse? usuario = await _usuarioService.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound(new { erro = "Usuário não encontrado." });

            return Ok(usuario);
        }

        [HttpPatch("{id:int}")]
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
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                await _usuarioService.RemoverAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }
    }
}
