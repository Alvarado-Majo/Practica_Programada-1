using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.DAL.Entidad;

namespace PracticaProgramada1.DAL.Data
{
    public class PracticaDBContext : DbContext
    {
        public PracticaDBContext(DbContextOptions<PracticaDBContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Cliente>(entity =>
            {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.nombre).HasColumnName("Nombre").HasMaxLength(30).IsRequired();
            entity.Property(e => e.apellido).HasColumnName("Apellido").HasMaxLength(50).IsRequired();
                entity.Property(e => e.email).HasColumnName("Email").HasMaxLength(30).IsRequired();
            entity.HasIndex(e => e.email).IsUnique();
            entity.Property(e => e.fechaRegistro).HasColumnName("FechaRegistro").HasMaxLength(10).IsRequired();
        });
    }
}
}
