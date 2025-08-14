using FeedbackApp.Domain.Entities;
using FeedbackApp.Application.Arguments.Usuario;

namespace FeedbackApp.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel?> ObterPorIdAsync(int id);
        Task<UsuarioModel?> ObterUsuarioEntidadePorIdAsync(int id);
        Task<UsuarioModel?> ObterPorEmailAsync(string email);
        Task<IEnumerable<UsuarioModel>> ListarTodosAsync();
        Task<UsuarioModel> CriarAsync(UsuarioArgument usuarioArgument);
        Task AtualizarAsync(UsuarioArgument usuarioArgument);
        Task RemoverAsync(int id);
    }
}
