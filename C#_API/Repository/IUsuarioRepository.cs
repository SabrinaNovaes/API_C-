using C__API.Model;

namespace C__API.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuariosById(int id);
        void AddUsuarios(Usuario usuario);
        void AtualizarUsuarios(Usuario usuario);
        void DeletarUsuarios(Usuario usuario);

        Task<bool> SaveChangesAsync();
    }
}