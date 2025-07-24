namespace FeedbackApp.Application.Requests
{
    public class CriarFeedbackRequest
    {
        public string Texto { get; set; } = null!;
        public int UsuarioId { get; set; }
    }
}
