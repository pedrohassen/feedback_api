using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Domain.ValueObjects
{
    public class TextoFeedback
    {
        public string Texto { get; }

        protected TextoFeedback() { }

        public TextoFeedback(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("O texto do feedback não pode estar vazio.", nameof(texto));

            if (texto.Length < 10)
                throw new ArgumentException("O texto do feedback deve ter pelo menos 10 caracteres.", nameof(texto));

            if (texto.Length > 500)
                throw new ArgumentException("O texto do feedback não pode exceder 500 caracteres.", nameof(texto));

            Texto = texto;
        }

        public override bool Equals(object? obj)
        {
            return obj is TextoFeedback feedback &&
                   Texto == feedback.Texto;
        }

        public override int GetHashCode() => Texto.GetHashCode();

        public override string ToString() => Texto;

        public static implicit operator string(TextoFeedback feedback) => feedback.Texto;
    }
}
