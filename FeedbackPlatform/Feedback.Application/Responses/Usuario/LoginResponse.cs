using FeedbackApp.Application.DTOs;

namespace FeedbackApp.Application.Responses.Usuario
{
    public class LoginResponse : UsuarioDTO
    {
        public int Id { get; set; }
        public string Token { get; set; } = null!;
    }
}
