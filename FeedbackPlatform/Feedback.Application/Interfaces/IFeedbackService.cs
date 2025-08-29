using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponse> CriarFeedbackAsync(FeedbackRequest request);
        Task<FeedbackResponse> AtualizarFeedbackAsync(FeedbackRequest request);
        Task<IEnumerable<FeedbackResponse>> ObterTodosFeedbacksAsync();
        Task<FeedbackResponse?> ObterFeedbackPorIdAsync(int id);
        Task<IEnumerable<FeedbackResponse?>> ObterFeedbackPorDestinatarioIdAsync(int id);
    }
}
