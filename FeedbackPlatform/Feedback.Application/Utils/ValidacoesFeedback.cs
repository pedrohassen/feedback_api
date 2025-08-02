using FeedbackApp.Application.DTOs.Requests.Feedback;

namespace FeedbackApp.Application.Utils
{
    public static class ValidacoesFeedback
    {
        public static void ValidarCriarFeedback(CriarFeedbackRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de criação não podem ser nulos.");

            if (string.IsNullOrWhiteSpace(request.Texto))
                throw new ArgumentException("O texto do feedback não pode ser vazio.", nameof(request));

            if (request.UsuarioId <= 0)
                throw new ArgumentException("ID de usuário inválido.", nameof(request));
        }

        public static void ValidarAtualizarFeedback(AtualizarFeedbackRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de atualização não podem ser nulos.");

            if (string.IsNullOrWhiteSpace(request.Texto))
                throw new ArgumentException("O texto do feedback não pode ser vazio.", nameof(request));
        }
    }
}
