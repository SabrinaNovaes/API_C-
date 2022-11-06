using C__API.Database;
using C__API.Model;
using Microsoft.EntityFrameworkCore;

namespace C__API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context) {
            _context = context;
        }
        public void AddUsuarios(Usuario usuario)
        {
            _context.Add(usuario);
        }
        public void AtualizarUsuarios(Usuario usuario)
        {
            _context.Update(usuario);
        }
        public void DeletarUsuarios(Usuario usuario)
        {
            _context.Remove(usuario);
        }
        public async Task<Usuario> GetUsuariosById(int id)
        {
            return await _context.Usuarios
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}