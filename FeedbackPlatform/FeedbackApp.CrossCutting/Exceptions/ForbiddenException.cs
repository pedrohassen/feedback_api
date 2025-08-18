using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(
            string[] mensagens,
            string titulo = "Acesso Negado",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 403, mensagemLog, innerException)
        {
        }
    }
}
