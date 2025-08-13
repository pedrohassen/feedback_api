using FeedbackApp.CrossCutting.Exceptions.Base;

namespace FeedbackApp.CrossCutting.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(
            string[] mensagens,
            string titulo = "Recurso Não Encontrado",
            string mensagemLog = null,
            Exception innerException = null)
            : base(mensagens, titulo, 404, mensagemLog, innerException)
        {
        }
    }
}
