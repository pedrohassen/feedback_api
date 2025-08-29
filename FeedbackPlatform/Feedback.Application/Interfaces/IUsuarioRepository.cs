using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel?> ObterUsuarioPorIdAsync(int id);
        Task<UsuarioModel?> ObterUsuarioPorEmailAsync(string email);
        Task<IEnumerable<UsuarioModel>> ObterTodosUsuariosAsync();
        Task<UsuarioModel> CriarUsuarioAsync(UsuarioArgument usuarioArgument);
        Task<UsuarioModel?> AtualizarUsuarioAsync(UsuarioArgument usuarioArgument);
    }
}
