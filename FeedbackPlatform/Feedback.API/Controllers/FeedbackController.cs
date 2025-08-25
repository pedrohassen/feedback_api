using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FeedbackApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        //[Authorize]
        [HttpPost]
        [SwaggerOperation(
            Summary = "Criar feedback.",
            Description = "Cria um feedback, associado a um usuário que criou, enviando a um outro usuário.",
            OperationId = "CriarFeedback")]
        public async Task<ActionResult<FeedbackResponse>> CriarAsync([FromBody] FeedbackRequest request)
        {
            FeedbackResponse novoFeedback = await _feedbackService.CriarAsync(request);
            return Ok(novoFeedback);
        }

        [HttpGet("listar")]
        [SwaggerOperation(
            Summary = "Listar feedbacks.",
            Description = "Retorna uma lista de todos os feedbacks enviados pelos usuários.",
            OperationId = "ListarFeedbacks")]
        public async Task<IActionResult> ListarFeedbacksAsync()
        {
            IEnumerable<FeedbackResponse> feedbacks = await _feedbackService.ListarTodosAsync();
            return Ok(feedbacks);
        }

        [HttpGet("obter/{id}")]
        [SwaggerOperation(
            Summary = "Obter feedback por ID.",
            Description = "Retorna um feedback específico com base no ID fornecido.",
            OperationId = "ObterFeedbackPorId")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            FeedbackResponse? feedback = await _feedbackService.ObterPorIdAsync(id);
            return Ok(feedback);
        }
    }
}
