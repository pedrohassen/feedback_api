﻿namespace FeedbackApp.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;

        public ICollection<Feedback> FeedbacksRecebidos { get; set; } = new List<Feedback>();
    }
}
