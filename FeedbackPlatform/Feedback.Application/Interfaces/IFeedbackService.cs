using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponse?> ObterPorIdAsync(int id);
        Task<IEnumerable<FeedbackResponse>> ListarFeedbacksAsync();
    }
}
