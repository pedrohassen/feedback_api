using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<FeedbackModel?> ObterPorIdAsync(int id);
        Task<IEnumerable<FeedbackModel>> ListarFeedbacksAsync();
    }
}
