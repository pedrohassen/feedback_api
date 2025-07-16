using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Domain.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Feedback>> ObterPorUsuarioIdAsync(Guid usuarioId);
        Task<IEnumerable<Feedback>> ObterTodosAsync();
        Task AdicionarAsync(Feedback feedback);
        Task AtualizarAsync(Feedback feedback);
        Task RemoverAsync(Guid id);
        Task<bool> ExisteAsync(Guid id);
    }
}
