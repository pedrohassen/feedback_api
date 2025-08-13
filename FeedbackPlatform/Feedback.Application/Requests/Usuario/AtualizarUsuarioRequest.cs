namespace FeedbackApp.Application.Requests.Usuario
{
    public class AtualizarUsuarioRequest
    {
        public string? NovoNome { get; set; }
        public string? NovoEmail { get; set; }
        public string? NovaSenha { get; set; }
    }
}
