using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<FeedbackModel> CriarAsync(FeedbackArgument argument);
        Task<FeedbackModel?> AtualizarAsync(FeedbackArgument argument);
        Task<IEnumerable<FeedbackModel>> ListarTodosAsync();
        Task<FeedbackModel?> ObterPorIdAsync(int id);
        Task<IEnumerable<FeedbackModel?>> ObterPorUsuarioIdAsync(int id);
    }
}
