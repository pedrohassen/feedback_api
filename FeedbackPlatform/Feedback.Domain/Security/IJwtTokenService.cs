using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Domain.Security
{
    public interface IJwtTokenService
    {
        string GerarToken(Usuario usuario);
    }
}
