//using FeedbackApp.Application.Requests.Feedback;
//using FeedbackApp.CrossCutting.Exceptions;

//namespace FeedbackApp.Application.Utils
//{
//    public static class ValidacoesFeedback
//    {
//        public static void ValidarCriarFeedback(CriarFeedbackRequest request)
//        {
//            if (request == null)
//                throw new BadRequestException(new[] { "Dados de criação não podem ser nulos." }, "Erro de Validação");

//            if (string.IsNullOrWhiteSpace(request.Texto))
//                throw new BadRequestException(new[] { "O texto do feedback não pode ser vazio." }, "Erro de Validação");

//            if (request.UsuarioId <= 0)
//                throw new BadRequestException(new[] { "ID de usuário inválido." }, "Erro de Validação");
//        }

//        public static void ValidarAtualizarFeedback(AtualizarFeedbackRequest request)
//        {
//            if (request == null)
//                throw new BadRequestException(new[] { "Dados de atualização não podem ser nulos." }, "Erro de Validação");

//            if (string.IsNullOrWhiteSpace(request.Texto))
//                throw new BadRequestException(new[] { "O texto do feedback não pode ser vazio." }, "Erro de Validação");
//        }
//    }
//}
