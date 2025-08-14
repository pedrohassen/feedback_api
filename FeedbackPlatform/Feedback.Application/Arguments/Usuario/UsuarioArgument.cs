using FeedbackApp.Application.DTOs;

namespace FeedbackApp.Application.Arguments.Usuario
{
    public class UsuarioArgument : UsuarioDTO
    {
        public int Id { get; set; }
        public required string SenhaHash { get; set; }
    }
}
