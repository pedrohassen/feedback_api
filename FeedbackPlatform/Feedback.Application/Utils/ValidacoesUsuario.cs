using System.Net.Mail;
using System.Text.RegularExpressions;
using FeedbackApp.Application.Requests;
using FeedbackApp.CrossCutting.Exceptions;

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

        public static bool ValidarLimparRegistro(UsuarioRequest request)
        {
            LancaExcecaoRequest(request);
            LancaExcecaoNome(request);
            LancaExcecaoEmail(request);
            LancaExcecaoSenha(request);

            LimpaCamposNomeEmail(request);
            LimpaCampoSenha(request);

            return true;
        }

        public static void ValidarLimparLogin(UsuarioRequest request)
        {
            LancaExcecaoRequest(request);
            LancaExcecaoEmail(request);
            LancaExcecaoSenha(request);

            LimpaCamposNomeEmail(request);
        }

        public static bool ValidarLimparAtualizacao(UsuarioRequest request)
        {
            LancaExcecaoId(request);
            LancaExcecaoRequest(request);
            LancaExcecaoNome(request);
            LancaExcecaoEmail(request);
            LancaExcecaoSenha(request);

            LimpaCamposNomeEmail(request);
            LimpaCampoSenha(request);

            return true;
        }

        public static void LancaExcecaoId(UsuarioRequest request)
        {
            if (request.Id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");
        }

        public static void LancaExcecaoRequest(UsuarioRequest request)
        {
            if (request is null)
                throw new BadRequestException(new[] { "Dados de login não podem ser nulos." }, "Erro de Validação");
        }

        public static void LancaExcecaoNome(UsuarioRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new BadRequestException(new[] { "Nome é obrigatório." }, "Erro de Validação");
        }

        public static void LancaExcecaoEmail(UsuarioRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new BadRequestException(new[] { "Email é obrigatório." }, "Erro de Validação");

            if (!ValidarEmail(request.Email))
                throw new BadRequestException(new[] { "Email inválido." }, "Erro de Validação");
        }

        public static void LancaExcecaoSenha(UsuarioRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new BadRequestException(new[] { "Senha é obrigatória." }, "Erro de Validação");
        }

        public static void LimpaCamposNomeEmail(UsuarioRequest request)
        {
            request.Nome = request.Nome.Trim();
            request.Email = request.Email.Trim();
        }

        public static void LimpaCampoSenha(UsuarioRequest request)
        {
            request.Senha = request.Senha.Trim();
        }
    }
}
