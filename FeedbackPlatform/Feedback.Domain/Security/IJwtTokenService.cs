
namespace FeedbackApp.Domain.Security
{
    public interface IJwtTokenService
    {
        string GerarToken(int id, string nome, string email);
        Task<UsuarioTokenInfo> ObterUsuarioLogado();
    }
}
