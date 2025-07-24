using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponse?> ObterPorIdAsync(int id);
        Task<IEnumerable<FeedbackResponse>> ObterPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<FeedbackResponse>> ObterTodosAsync();
        Task<FeedbackResponse> AdicionarAsync(CriarFeedbackRequest request);
        Task<FeedbackResponse> AtualizarAsync(int id, AtualizarFeedbackRequest request);
        Task DeletarAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
