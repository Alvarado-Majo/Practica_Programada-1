using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.DAL.Entidad;

namespace PracticaProgramada1.DAL.Data
{
    public partial class PracticaDBContext : DbContext
    {
        public PracticaDBContext(DbContextOptions<PracticaDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Nombre).HasColumnName("Nombre").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Apellido).HasColumnName("Apellido").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(30);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FechaRegistro).HasColumnName("FechaRegistro").HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
            });


            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.ToTable("TELEFONO");
                entity.HasKey(e => e.Id_Telefono);
                entity.Property(e => e.Id_Telefono).HasColumnName("Id_Telefono");
                entity.Property(e => e.Numero).HasColumnName("Numero").HasMaxLength(15).IsRequired();
                entity.Property(e => e.Tipo).HasColumnName("Tipo").HasMaxLength(30);
                entity.Property(e => e.FKCLIENTE).HasColumnName("FKCLIENTE").IsRequired();
                entity.HasOne(e => e.Cliente).WithMany(c => c.Telefonos).HasForeignKey(e => e.FKCLIENTE).HasConstraintName("FK_TELEFONO_CLIENTE");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}