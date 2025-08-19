namespace FeedbackApp.Application.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public UsuarioDTO Usuario { get; set; } = null!;
        public int UsuarioId { get; set; }
    }
}
