using FeedbackApp.Application.Models;

namespace FeedbackApp.Application.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public int DestinatarioId { get; set; }
        public UsuarioModel Destinatario { get; set; }
        public int RemetenteId { get; set; }
        public UsuarioModel Remetente { get; set; }
    }
}
