using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Infrastructure.Data;
using FeedbackApp.Application.Models;
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

        public async Task<FeedbackModel?> ObterPorIdAsync(int id)
        {
            Feedback? entidade = await _context.Feedbacks.FindAsync(id);
            if (entidade == null)
                return null;

            return _mapper.Map<FeedbackModel?>(entidade);
        }

        public async Task<IEnumerable<FeedbackModel>> ListarFeedbacksAsync()
        {
            IEnumerable<Feedback> entidades = await _context.Feedbacks.ToListAsync();
            if (entidades == null || !entidades.Any())
                return Enumerable.Empty<FeedbackModel>();

            return _mapper.Map<IEnumerable<FeedbackModel>>(entidades);
        }
    }
}
