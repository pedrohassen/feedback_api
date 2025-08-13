//using FeedbackApp.Application.Arguments;
//using FeedbackApp.Application.Mapper;
//using FeedbackApp.Domain.Entities;
//using FeedbackApp.Domain.Interfaces;
//using FeedbackApp.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//namespace FeedbackApp.Infrastructure.Repositories
//{
//    public class FeedbackRepository : IFeedbackRepository
//    {
//        private readonly AppDbContext _context;
//        private readonly IObjectConverter _mapper;

//        public FeedbackRepository(
//            AppDbContext context,
//            IObjectConverter mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<FeedbackArgument?> ObterPorIdAsync(int id)
//        {
//            Feedback? feedback = await _context.Feedbacks.FindAsync(id);
//            if (feedback == null) return null;

//            return _mapper.Map<FeedbackArgument>(feedback);
//        }

//        public async Task<IEnumerable<FeedbackArgument>> ObterPorUsuarioIdAsync(int usuarioId)
//        {
//            List<Feedback> feedbacks = await _context.Feedbacks
//                .Where(f => f.UsuarioId == usuarioId)
//                .ToListAsync();

//            return _mapper.Map<IEnumerable<FeedbackArgument>>(feedbacks);
//        }

//        public async Task<IEnumerable<FeedbackArgument>> ObterTodosAsync()
//        {
//            List<Feedback> feedbacks = await _context.Feedbacks.ToListAsync();

//            return _mapper.Map<IEnumerable<FeedbackArgument>>(feedbacks);
//        }

//        public async Task AdicionarAsync(FeedbackArgument feedback)
//        {
//            Feedback feedbackEntity = _mapper.Map<Feedback>(feedback);

//            await _context.Feedbacks.AddAsync(feedbackEntity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task AtualizarAsync(FeedbackArgument feedback)
//        {
//            Feedback feedbackEntity = _mapper.Map<Feedback>(feedback);

//            _context.Feedbacks.Update(feedbackEntity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task RemoverAsync(int id)
//        {
//            var feedback = await ObterPorIdAsync(id);
//            if (feedback != null)
//            {
//                _context.Feedbacks.Remove(feedback);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
