using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponse> CriarAsync(FeedbackRequest request);
        Task<FeedbackResponse> AtualizarAsync(FeedbackRequest request);
        Task<IEnumerable<FeedbackResponse>> ListarTodosAsync();
        Task<FeedbackResponse?> ObterPorIdAsync(int id);
    }
}
