using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain.Interfaces;
using FeedbackApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Feedback?> ObterPorIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task<IEnumerable<Feedback>> ObterPorUsuarioIdAsync(int usuarioId)
        {
            return await _context.Feedbacks
                .Where(f => f.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> ObterTodosAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task AdicionarAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var feedback = await ObterPorIdAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}
