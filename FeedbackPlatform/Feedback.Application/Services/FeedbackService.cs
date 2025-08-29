using System.Net;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using FeedbackApp.CrossCutting.Exceptions;
using FeedbackApp.Domain.Security;
using static FeedbackApp.Application.Utils.Constants.MensagemErro;

namespace FeedbackApp.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IObjectConverter _mapper;

        public FeedbackService(
            IFeedbackRepository feedbackRepository,
            IUsuarioService usuarioService,
            IJwtTokenService jwtTokenService,
            IObjectConverter mapper)
        {
            _feedbackRepository = feedbackRepository;
            _usuarioService = usuarioService;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<FeedbackResponse> CriarFeedbackAsync(FeedbackRequest request)
        {
            if (request == null)
                throw new FeedbackErrosException(RequestNula, HttpStatusCode.BadRequest, RequisicaoInvalida);

            UsuarioResponse? destinatario = await _usuarioService.ObterUsuarioPorIdAsync(request.DestinatarioId);

            UsuarioTokenInfo usuarioLogado = _jwtTokenService.ObterUsuarioLogado();

            if (usuarioLogado.Id == request.DestinatarioId)
                throw new FeedbackErrosException(ErroRemetenteDestinatarioIgual, HttpStatusCode.BadRequest, ErroValidacao);

            if (request.Texto.Length > 500)
                throw new FeedbackErrosException(FeedbackTextoLimite, HttpStatusCode.BadRequest, ErroValidacao);

            FeedbackArgument argument = _mapper.Map<FeedbackArgument>(request);

            argument.RemetenteId = usuarioLogado.Id;

            FeedbackModel feedbackAdicionado = await _feedbackRepository.CriarFeedbackAsync(argument);

            return _mapper.Map<FeedbackResponse>(feedbackAdicionado);
        }

        public async Task<FeedbackResponse> AtualizarFeedbackAsync(FeedbackRequest request)
        {
            if (request == null)
                throw new FeedbackErrosException(RequestNula, HttpStatusCode.BadRequest, RequisicaoInvalida);

            if (request.Id <= 0)
                throw new FeedbackErrosException(IdInvalido, HttpStatusCode.BadRequest, ErroValidacao);

            if (request.Texto.Length > 500)
                throw new FeedbackErrosException(FeedbackTextoLimite, HttpStatusCode.BadRequest, ErroValidacao);

            FeedbackResponse? feedbackExistente = await ObterFeedbackPorIdAsync(request.Id);
            UsuarioTokenInfo usuarioLogado = _jwtTokenService.ObterUsuarioLogado();

            if (feedbackExistente!.RemetenteId != usuarioLogado.Id)
                throw new FeedbackErrosException(ApenasRemetenteAtualizaFeedback, HttpStatusCode.Forbidden, AcessoNegado);

            FeedbackArgument argument = _mapper.Map<FeedbackArgument>(request);

            argument.RemetenteId = feedbackExistente.RemetenteId;
            argument.DestinatarioId = feedbackExistente.DestinatarioId;
            argument.DataAtualizacao = DateTime.UtcNow;
            
            FeedbackModel? feedbackAtualizado = await _feedbackRepository.AtualizarFeedbackAsync(argument)
                ?? throw new FeedbackErrosException(FeedbacksNaoEncontrados, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<FeedbackResponse>(feedbackAtualizado);
        }

        public async Task<IEnumerable<FeedbackResponse>> ObterTodosFeedbacksAsync()
        {
            IEnumerable<FeedbackModel> feedbacks = await _feedbackRepository.ObterTodosFeedbacksAsync()
                ?? throw new FeedbackErrosException(FeedbacksNaoEncontrados, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
        }

        public async Task<FeedbackResponse?> ObterFeedbackPorIdAsync(int id)
        {
            if (id <= 0)
                throw new FeedbackErrosException(IdInvalido, HttpStatusCode.BadRequest, ErroValidacao);

            FeedbackModel? feedback = await _feedbackRepository.ObterFeedbackPorIdAsync(id)
                ?? throw new FeedbackErrosException(FeedbackNaoEncontrado, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<FeedbackResponse>(feedback);
        }

        public async Task<IEnumerable<FeedbackResponse?>> ObterFeedbackPorDestinatarioIdAsync(int id)
        {
            if (id <= 0)
                throw new FeedbackErrosException(IdInvalido, HttpStatusCode.BadRequest, ErroValidacao);

            IEnumerable<FeedbackModel?> feedback = await _feedbackRepository.ObterFeedbackPorDestinatarioIdAsync(id)
                ?? throw new FeedbackErrosException(FeedbackNaoEncontrado, HttpStatusCode.NotFound, RecursoInexistente);

            return _mapper.Map<IEnumerable<FeedbackResponse>>(feedback);
        }
    }
}
