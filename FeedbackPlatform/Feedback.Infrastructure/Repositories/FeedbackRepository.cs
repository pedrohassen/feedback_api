using FeedbackApp.Application.Arguments;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Models;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;
        private readonly IObjectConverter _mapper;

        public FeedbackRepository(
            AppDbContext context,
            IObjectConverter mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FeedbackModel> CriarFeedbackAsync(FeedbackArgument argument)
        {
            Feedback entidade = _mapper.Map<Feedback>(argument);

            _context.Feedbacks.Add(entidade);
            await _context.SaveChangesAsync();

            return _mapper.Map<FeedbackModel>(entidade);
        }

        public async Task<FeedbackModel?> AtualizarFeedbackAsync(FeedbackArgument argument)
        {
            Feedback? entidadeExistente = await _context.Feedbacks.FindAsync(argument.Id);

            _mapper.Map(argument, entidadeExistente);

            await _context.SaveChangesAsync();

            return _mapper.Map<FeedbackModel>(entidadeExistente!);
        }

        public async Task<IEnumerable<FeedbackModel>> ObterTodosFeedbacksAsync()
        {
            IEnumerable<Feedback> entidades = await _context.Feedbacks
                .Include(fb => fb.Destinatario)
                .Include(fb => fb.Remetente)
                .ToListAsync();

            return _mapper.Map<IEnumerable<FeedbackModel>>(entidades);
        }

        public async Task<FeedbackModel?> ObterFeedbackPorIdAsync(int id)
        {
            Feedback? entidade = await _context.Feedbacks
                .Include(fb => fb.Destinatario)
                .Include(fb => fb.Remetente)
                .FirstOrDefaultAsync(fb => fb.Id == id);

            return _mapper.Map<FeedbackModel?>(entidade);
        }

        public async Task<IEnumerable<FeedbackModel?>> ObterFeedbackPorDestinatarioIdAsync(int id)
        {
            IEnumerable<Feedback?> entidade = await _context.Feedbacks
                .Include(fb => fb.Destinatario)
                .Include(fb => fb.Remetente)
                .Where(fb => fb.DestinatarioId == id).ToListAsync();

            return _mapper.Map<IEnumerable<FeedbackModel?>>(entidade);
        }
    }
}
