using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(
            string[] mensagens,
            string titulo = "Conflito de Dados",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 409, mensagemLog, innerException)
        {
        }
    }
}
