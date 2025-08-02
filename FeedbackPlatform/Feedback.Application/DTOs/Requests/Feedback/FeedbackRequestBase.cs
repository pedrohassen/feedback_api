namespace FeedbackApp.Application.DTOs.Requests.Feedback
{
    public abstract class FeedbackRequestBase
    {
        public string Texto { get; set; } = null!;
    }
}
