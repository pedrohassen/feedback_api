using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObterPorIdAsync(int id);
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ListarTodosAsync();
        Task<Usuario> CriarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(int id);
        Task<bool> ExistePorEmailAsync(string email);
    }
}
