using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> RegistrarUsuarioAsync(UsuarioRequest request);
        Task<UsuarioResponse> LoginUsuarioAsync(UsuarioRequest request);
        Task<IEnumerable<UsuarioResponse>> ObterTodosUsuariosAsync();
        Task<UsuarioResponse?> ObterUsuarioPorIdAsync(int id);
        Task<UsuarioResponse> AtualizarUsuarioAsync(UsuarioRequest request);
        Task<UsuarioResponse> RemoverUsuarioAsync(int id);
    }
}
