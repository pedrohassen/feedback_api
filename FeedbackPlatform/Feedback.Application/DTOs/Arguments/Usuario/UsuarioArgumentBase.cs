namespace FeedbackApp.Application.DTOs.Arguments.Usuario
{
    public abstract class UsuarioArgumentBase
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? SenhaHash { get; set; }
    }
}
