namespace FeedbackApp.Domain.Entities
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;

        public ICollection<Feedback> FeedbacksRecebidos { get; set; } = new List<Feedback>();
    }
}
