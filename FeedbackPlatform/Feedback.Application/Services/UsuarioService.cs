using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Arguments.Usuario;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Application.Utils;
using FeedbackApp.CrossCutting.Exceptions;
using FeedbackApp.Domain.Security;
using FeedbackApp.Application.Models;

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

        public async Task<UsuarioResponse> RegistrarAsync(UsuarioRequest request)
        {
            if (ValidacoesUsuario.ValidarRegistro(request))
                request.Senha = _passwordHasher.Hash(request.Senha);

            UsuarioModel? usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email.Trim());
            if (usuarioExistente is not null)
                throw new ConflictException(new[] { "Email já cadastrado." }, "Conflito de Cadastro");

            UsuarioArgument argument = _mapper.Map<UsuarioArgument>(request);

            UsuarioModel usuarioAdicionado = await _usuarioRepository.CriarAsync(argument);

            return _mapper.Map<UsuarioResponse>(usuarioAdicionado);
        }

        public async Task<UsuarioResponse> LoginAsync(UsuarioRequest request)
        {
            ValidacoesUsuario.ValidarLogin(request);

            UsuarioModel? usuarioExiste = await _usuarioRepository.ObterPorEmailAsync(request.Email.Trim());

            bool credenciaisInvalidas = usuarioExiste is null || !_passwordHasher.Verify(request.Senha.Trim(), usuarioExiste.SenhaHash);
            if (credenciaisInvalidas)
                throw new UnauthorizedException(new[] { "Credenciais inválidas." }, "Acesso Negado");

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuarioExiste!);
            response.Token = _jwtTokenService.GerarToken(usuarioExiste!.Id, usuarioExiste.Nome, usuarioExiste.Email);

            return response;
        }

        public async Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync()
        {
            IEnumerable<UsuarioModel> usuarios = await _usuarioRepository.ListarTodosAsync();

            return _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

            UsuarioModel? usuario = await _usuarioRepository.ObterPorIdAsync(id)
                ?? throw new NotFoundException(new[] { "Usuário não encontrado." }, "Recurso Inexistente");

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuario);
            return response;
        }

        public async Task<UsuarioResponse> AtualizarAsync(UsuarioRequest request)
        {
            ValidacoesUsuario.ValidarAtualizacao(request);

            request.Senha = _passwordHasher.Hash(request.Senha);

            UsuarioArgument usuarioArgument = _mapper.Map<UsuarioArgument>(request);

            UsuarioModel? usuarioAtualizado = await _usuarioRepository.AtualizarAsync(usuarioArgument)
                ?? throw new NotFoundException(new[] { "Usuário não encontrado." }, "Recurso Inexistente");

            return _mapper.Map<UsuarioResponse>(usuarioAtualizado);
        }

        public async Task<UsuarioResponse> RemoverAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

            UsuarioModel? usuarioRemovido = await _usuarioRepository.RemoverAsync(id)
                ?? throw new NotFoundException(new[] { "Usuário não encontrado." }, "Recurso Inexistente");

            return _mapper.Map<UsuarioResponse>(usuarioRemovido);
        }
    }
}
