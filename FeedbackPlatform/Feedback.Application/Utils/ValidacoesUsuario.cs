using System.Net.Mail;
using System.Text.RegularExpressions;
using FeedbackApp.Application.Requests;
using FeedbackApp.CrossCutting.Exceptions;
using static FeedbackApp.Application.Utils.Constants;
using static FeedbackApp.Application.Utils.Constants.MensagemErro;

namespace FeedbackApp.Application.Utils
{
    public static class ValidacoesUsuario
    {
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress mailAddress = new (email);
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private static void ValidarCondicao(bool condicao, string mensagemErro)
        {
            if (!condicao)
                throw new BadRequestException(new[] { mensagemErro }, ErroValidacao);
        }

        public static void ValidarRequest(UsuarioRequest request, ValidacaoUsuario tipo)
        {
            ValidarCondicao(request is not null, RequestNaoNula);

            switch (tipo)
            {
                case ValidacaoUsuario.Registro:
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request!.Nome), NomeObrigatorio);
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request.Email), EmailObrigatorio);
                    ValidarCondicao(ValidarEmail(request.Email), EmailInvalido);
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request.Senha), SenhaObrigatoria);
                    break;

                case ValidacaoUsuario.Login:
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request!.Email), EmailObrigatorio);
                    ValidarCondicao(ValidarEmail(request.Email), EmailInvalido);
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request.Senha), SenhaObrigatoria);
                    break;

                case ValidacaoUsuario.Atualizacao:
                    ValidarCondicao(request!.Id >= 0, IdInvalido);
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request.Nome), NomeObrigatorio);
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request.Email), EmailObrigatorio);
                    ValidarCondicao(ValidarEmail(request.Email), EmailInvalido);
                    ValidarCondicao(!string.IsNullOrWhiteSpace(request.Senha), SenhaObrigatoria);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), tipo, null);
            }
        }
    }
}
