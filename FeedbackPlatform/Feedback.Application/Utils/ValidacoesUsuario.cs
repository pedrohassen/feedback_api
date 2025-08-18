using System.Net.Mail;
using System.Text.RegularExpressions;
using FeedbackApp.Application.Requests.Usuario;
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

        public static bool ValidarRegistro(UsuarioRequest request)
        {
            if (request == null)
                throw new BadRequestException(new[] { "Dados de registro não podem ser nulos." }, "Erro de Validação");

            request.Nome = request.Nome.Trim();
            request.Email = request.Email.Trim();
            request.Senha = request.Senha.Trim();

            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new BadRequestException(new[] { "Nome é obrigatório." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new BadRequestException(new[] { "Email é obrigatório." }, "Erro de Validação");

            if (!ValidarEmail(request.Email))
                throw new BadRequestException(new[] { "Email inválido." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new BadRequestException(new[] { "Senha é obrigatória." }, "Erro de Validação");

            return true;
        }

        public static void ValidarLogin(UsuarioRequest? request)
        {
            if (request is null)
                throw new BadRequestException(new[] { "Dados de login não podem ser nulos." }, "Erro de Validação");

            request.Email = request.Email?.Trim() ?? string.Empty;
            request.Senha = request.Senha?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new BadRequestException(new[] { "Email é obrigatório." }, "Erro de Validação");

            if (!ValidarEmail(request.Email))
                throw new BadRequestException(new[] { "Email inválido." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new BadRequestException(new[] { "Senha é obrigatória." }, "Erro de Validação");
        }

        public static bool ValidarAtualizacao(UsuarioRequest request)
        {
            if (request.Id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

            if (request == null)
                throw new BadRequestException(new[] { "Dados de atualização não podem ser nulos." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new BadRequestException(new[] { "Email é obrigatório." }, "Erro de Validação");
            request.Email = request.Email.Trim();

            if (!ValidarEmail(request.Email))
                throw new BadRequestException(new[] { "Email inválido." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new BadRequestException(new[] { "Nome é obrigatório." }, "Erro de Validação");
            request.Nome = request.Nome.Trim();

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new BadRequestException(new[] { "Senha é obrigatória." }, "Erro de Validação");
            request.Senha = request.Senha.Trim();

            return true;
        }

    }
}
