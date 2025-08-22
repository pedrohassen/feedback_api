using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(
            string[] mensagens,
            string titulo = "Não Autorizado",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 401, mensagemLog, innerException)
        {
        }
    }
}
