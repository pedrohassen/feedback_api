using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> RegistrarAsync(UsuarioRequest request);
        Task<UsuarioResponse> LoginAsync(UsuarioRequest request);
        Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync();
        Task<UsuarioResponse?> ObterPorIdAsync(int id);
        Task<UsuarioResponse> AtualizarAsync(UsuarioRequest request);
        Task<UsuarioResponse> RemoverAsync(int id);
    }
}
