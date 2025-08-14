using FeedbackApp.Application.DTOs;

namespace FeedbackApp.Application.Requests.Usuario
{
    public class AtualizarUsuarioRequest : UsuarioDTO
    {
        public new string? Nome { get; set; }
        public new string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
