namespace FeedbackApp.Application.DTOs.Responses.Feedback
{
    public abstract class FeedbackResponseBase
    {
        public int Id { get; set; }
        public string Texto { get; set; } = null!;
        public DateTime DataEnvio { get; set; }
        public int UsuarioId { get; set; }
    }
}
