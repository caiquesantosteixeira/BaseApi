using Base.Domain.Shared.Entidades.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Base.Infra.Context
{
    public class IdentityDataContext: IdentityDbContext<Usuario>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity => {
                entity.ToTable("usuarios");
                entity.HasKey(x => x.Id);

            });
        }
    }
}
