using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;

namespace FeedbackApp.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> RegistrarAsync(RegistroRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync();
        Task<UsuarioResponse?> ObterPorIdAsync(int id);
        Task<UsuarioResponse> AtualizarAsync(int id, AtualizarUsuarioRequest request);
        Task RemoverAsync(int id);
    }
}
