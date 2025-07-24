using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain.Interfaces;
using FeedbackApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorIdAsync(int id) =>
            await _context.Usuarios.FindAsync(id);

        public async Task<Usuario?> ObterPorEmailAsync(string email) =>
            await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<IEnumerable<Usuario>> ListarTodosAsync() =>
            await _context.Usuarios.ToListAsync();

        public async Task<Usuario> CriarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            Usuario? usuario = await ObterPorIdAsync(id);
            if (usuario is not null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistePorEmailAsync(string email) =>
            await _context.Usuarios.AnyAsync(u => u.Email == email);
    }
}
