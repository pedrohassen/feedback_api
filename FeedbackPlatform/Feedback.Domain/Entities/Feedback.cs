using System;
using FeedbackApp.Domain.ValueObjects;

namespace FeedbackApp.Domain.Entities
{
    public class Feedback
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public TextoFeedback Texto { get; private set; }
        public DateTime DataEnvio { get; private set; } = DateTime.UtcNow;

        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        protected Feedback() { }

        public Feedback(TextoFeedback texto, Guid usuarioId)
        {
            Texto = texto ?? throw new ArgumentNullException(nameof(texto));

            if (usuarioId == Guid.Empty)
                throw new ArgumentException("O ID do usuário não pode ser vazio.", nameof(usuarioId));

            UsuarioId = usuarioId;
        }
    }
}
