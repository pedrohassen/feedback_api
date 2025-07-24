using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using FeedbackApp.Application.Utils;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain.Interfaces;
using FeedbackApp.Domain.Security;

namespace FeedbackApp.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<UsuarioResponse> RegistrarAsync(RegistroRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de registro não podem ser nulos.");

            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email é obrigatório.", nameof(request));

            if (!Validacoes.ValidarEmail(request.Email))
                throw new ArgumentException("Email inválido.", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new ArgumentException("Senha é obrigatória.", nameof(request));

            Usuario? usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email);
            if (usuarioExistente != null)
                throw new Exception("Email já cadastrado.");

            Usuario novoUsuario = new ()
            {
                Nome = request.Nome,
                Email = request.Email,
                SenhaHash = _passwordHasher.Hash(request.Senha)
            };

            Usuario usuarioCriado = await _usuarioRepository.CriarAsync(novoUsuario);

            return new UsuarioResponse
            {
                Id = usuarioCriado.Id,
                Nome = usuarioCriado.Nome,
                Email = usuarioCriado.Email,
                Token = _jwtTokenService.GerarToken(usuarioCriado)
            };
        }

        public async Task<UsuarioResponse> LoginAsync(LoginRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de login não podem ser nulos.");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email é obrigatório.", nameof(request));

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new ArgumentException("Senha é obrigatória.", nameof(request));

            Usuario? usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null || !_passwordHasher.Verify(request.Senha.Trim(), usuario.SenhaHash))
                throw new Exception("Credenciais inválidas.");

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Token = _jwtTokenService.GerarToken(usuario)
            };
        }

        public async Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync()
        {
            IEnumerable<Usuario> usuarios = await _usuarioRepository.ListarTodosAsync();

            return usuarios.Select(usuario => new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            });
        }

        public async Task<UsuarioResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            Usuario? usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioResponse> AtualizarAsync(int id, AtualizarUsuarioRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de atualização não podem ser nulos.");

            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(request));

            Usuario? usuario = await _usuarioRepository.ObterPorIdAsync(id) ?? throw new Exception("Usuário não encontrado.");

            if (request.Nome is not null)
                usuario.Nome = request.Nome;

            if (request.Email is not null)
            {
                Usuario? usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email);
                if (usuarioExistente != null && usuarioExistente.Id != usuario.Id)
                    throw new Exception("Email já está em uso por outro usuário.");

                usuario.Email = request.Email;
            }

            if (request.NovaSenha is not null)
                usuario.SenhaHash = _passwordHasher.Hash(request.NovaSenha);

            await _usuarioRepository.AtualizarAsync(usuario);

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Token = _jwtTokenService.GerarToken(usuario)
            };
        }

        public async Task RemoverAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            _ = await _usuarioRepository.ObterPorIdAsync(id) ?? throw new Exception("Usuário não encontrado.");

            await _usuarioRepository.RemoverAsync(id);
        }
    }
}
