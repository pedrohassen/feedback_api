namespace FeedbackApp.Application.DTOs.Arguments.Usuario
{
    public class CriarUsuarioArgument
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
    }
}
