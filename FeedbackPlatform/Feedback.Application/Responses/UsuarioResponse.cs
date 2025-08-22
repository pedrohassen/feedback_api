using FeedbackApp.Application.DTOs;

namespace FeedbackApp.Application.Responses
{
    public class UsuarioResponse : UsuarioDTO
    {
        public string Token { get; set; } = string.Empty;
    }
}
