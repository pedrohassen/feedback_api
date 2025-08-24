using System.Net;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Responses;
using FeedbackApp.CrossCutting.Exceptions;

namespace FeedbackApp.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IObjectConverter _mapper;

        public FeedbackService(
            IFeedbackRepository feedbackRepository,
            IObjectConverter mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<FeedbackResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new UsuariosErrosException("ID inválido.", HttpStatusCode.BadRequest, "Erro de Validação");

            FeedbackModel? feedback = await _feedbackRepository.ObterPorIdAsync(id)
                ?? throw new UsuariosErrosException("Feedback não encontrado.", HttpStatusCode.NotFound, "Recurso Inexistente");

            return _mapper.Map<FeedbackResponse>(feedback);
        }

        public async Task<IEnumerable<FeedbackResponse>> ListarFeedbacksAsync()
        {
            IEnumerable<FeedbackModel> feedbacks = await _feedbackRepository.ListarFeedbacksAsync();
            if (feedbacks == null || !feedbacks.Any())
                return Enumerable.Empty<FeedbackResponse>();

            return _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
        }
    }
}
