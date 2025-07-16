using System;
using System.Collections.Generic;
using FeedbackApp.Domain.ValueObjects;

namespace FeedbackApp.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public string SenhaHash { get; private set; }
        public List<Feedback> FeedBacksRecebidos { get; private set; } = new ();

        protected Usuario() { }

        public Usuario(string nome, Email email, string senhaHash)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(nome));

            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }
    }
}
