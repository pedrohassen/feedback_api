using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Requests.Usuario;
using FeedbackApp.Application.Responses.Usuario;
using FeedbackApp.Application.Utils;
using FeedbackApp.CrossCutting.Exceptions;
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

            UsuarioModel? usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email!);
            if (usuarioExistente != null)
                throw new ConflictException(new[] { "Email já cadastrado." }, "Conflito de Cadastro");

            UsuarioArgument novoUsuario = _mapper.Map<UsuarioArgument>(request);

            novoUsuario.SenhaHash = _passwordHasher.Hash(request.Senha);

            UsuarioModel usuarioCriado = await _usuarioRepository.CriarAsync(novoUsuario);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuarioCriado);

            return response;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            ValidacoesUsuario.ValidarLogin(request);

            UsuarioModel? usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email.Trim());

            if (usuario == null || !_passwordHasher.Verify(request.Senha.Trim(), usuario.SenhaHash))
                throw new UnauthorizedException(new[] { "Credenciais inválidas." }, "Acesso Negado");

            LoginResponse response = _mapper.Map<LoginResponse>(usuario);
            response.Token = _jwtTokenService.GerarToken(usuario);

            return response;
        }

        public async Task<IEnumerable<UsuarioResponse>> ListarUsuariosAsync()
        {
            IEnumerable<UsuarioModel> usuarios = await _usuarioRepository.ListarTodosAsync();

            IEnumerable<UsuarioResponse> response = _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);

            return response;
        }

        public async Task<UsuarioResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

            UsuarioModel? usuarioModel = await _usuarioRepository.ObterPorIdAsync(id)
                ?? throw new NotFoundException(new[] { "Usuário não encontrado." }, "Recurso Inexistente");

            UsuarioArgument usuarioArgument = _mapper.Map<UsuarioArgument>(usuarioModel);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuarioArgument);
            return response;
        }

        public async Task<UsuarioResponse> AtualizarAsync(int id, AtualizarUsuarioRequest request)
        {
            if (request == null)
                throw new BadRequestException(new[] { "Dados de atualização não podem ser nulos." }, "Erro de Validação");

            if (id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

            ValidacoesUsuario.ValidarAtualizacao(request);

            UsuarioModel usuarioModel = await _usuarioRepository.ObterPorIdAsync(id)
                ?? throw new NotFoundException(new[] { "Usuário não encontrado." }, "Recurso Inexistente");

            _mapper.Map(request, usuarioModel);
            usuarioModel.Id = id;

            if (request.NovaSenha is not null)
                usuarioModel.SenhaHash = _passwordHasher.Hash(request.NovaSenha);

            UsuarioArgument usuarioArgument = _mapper.Map<UsuarioArgument>(usuarioModel);

            await _usuarioRepository.AtualizarAsync(usuarioArgument);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuarioModel);

            return response;
        }

        public async Task RemoverAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

            _ = await _usuarioRepository.ObterPorIdAsync(id)
                ?? throw new NotFoundException(new[] { "Usuário não encontrado." }, "Recurso Inexistente");

            await _usuarioRepository.RemoverAsync(id);
        }
    }
}
