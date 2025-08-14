using FeedbackApp.Application.Arguments.Usuario;
using FeedbackApp.Application.Mapper;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain.Interfaces;
using FeedbackApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UsuarioModel?> ObterPorIdAsync(int id) =>
            await _context.Usuarios.FindAsync(id);

        public async Task<UsuarioModel?> ObterUsuarioEntidadePorIdAsync(int id) =>
            await _context.Usuarios.FindAsync(id);

        public async Task<UsuarioModel?> ObterPorEmailAsync(string email) =>
            await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<IEnumerable<UsuarioModel>> ListarTodosAsync() =>
            await _context.Usuarios.ToListAsync();

        public async Task<UsuarioModel> CriarAsync(UsuarioArgument usuarioArgument)
        {
            UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioArgument);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task AtualizarAsync(UsuarioArgument usuarioArgument)
        {
            UsuarioModel? usuario = await _context.Usuarios.FindAsync(usuarioArgument.Id);

            _mapper.Map(usuarioArgument, usuario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            UsuarioModel? usuario = await _context.Usuarios.FindAsync(id);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
