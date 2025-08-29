using System.Net;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using FeedbackApp.Application.Utils;
using FeedbackApp.CrossCutting.Exceptions;
using FeedbackApp.Domain.Security;
using static FeedbackApp.Application.Utils.Constants;
using static FeedbackApp.Application.Utils.Constants.MensagemErro;

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

        public async Task<UsuarioResponse> RegistrarUsuarioAsync(UsuarioRequest request)
        {
            ValidacoesUsuario.ValidarRequest(request, TipoValidacao.Registro);

            request.Senha = _passwordHasher.Hash(request.Senha);
            request.Nome = request.Nome.Trim();
            request.Email = request.Email.Trim();

            UsuarioModel? usuarioExistente = await _usuarioRepository.ObterUsuarioPorEmailAsync(request.Email);
            if (usuarioExistente is not null)
                throw new UsuariosErrosException(EmailJaCadastrado, HttpStatusCode.Conflict, ConflitoCadastro);

            UsuarioArgument argument = _mapper.Map<UsuarioArgument>(request);

            UsuarioModel usuarioAdicionado = await _usuarioRepository.CriarUsuarioAsync(argument);

            return _mapper.Map<UsuarioResponse>(usuarioAdicionado);
        }

        public async Task<UsuarioResponse> LoginUsuarioAsync(UsuarioRequest request)
        {
            ValidacoesUsuario.ValidarRequest(request, TipoValidacao.Login);

            request.Nome = request.Nome.Trim();
            request.Email = request.Email.Trim();

            UsuarioModel? usuarioExiste = await _usuarioRepository.ObterUsuarioPorEmailAsync(request.Email);

            bool credenciaisInvalidas = usuarioExiste is null || !_passwordHasher.Verify(request.Senha, usuarioExiste.Senha);
            if (credenciaisInvalidas)
                throw new UsuariosErrosException(CredenciaisInvalidas, HttpStatusCode.Unauthorized, AcessoNegado);

            UsuarioResponse response = _mapper.Map<UsuarioResponse>(usuarioExiste!);
            response.Token = _jwtTokenService.GerarToken(usuarioExiste!.Id, usuarioExiste.Nome, usuarioExiste.Email);

            return response;
        }

        public async Task<IEnumerable<UsuarioResponse>> ObterTodosUsuariosAsync()
        {
            IEnumerable<UsuarioModel> usuarios = await _usuarioRepository.ObterTodosUsuariosAsync();

            return _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse?> ObterUsuarioPorIdAsync(int id)
        {
            ValidacoesUsuario.ValidarIdUsuario(id);

            UsuarioModel? usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(id)
                ?? throw new UsuariosErrosException(UsuarioNaoEncontrado, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task<UsuarioResponse> AtualizarUsuarioAsync(UsuarioRequest request)
        {
            await ObterUsuarioPorIdAsync(request.Id);

            ValidacoesUsuario.ValidarRequest(request, TipoValidacao.Atualizacao);

            request.Senha = _passwordHasher.Hash(request.Senha);
            request.Nome = request.Nome.Trim();
            request.Email = request.Email.Trim();

            UsuarioArgument usuarioArgument = _mapper.Map<UsuarioArgument>(request);

            UsuarioModel? usuarioAtualizado = await _usuarioRepository.AtualizarUsuarioAsync(usuarioArgument)
                ?? throw new UsuariosErrosException(UsuarioNaoEncontrado, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<UsuarioResponse>(usuarioAtualizado);
        }

        public async Task<UsuarioResponse> RemoverUsuarioAsync(int id)
        {
            ValidacoesUsuario.ValidarIdUsuario(id);

            UsuarioResponse? usuarioExistente = await ObterUsuarioPorIdAsync(id);

            usuarioExistente!.Status = false;

            UsuarioArgument usuarioArgument = _mapper.Map<UsuarioArgument>(usuarioExistente);
            UsuarioModel usuarioAtualizado = await _usuarioRepository.AtualizarUsuarioAsync(usuarioArgument)
                ?? throw new UsuariosErrosException(UsuarioNaoEncontrado, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<UsuarioResponse>(usuarioAtualizado);
        }
    }
}
