using FeedbackApp.Application.DTOs.Requests.Usuario;
using FeedbackApp.Application.DTOs.Responses.Usuario;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
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
        private readonly IObjectConverter _mapper;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtTokenService,
            IObjectConverter mapper)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> RegistrarAsync(RegistroRequest request)
        {
            ValidacoesUsuario.ValidarRegistro(request);

            Usuario? usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email!);
            if (usuarioExistente != null)
                throw new InvalidOperationException("Email já cadastrado.");

            //Usuario novoUsuario = _mapper.Map<RegistroRequest, Usuario>(request);
            Usuario novoUsuario = new Usuario
            {
                Nome = request.Nome ?? string.Empty,
                Email = request.Email ?? string.Empty,
                // SenhaHash você vai atribuir logo em seguida (como já faz)
            };
            novoUsuario.SenhaHash = _passwordHasher.Hash(request.Senha);

            Usuario usuarioCriado = await _usuarioRepository.CriarAsync(novoUsuario);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuarioCriado);
            response.Token = _jwtTokenService.GerarToken(usuarioCriado);

            return response;
        }

        public async Task<UsuarioResponse> LoginAsync(LoginRequest request)
        {
            ValidacoesUsuario.ValidarLogin(request);

            Usuario? usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email.Trim());

            if (usuario == null || !_passwordHasher.Verify(request.Senha.Trim(), usuario.SenhaHash))
                throw new Exception("Credenciais inválidas.");

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuario);
            response.Token = _jwtTokenService.GerarToken(usuario);

            return response;
        }

        public async Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync()
        {
            IEnumerable<Usuario> usuarios = await _usuarioRepository.ListarTodosAsync();

            IEnumerable<UsuarioResponse> response = _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);

            return response;
        }

        public async Task<UsuarioResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            Usuario? usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null)
                return null;

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuario);
            return response;
        }

        public async Task<UsuarioResponse> AtualizarAsync(int id, AtualizarUsuarioRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dados de atualização não podem ser nulos.");

            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            ValidacoesUsuario.ValidarAtualizacao(request);

            Usuario? usuario = await _usuarioRepository.ObterPorIdAsync(id)
                ?? throw new Exception("Usuário não encontrado.");

            //_mapper.Map<AtualizarUsuarioRequest, Usuario>(request, usuario);
            usuario.Nome = request.Nome ?? usuario.Nome;
            usuario.Email = request.Email ?? usuario.Email;

            if (request.NovaSenha is not null)
                usuario.SenhaHash = _passwordHasher.Hash(request.NovaSenha);

            await _usuarioRepository.AtualizarAsync(usuario);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuario);
            response.Token = _jwtTokenService.GerarToken(usuario);

            return response;
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
