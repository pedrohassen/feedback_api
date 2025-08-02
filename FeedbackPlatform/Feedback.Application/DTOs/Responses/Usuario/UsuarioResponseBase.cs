namespace FeedbackApp.Application.DTOs.Responses.Usuario
{
    public abstract class UsuarioResponseBase
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
