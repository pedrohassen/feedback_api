using System.Net;
using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Requests;
using FeedbackApp.Application.Responses;
using FeedbackApp.Application.Utils;
using FeedbackApp.CrossCutting.Exceptions;

namespace FeedbackApp.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IObjectConverter _mapper;

        public FeedbackService(
            IFeedbackRepository feedbackRepository,
            IUsuarioRepository usuarioRepository,
            IObjectConverter mapper)
        {
            _feedbackRepository = feedbackRepository;
            _usuarioRepository = usuarioRepository;

            _mapper = mapper;
        }

        public async Task<FeedbackResponse> CriarAsync(FeedbackRequest request)
        {
            UsuarioModel? remetente = await _usuarioRepository.ObterPorIdAsync(request.RemetenteId)
                ?? throw new FeedbackErrosException("Remetente não encontrado", HttpStatusCode.NotFound);

            UsuarioModel? destinatario = await _usuarioRepository.ObterPorIdAsync(request.DestinatarioId)
                ?? throw new FeedbackErrosException("Destinatário não encontrado", HttpStatusCode.NotFound);

            if (request.RemetenteId == request.DestinatarioId)
                throw new FeedbackErrosException("O remetente não pode ser o mesmo que o destinatário", HttpStatusCode.BadRequest);

            FeedbackArgument argument = _mapper.Map<FeedbackArgument>(request);

            argument.RemetenteId = remetente.Id;
            argument.DestinatarioId = destinatario.Id;

            FeedbackModel feedbackAdicionado = await _feedbackRepository.CriarAsync(argument);

            return _mapper.Map<FeedbackResponse>(feedbackAdicionado);
        }

        public async Task<IEnumerable<FeedbackResponse>> ListarTodosAsync()
        {
            IEnumerable<FeedbackModel> feedbacks = await _feedbackRepository.ListarTodosAsync();

            return _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
        }

        public async Task<FeedbackResponse?> ObterPorIdAsync(int id)
        {
            if (id <= 0)
                throw new FeedbackErrosException("ID inválido.", HttpStatusCode.BadRequest, "Erro de Validação");

            FeedbackModel? feedback = await _feedbackRepository.ObterPorIdAsync(id)
                ?? throw new FeedbackErrosException("Feedback não encontrado.", HttpStatusCode.NotFound, "Recurso Inexistente");

            return _mapper.Map<FeedbackResponse>(feedback);
        }
    }
}
