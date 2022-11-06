using C__API.Model;
using Microsoft.EntityFrameworkCore;

namespace C__API.Database
{
    public class UsuarioDbContext : DbContext {

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.sobrenome).HasColumnName("sobrenome").IsRequired();
            usuario.Property(x => x.cpf).HasColumnName("cpf").IsRequired();
            usuario.Property(x => x.dataNacimento).HasColumnName("data_nascimento").IsRequired();
            usuario.Property(x => x.telefone).HasColumnName("telefone").IsRequired();
            usuario.Property(x => x.email).HasColumnName("email").IsRequired();
            usuario.Property(x => x.senha).HasColumnName("senha").IsRequired();
        }
    }
}