using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeedbackApp.CrossCutting.Exceptions;
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
                     ?? throw new InternalServerErrorException(new[] { "Jwt:SecretKey não está configurado." }, "Erro de Configuração");

            _emissor = configuration["Jwt:Issuer"]?.Trim()
                       ?? throw new InternalServerErrorException(new[] { "Jwt:Issuer não está configurado." }, "Erro de Configuração");

            _publico = configuration["Jwt:Audience"]?.Trim()
                       ?? throw new InternalServerErrorException(new[] { "Jwt:Audience não está configurado." }, "Erro de Configuração");
        }

        public string GerarToken(UsuarioModel usuario)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chave));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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
