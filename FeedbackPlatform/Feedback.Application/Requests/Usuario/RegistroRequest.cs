using FeedbackApp.Application.DTOs;

namespace FeedbackApp.Application.Requests.Usuario
{
    public class RegistroRequest : UsuarioDTO
    {
        public string Senha { get; set; } = null!;
    }
}
