namespace FeedbackApp.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
        public int DestinatarioId { get; set; }
        public Usuario Destinatario { get; set; } = null!;
        public int RemetenteId { get; set; }
        public Usuario Remetente { get; set; } = null!;
    }
}
