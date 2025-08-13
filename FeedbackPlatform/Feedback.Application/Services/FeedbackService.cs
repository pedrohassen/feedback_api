//using FeedbackApp.Application.Interfaces;
//using FeedbackApp.Application.Mapper;
//using FeedbackApp.Application.Requests.Feedback;
//using FeedbackApp.Application.Responses.Feedback;
//using FeedbackApp.Application.Utils;
//using FeedbackApp.CrossCutting.Exceptions;
//using FeedbackApp.Domain.Entities;
//using FeedbackApp.Domain.Interfaces;

//namespace FeedbackApp.Application.Services
//{
//    public class FeedbackService : IFeedbackService
//    {
//        private readonly IFeedbackRepository _feedbackRepository;
//        private readonly IObjectConverter _mapper;

//        public FeedbackService(
//            IFeedbackRepository feedbackRepository,
//            IObjectConverter mapper)
//        {
//            _feedbackRepository = feedbackRepository;
//            _mapper = mapper;
//        }

//        public async Task<FeedbackResponse?> ObterPorIdAsync(int id)
//        {
//            if (id <= 0)
//                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

//            Feedback? feedback = await _feedbackRepository.ObterPorIdAsync(id);
//            if (feedback == null)
//                throw new NotFoundException(new[] { "Feedback não encontrado." }, "Recurso Inexistente");

//            FeedbackResponse response = _mapper.Map<FeedbackResponse>(feedback);
//            return response;
//        }

//        public async Task<IEnumerable<FeedbackResponse>> ObterPorUsuarioIdAsync(int usuarioId)
//        {
//            if (usuarioId <= 0)
//                throw new BadRequestException(new[] { "ID de usuário inválido." }, "Erro de Validação");

//            IEnumerable<Feedback> feedbacks = await _feedbackRepository.ObterPorUsuarioIdAsync(usuarioId);
//            IEnumerable<FeedbackResponse> response = _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);

//            return response;
//        }

//        public async Task<IEnumerable<FeedbackResponse>> ObterTodosAsync()
//        {
//            IEnumerable<Feedback> feedbacks = await _feedbackRepository.ObterTodosAsync();
//            IEnumerable<FeedbackResponse> response = _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);

//            return response;
//        }

//        public async Task<FeedbackResponse> AdicionarAsync(CriarFeedbackRequest request)
//        {
//            ValidacoesFeedback.ValidarCriarFeedback(request);

//            Feedback novoFeedback = new (request.Texto, request.UsuarioId);

//            await _feedbackRepository.AdicionarAsync(novoFeedback);
//            FeedbackResponse response = _mapper.Map<FeedbackResponse>(novoFeedback);

//            return response;
//        }

//        public async Task<FeedbackResponse> AtualizarAsync(int id, AtualizarFeedbackRequest request)
//        {
//            if (id <= 0)
//                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

//            ValidacoesFeedback.ValidarAtualizarFeedback(request);

//            Feedback? feedbackExistente = await _feedbackRepository.ObterPorIdAsync(id)
//                ?? throw new NotFoundException(new[] { "Feedback não encontrado." }, "Recurso Inexistente");

//            feedbackExistente.AtualizarTexto(request.Texto);
//            await _feedbackRepository.AtualizarAsync(feedbackExistente);
//            FeedbackResponse response = _mapper.Map<FeedbackResponse>(feedbackExistente);

//            return response;
//        }

//        public async Task DeletarAsync(int id)
//        {
//            if (id <= 0)
//                throw new BadRequestException(new[] { "ID inválido." }, "Erro de Validação");

//            _ = await _feedbackRepository.ObterPorIdAsync(id)
//                ?? throw new NotFoundException(new[] { "Feedback não encontrado." }, "Recurso Inexistente");

//            await _feedbackRepository.RemoverAsync(id);
//        }
//    }
//}
