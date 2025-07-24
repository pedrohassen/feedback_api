using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Domain.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback?> ObterPorIdAsync(int id);
        Task<IEnumerable<Feedback>> ObterPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Feedback>> ObterTodosAsync();
        Task AdicionarAsync(Feedback feedback);
        Task AtualizarAsync(Feedback feedback);
        Task RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}
