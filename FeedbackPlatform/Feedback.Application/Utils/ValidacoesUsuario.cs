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

        public static void ValidarRegistro(RegistroRequest request)
        {
            if (request == null)
                throw new BadRequestException(new[] { "Dados de registro não podem ser nulos." }, "Erro de Validação");

            request.Nome = request.Nome?.Trim() ?? string.Empty;
            request.Email = request.Email?.Trim() ?? string.Empty;
            request.Senha = request.Senha?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new BadRequestException(new[] { "Nome é obrigatório." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new BadRequestException(new[] { "Email é obrigatório." }, "Erro de Validação");

            if (!ValidarEmail(request.Email))
                throw new BadRequestException(new[] { "Email inválido." }, "Erro de Validação");

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new BadRequestException(new[] { "Senha é obrigatória." }, "Erro de Validação");
        }

        public static void ValidarLogin(LoginRequest? request)
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

        public static void ValidarAtualizacao(AtualizarUsuarioRequest request)
        {
            if (request == null)
                throw new BadRequestException(new[] { "Dados de atualização não podem ser nulos." }, "Erro de Validação");

            if (request.Email is not null)
            {
                request.Email = request.Email.Trim();
                if (!ValidarEmail(request.Email))
                    throw new BadRequestException(new[] { "Email inválido." }, "Erro de Validação");
            }

            if (request.Nome is not null)
            {
                request.Nome = request.Nome.Trim();
                if (string.IsNullOrWhiteSpace(request.Nome))
                    throw new BadRequestException(new[] { "Nome inválido." }, "Erro de Validação");
            }

            if (request.Senha is not null)
            {
                request.Senha = request.Senha.Trim();
                if (string.IsNullOrWhiteSpace(request.Senha))
                    throw new BadRequestException(new[] { "Nova senha inválida." }, "Erro de Validação");
            }
        }

    }
}
