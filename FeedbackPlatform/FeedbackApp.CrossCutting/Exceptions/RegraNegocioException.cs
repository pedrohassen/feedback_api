using System.Net;
using System.Runtime.Serialization;
using FeedbackApp.CrossCutting.Exceptions.Base;
using FeedbackApp.CrossCutting.Utils;

namespace FeedbackApp.CrossCutting.Exceptions
{
    [Serializable]
    public class RegraNegocioException : BaseException
    {
        public RegraNegocioException(string[] mensagens, string titulo, string mensagemLog = null, Exception innerException = null)
            : base(mensagens, titulo, HttpStatusCode.UnprocessableEntity, mensagemLog, innerException)
        {
        }

        public RegraNegocioException(string[] mensagens, string titulo, HttpStatusCode statusCode, string mensagemLog = null, Exception innerException = null)
    : base(mensagens, titulo, statusCode, mensagemLog, innerException)
        {
        }

        public RegraNegocioException(string mensagem, string titulo, string mensagemLog = null, Exception innerException = null)
    : base(mensagem.ToStringArray(), titulo, HttpStatusCode.UnprocessableEntity, mensagemLog, innerException)
        {
        }

        public RegraNegocioException(string mensagem, string titulo, HttpStatusCode statusCode, string mensagemLog = null, Exception innerException = null)
           : base(mensagem.ToStringArray(), titulo, statusCode, mensagemLog, innerException)
        {
        }

        protected RegraNegocioException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
