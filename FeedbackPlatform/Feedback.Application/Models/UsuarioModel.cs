using FeedbackApp.Application.DTOs;

namespace FeedbackApp.Application.Models
{
    public class UsuarioModel : UsuarioDTO
    {
        public string SenhaHash { get; set; } = string.Empty;
    }
}
