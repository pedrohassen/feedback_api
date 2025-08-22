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
        public static void ValidarEmail(string email)
        {
            ValidarDadosUsuario(email, EmailObrigatorio);

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                throw new BadRequestException(new[] { EmailInvalido }, ErroValidacao);
        }

        public static void ValidarIdUsuario(int id)
        {
            if (id <= 0)
                throw new BadRequestException(new[] { IdInvalido }, ErroValidacao);
        }

        private static void ValidarDadosUsuario(string valor, string mensagemErro)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new BadRequestException(new[] { mensagemErro }, ErroValidacao);
        }

        public static void ValidarRequest(UsuarioRequest request, TipoValidacao tipo)
        {
            ValidarEmail(request!.Email);
            ValidarDadosUsuario(request.Senha, SenhaObrigatoria);

            if (tipo == TipoValidacao.Registro || tipo == TipoValidacao.Atualizacao)
            {
                if (tipo == TipoValidacao.Atualizacao)
                {
                    ValidarIdUsuario(request.Id);
                }
                ValidarDadosUsuario(request.Nome, NomeObrigatorio);
            }
        }
    }
}
