namespace FeedbackApp.Application.Requests.Feedback
{
    public class AtualizarFeedbackRequest
    {
        public string NovoTexto { get; set; } = null!;
        public DateTime NovaDataEnvio { get; set; } = DateTime.UtcNow;
    }
}
