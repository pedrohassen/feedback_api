using System;
using System.Linq;
using System.Net;

namespace FeedbackApp.CrossCutting.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        public string[] Mensagens { get; }
        public string Titulo { get; }
        public string MensagemLog { get; }
        public virtual int StatusCode { get; }

        protected BaseException(
            string[] mensagens,
            string titulo = "Erro",
            int statusCode = 400,
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens?.FirstOrDefault(), innerException)
        {
            Mensagens = mensagens ?? new[] { "Ocorreu um erro inesperado." };
            Titulo = titulo;
            StatusCode = statusCode;
            MensagemLog = string.IsNullOrWhiteSpace(mensagemLog) ? Message : mensagemLog;
        }
    }
}
