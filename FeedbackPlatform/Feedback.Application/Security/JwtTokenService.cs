using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeedbackApp.CrossCutting.Exceptions;
using FeedbackApp.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;

namespace FeedbackApp.Application.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _chave;
        private readonly string _emissor;
        private readonly string _publico;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtTokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _chave = configuration["Jwt:SecretKey"]?.Trim()
                     ?? throw new JwtException(new[] { "Jwt:SecretKey não está configurado." });

            _emissor = configuration["Jwt:Issuer"]?.Trim()
                       ?? throw new JwtException(new[] { "Jwt:Issuer não está configurado." });

            _publico = configuration["Jwt:Audience"]?.Trim()
                       ?? throw new JwtException(new[] { "Jwt:Audience não está configurado." });
            _httpContextAccessor = httpContextAccessor
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GerarToken(int id, string nome, string email)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chave));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, nome),
                new Claim(ClaimTypes.Email, email)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _emissor,
                audience: _publico,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UsuarioTokenInfo ObterUsuarioLogado()
        {
            string? token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(token))
                throw new JwtException(new[] { "Token não encontrado." });

            return ObterUsuarioDoToken(token.Replace("Bearer ", "").Trim());
        }

        public static UsuarioTokenInfo ObterUsuarioDoToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
                throw new JwtException(new[] { "Token JWT inválido." });

            JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

            Claim? idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Claim? nomeClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            Claim? emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (idClaim == null || !int.TryParse(idClaim.Value, out int userId))
                throw new JwtException(new[] { "Não foi possível extrair o ID do usuário do token." });

            if (nomeClaim == null)
                throw new JwtException(new[] { "Não foi possível extrair o nome do usuário do token." });

            if (emailClaim == null)
                throw new JwtException(new[] { "Não foi possível extrair o e-mail do usuário do token." });

            return new UsuarioTokenInfo
            {
                Id = userId,
                Nome = nomeClaim.Value,
                Email = emailClaim.Value
            };
        }

    }
}
