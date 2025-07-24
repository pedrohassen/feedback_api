namespace FeedbackApp.Application.Responses
{
    public class FeedbackResponse
    {
        public int Id { get; set; }
        public string Texto { get; set; } = null!;
        public DateTime DataEnvio { get; set; }
        public int UsuarioId { get; set; }
    }
}
