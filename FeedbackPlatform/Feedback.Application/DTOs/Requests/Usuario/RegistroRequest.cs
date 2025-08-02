namespace FeedbackApp.Application.DTOs.Requests.Usuario
{
    public class RegistroRequest : UsuarioRequestBase
    {
        public string Senha { get; set; } = null!;
    }
}
