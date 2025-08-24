using System.Text.RegularExpressions;
using System.Net;
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
                throw new UsuariosErrosException(EmailInvalido, HttpStatusCode.BadRequest, ErroValidacao);
        }

        public static void ValidarIdUsuario(int id)
        {
            if (id <= 0)
                throw new UsuariosErrosException(IdInvalido, HttpStatusCode.BadRequest, ErroValidacao);
        }

        private static void ValidarDadosUsuario(string valor, string mensagemErro)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new UsuariosErrosException(mensagemErro, HttpStatusCode.BadRequest, ErroValidacao);
        }

        private static void ValidarNullRequest(UsuarioRequest request, string mensagemErro)
        {
            if (request is null)
                throw new UsuariosErrosException(mensagemErro, HttpStatusCode.BadRequest, RequisicaoInvalida);
        }

        public static void ValidarRequest(UsuarioRequest request, TipoValidacao tipo)
        {
            ValidarNullRequest(request, RequestNula);
            ValidarEmail(request.Email);
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
