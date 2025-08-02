using System.Net.Mail;
using FeedbackApp.Application.DTOs.Requests.Usuario;

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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ValidarRegistro(RegistroRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de registro não podem ser nulos.");

            request.Nome = request.Nome?.Trim() ?? string.Empty;
            request.Email = request.Email?.Trim() ?? string.Empty;
            request.Senha = request.Senha?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email é obrigatório.", nameof(request));

            if (!ValidarEmail(request.Email))
                throw new ArgumentException("Email inválido.", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new ArgumentException("Senha é obrigatória.", nameof(request));
        }

        public static void ValidarLogin(LoginRequest? request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request), "Dados de login não podem ser nulos.");

            request.Email = request.Email?.Trim() ?? string.Empty;
            request.Senha = request.Senha?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email é obrigatório.", nameof(request));

            if (!ValidarEmail(request.Email))
                throw new ArgumentException("Email inválido.", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new ArgumentException("Senha é obrigatória.", nameof(request));
        }

        public static void ValidarAtualizacao(AtualizarUsuarioRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de atualização não podem ser nulos.");

            if (request.Email is not null)
            {
                request.Email = request.Email.Trim();
                if (!ValidarEmail(request.Email))
                    throw new ArgumentException("Email inválido.", nameof(request));
            }

            if (request.Nome is not null)
            {
                request.Nome = request.Nome.Trim();
                if (string.IsNullOrWhiteSpace(request.Nome))
                    throw new ArgumentException("Nome inválido.", nameof(request));
            }

            if (request.NovaSenha is not null)
            {
                request.NovaSenha = request.NovaSenha.Trim();
                if (string.IsNullOrWhiteSpace(request.NovaSenha))
                    throw new ArgumentException("Nova senha inválida.", nameof(request));
            }
        }

    }
}
