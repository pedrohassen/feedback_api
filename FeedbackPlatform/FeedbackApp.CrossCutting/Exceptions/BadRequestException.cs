using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(
            string[] mensagens,
            string titulo = "Requisição Inválida",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 400, mensagemLog, innerException)
        {
        }
    }
}
