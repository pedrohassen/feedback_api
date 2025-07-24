using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;

namespace FeedbackApp.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> RegistrarAsync(RegistroRequest request);
        Task<UsuarioResponse> LoginAsync(LoginRequest request);
        Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync();
        Task<UsuarioResponse?> ObterPorIdAsync(int id);
        Task<UsuarioResponse> AtualizarAsync(int id, AtualizarUsuarioRequest request);
        Task RemoverAsync(int id);
    }
}
