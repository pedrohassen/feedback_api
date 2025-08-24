using System.Net;
using System.Runtime.Serialization;
using FeedbackApp.CrossCutting.Utils;

namespace FeedbackApp.CrossCutting.Exceptions
{
    [Serializable]
    public class JwtException : RegraNegocioException
    {
        public JwtException(string[] mensagens, string titulo = "Token JWT", string mensagemLog = null)
            : base(mensagens, titulo, HttpStatusCode.Unauthorized, mensagemLog, null)
        {
        }

        public JwtException(string mensagem, string titulo = "Token JWT", string mensagemLog = null)
            : base(mensagem.ToStringArray(), titulo, HttpStatusCode.Unauthorized, mensagemLog, null)
        {
        }

        public JwtException(string mensagem, HttpStatusCode statusCode, string titulo = "Token JWT", string mensagemLog = null)
            : base(mensagem.ToStringArray(), titulo, statusCode, mensagemLog, null)
        {
        }

        protected JwtException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
