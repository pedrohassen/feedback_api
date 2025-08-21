using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FeedbackApp.API.Controllers
{
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [Authorize]
        [HttpGet("obter/{id}")]
        [SwaggerOperation(
            Summary = "Obter feedback por ID.",
            Description = "Retorna um feedback específico com base no ID fornecido.",
            OperationId = "ObterFeedbackPorId")]
        public async Task<IActionResult> ObterFeedbackPorIdAsync(int id)
        {
            FeedbackResponse? feedback = await _feedbackService.ObterPorIdAsync(id);
            return Ok(feedback);
        }

        [HttpGet("listar")]
        [SwaggerOperation(
            Summary = "Listar feedbacks.",
            Description = "Retorna uma lista de todos os feedbacks enviados pelos usuários.",
            OperationId = "ListarFeedbacks")]
        public async Task<IActionResult> ListarFeedbacksAsync()
        {
            IEnumerable<FeedbackResponse> feedbacks = await _feedbackService.ListarFeedbacksAsync();
            return Ok(feedbacks);
        }
    }
}
