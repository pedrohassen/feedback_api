namespace FeedbackApp.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; private set; }
        public string Texto { get; private set; }
        public DateTime DataEnvio { get; private set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        protected Feedback() { }

        public Feedback(string texto, int usuarioId)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("Texto é obrigatório.", nameof(texto));

            Texto = texto;
            UsuarioId = usuarioId;
        }

        public void AtualizarTexto(string novoTexto)
        {
            if (string.IsNullOrWhiteSpace(novoTexto))
                throw new ArgumentException("Texto é obrigatório.", nameof(novoTexto));

            Texto = novoTexto;
        }
    }
}