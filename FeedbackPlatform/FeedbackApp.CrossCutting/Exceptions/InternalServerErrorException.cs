using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException(
            string[] mensagens,
            string titulo = "Erro Interno do Servidor",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 500, mensagemLog, innerException)
        {
        }
    }
}
