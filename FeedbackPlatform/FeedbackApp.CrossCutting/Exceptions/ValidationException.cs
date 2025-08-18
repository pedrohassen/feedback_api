using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(
            string[] mensagens,
            string titulo = "Erro de Validação",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 400, mensagemLog, innerException)
        {
        }
    }
}
