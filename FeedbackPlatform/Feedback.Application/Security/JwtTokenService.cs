using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeedbackApp.Domain.Entities;
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
                     ?? throw new InvalidOperationException("Jwt:SecretKey não está configurado.");

            _emissor = configuration["Jwt:Issuer"]?.Trim()
                       ?? throw new InvalidOperationException("Jwt:Issuer não está configurado.");

            _publico = configuration["Jwt:Audience"]?.Trim()
                       ?? throw new InvalidOperationException("Jwt:Audience não está configurado.");
        }

        public string GerarToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chave));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var token = new JwtSecurityToken(
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
