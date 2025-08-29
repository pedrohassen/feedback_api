using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<FeedbackModel> CriarFeedbackAsync(FeedbackArgument argument);
        Task<FeedbackModel?> AtualizarFeedbackAsync(FeedbackArgument argument);
        Task<IEnumerable<FeedbackModel>> ObterTodosFeedbacksAsync();
        Task<FeedbackModel?> ObterFeedbackPorIdAsync(int id);
        Task<IEnumerable<FeedbackModel?>> ObterFeedbackPorDestinatarioIdAsync(int id);
    }
}
