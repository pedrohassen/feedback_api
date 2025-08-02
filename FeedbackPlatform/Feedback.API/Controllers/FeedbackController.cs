using FeedbackApp.Application.DTOs.Requests.Feedback;
using FeedbackApp.Application.DTOs.Responses.Feedback;
using FeedbackApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FeedbackApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Criar novo feedback.",
            Description = "Adiciona um novo feedback à aplicação.",
            OperationId = "CriarFeedback")]
        public async Task<IActionResult> CriarFeedback([FromBody] CriarFeedbackRequest request)
        {
            try
            {
                FeedbackResponse response = await _feedbackService.AdicionarAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(
            Summary = "Obter feedback por ID.",
            Description = "Recupera um feedback específico pelo seu ID.",
            OperationId = "ObterFeedbackPorId")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                FeedbackResponse? response = await _feedbackService.ObterPorIdAsync(id);
                if (response == null) return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("usuario/{usuarioId:int}")]
        [SwaggerOperation(
            Summary = "Obter feedbacks por usuário.",
            Description = "Recupera todos os feedbacks associados a um usuário específico.",
            OperationId = "ObterFeedbacksPorUsuario")]
        public async Task<IActionResult> ObterPorUsuario(int usuarioId)
        {
            try
            {
                IEnumerable<FeedbackResponse> response = await _feedbackService.ObterPorUsuarioIdAsync(usuarioId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os feedbacks.",
            Description = "Recupera todos os feedbacks registrados na aplicação.",
            OperationId = "ObterTodosFeedbacks")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                IEnumerable<FeedbackResponse> response = await _feedbackService.ObterTodosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(
            Summary = "Atualizar feedback.",
            Description = "Atualiza os detalhes de um feedback existente.",
            OperationId = "AtualizarFeedback")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarFeedbackRequest request)
        {

            try
            {
                FeedbackResponse response = await _feedbackService.AtualizarAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(
            Summary = "Deletar feedback.",
            Description = "Remove um feedback específico da aplicação.",
            OperationId = "DeletarFeedback")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _feedbackService.DeletarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
