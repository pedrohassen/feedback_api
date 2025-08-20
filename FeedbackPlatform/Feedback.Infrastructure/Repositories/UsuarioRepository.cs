using FeedbackApp.Domain.Entities;
using FeedbackApp.Application.Models;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Application.Interfaces;
using FeedbackApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Application.Arguments;

namespace FeedbackApp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        private readonly IObjectConverter _mapper;

        public UsuarioRepository(
            AppDbContext context,
            IObjectConverter mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioModel?> ObterPorIdAsync(int id)
        {
            Usuario? entidade = await _context.Usuarios.FindAsync(id);
            if (entidade == null)
                return null;
            return _mapper.Map<UsuarioModel?>(entidade);
        }

        public async Task<UsuarioModel?> ObterPorEmailAsync(string email)
        {
            Usuario? entidade = await _context.Usuarios.FirstOrDefaultAsync(user => user.Email == email);
            if (entidade == null)
                return null;
            return _mapper.Map<UsuarioModel?>(entidade);
        }

        public async Task<IEnumerable<UsuarioModel>> ListarTodosAsync()
        {
            IEnumerable<Usuario> entidades = await _context.Usuarios.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioModel>>(entidades);
        }

        public async Task<UsuarioModel> CriarAsync(UsuarioArgument argument)
        {
            Usuario entidade = _mapper.Map<Usuario>(argument);

            _context.Usuarios.Add(entidade);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioModel>(entidade);
        }

        public async Task<UsuarioModel?> AtualizarAsync(UsuarioArgument argument)
        {
            Usuario entidade = _mapper.Map<Usuario>(argument);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioModel>(entidade);
        }

        public async Task<UsuarioModel?> RemoverAsync(int id)
        {
            Usuario? entidade = await _context.Usuarios.FindAsync(id);
            if (entidade == null)
                return null;

            _context.Usuarios.Remove(entidade);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioModel>(entidade);
        }
    }
}
