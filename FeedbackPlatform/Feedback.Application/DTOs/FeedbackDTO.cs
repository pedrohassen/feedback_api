namespace FeedbackApp.Application.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public int DestinatarioId { get; set; }
        public UsuarioDTO Destinatario { get; set; } = null!;
        public int RemetenteId { get; set; }
        public UsuarioDTO Remetente { get; set; } = null!;
    }
}
