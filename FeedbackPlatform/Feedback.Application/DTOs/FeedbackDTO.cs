namespace FeedbackApp.Application.DTOs
{
    public class FeedbackDTO
    {
        public string Texto { get; set; } = null!;
        public DateTime DataEnvio { get; set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; }
    }
}

