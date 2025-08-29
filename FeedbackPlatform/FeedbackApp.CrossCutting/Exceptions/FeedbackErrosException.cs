using System.Net;
using System.Runtime.Serialization;

namespace FeedbackApp.CrossCutting.Exceptions
{
    [Serializable]
    public class FeedbackErrosException : RegraNegocioException
    {
        public FeedbackErrosException(string[] mensagens, string titulo, string mensagemLog = null) : base(mensagens, titulo, mensagemLog) { }
        public FeedbackErrosException(string mensagem, string titulo, string mensagemLog = null) : base(mensagem, titulo, mensagemLog) { }
        public FeedbackErrosException(string mensagem) : base(mensagem, "Feedback", mensagem) { }
        public FeedbackErrosException(string[] mensagens, string titulo, string mensagemLog, Exception e = null) : base(mensagens, titulo, mensagemLog, e) { }
        public FeedbackErrosException(string mensagem, HttpStatusCode statusCode, string mensagemLog = null, Exception e = null) : base(mensagem, "Feedback", statusCode, mensagemLog, e) { }
        protected FeedbackErrosException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
