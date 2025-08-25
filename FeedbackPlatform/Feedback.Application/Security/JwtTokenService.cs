using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeedbackApp.CrossCutting.Exceptions;
using FeedbackApp.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FeedbackApp.Application.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _chave;
        private readonly string _emissor;
        private readonly string _publico;

        public JwtTokenService(IConfiguration configuration)
        {
            _chave = configuration["Jwt:SecretKey"]?.Trim()
                     ?? throw new JwtException(new[] { "Jwt:SecretKey não está configurado." });

            _emissor = configuration["Jwt:Issuer"]?.Trim()
                       ?? throw new JwtException(new[] { "Jwt:Issuer não está configurado." });

            _publico = configuration["Jwt:Audience"]?.Trim()
                       ?? throw new JwtException(new[] { "Jwt:Audience não está configurado." });
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
    }
}
