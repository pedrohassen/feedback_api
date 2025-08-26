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

        public async Task<FeedbackModel> CriarAsync(FeedbackArgument argument)
        {
            Feedback entidade = _mapper.Map<Feedback>(argument);

            _context.Feedbacks.Add(entidade);
            await _context.SaveChangesAsync();

            return _mapper.Map<FeedbackModel>(entidade);
        }

        public async Task<FeedbackModel?> AtualizarAsync(FeedbackArgument argument)
        {
            Feedback? entidadeExistente = await _context.Feedbacks.FindAsync(argument.Id);

            _mapper.Map(argument, entidadeExistente);
            entidadeExistente!.DataAtualizacao = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return _mapper.Map<FeedbackModel>(entidadeExistente!);
        }

        public async Task<IEnumerable<FeedbackModel>> ListarTodosAsync()
        {
            IEnumerable<Feedback> entidades = await _context.Feedbacks.ToListAsync();

            return _mapper.Map<IEnumerable<FeedbackModel>>(entidades);
        }

        public async Task<FeedbackModel?> ObterPorIdAsync(int id)
        {
            Feedback? entidade = await _context.Feedbacks.FindAsync(id);

            return _mapper.Map<FeedbackModel?>(entidade);
        }
    }
}
