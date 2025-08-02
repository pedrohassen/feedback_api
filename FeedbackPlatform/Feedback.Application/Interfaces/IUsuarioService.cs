using FeedbackApp.Application.DTOs.Requests.Usuario;
using FeedbackApp.Application.DTOs.Responses.Usuario;

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
