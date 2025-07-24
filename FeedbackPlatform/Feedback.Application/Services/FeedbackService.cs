using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using FeedbackApp.Domain.Interfaces;

namespace FeedbackApp.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<FeedbackResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            Feedback? feedback = await _feedbackRepository.ObterPorIdAsync(id);
            if (feedback == null) return null;

            return MapToResponse(feedback);
        }

        public async Task<IEnumerable<FeedbackResponse>> ObterPorUsuarioIdAsync(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentException("ID de usuário inválido.", nameof(usuarioId));

            IEnumerable<Feedback> feedbacks = await _feedbackRepository.ObterPorUsuarioIdAsync(usuarioId);
            return feedbacks.Select(MapToResponse);
        }

        public async Task<IEnumerable<FeedbackResponse>> ObterTodosAsync()
        {
            IEnumerable<Feedback> feedbacks = await _feedbackRepository.ObterTodosAsync();
            return feedbacks.Select(MapToResponse);
        }

        public async Task<FeedbackResponse> AdicionarAsync(CriarFeedbackRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de criação não podem ser nulos.");

            if (string.IsNullOrWhiteSpace(request.Texto))
                throw new ArgumentException("O texto do feedback não pode ser vazio.", nameof(request));

            if (request.UsuarioId <= 0)
                throw new ArgumentException("ID de usuário inválido.", nameof(request));

            Feedback novoFeedback = new (request.Texto, request.UsuarioId);
            await _feedbackRepository.AdicionarAsync(novoFeedback);
            return MapToResponse(novoFeedback);
        }

        public async Task<FeedbackResponse> AtualizarAsync(int id,AtualizarFeedbackRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de atualização não podem ser nulos.");

            if (string.IsNullOrWhiteSpace(request.Texto))
                throw new ArgumentException("O texto do feedback não pode ser vazio.", nameof(request));

            Feedback? feedbackExistente = await _feedbackRepository.ObterPorIdAsync(id) ?? throw new Exception("Feedback não encontrado.");

            feedbackExistente.AtualizarTexto(request.Texto);
            await _feedbackRepository.AtualizarAsync(feedbackExistente);

            return MapToResponse(feedbackExistente);
        }

        public async Task DeletarAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            _ = await _feedbackRepository.ObterPorIdAsync(id) ?? throw new Exception("Feedback não encontrado.");

            await _feedbackRepository.RemoverAsync(id);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            return await _feedbackRepository.ExisteAsync(id);
        }

        private FeedbackResponse MapToResponse(Feedback feedback)
        {
            return new FeedbackResponse
            {
                Id = feedback.Id,
                Texto = feedback.Texto,
                DataEnvio = feedback.DataEnvio,
                UsuarioId = feedback.UsuarioId
            };
        }
    }
}
