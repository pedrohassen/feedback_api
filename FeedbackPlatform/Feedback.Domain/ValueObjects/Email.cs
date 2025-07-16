using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeedbackApp.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; }

        protected Email() { }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O email não pode ser vazio.", nameof(endereco));

            if (!Regex.IsMatch(endereco, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("O email informado é inválido.", nameof(endereco));

            Endereco = endereco;
        }

        public override bool Equals(object? obj)
        {
            return obj is Email email &&
                Endereco.ToLowerInvariant() == email.Endereco.ToLowerInvariant();
        }

        public override int GetHashCode()
        {
            return Endereco.ToLowerInvariant().GetHashCode();
        }

        public override string ToString() => Endereco;

        public static implicit operator string(Email email) => email.Endereco;
    }
}
