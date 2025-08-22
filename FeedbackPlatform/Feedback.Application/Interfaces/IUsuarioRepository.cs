using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel?> ObterPorIdAsync(int id);
        Task<UsuarioModel?> ObterPorEmailAsync(string email);
        Task<IEnumerable<UsuarioModel>> ListarTodosAsync();
        Task<UsuarioModel> CriarAsync(UsuarioArgument usuarioArgument);
        Task<UsuarioModel?> AtualizarAsync(UsuarioArgument usuarioArgument);
        Task<UsuarioModel?> RemoverAsync(int id);
    }
}
