namespace FeedbackApp.Application.Requests
{
    public class AtualizarUsuarioRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? NovaSenha { get; set; }
    }
}
