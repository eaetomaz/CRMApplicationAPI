using CRMApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApplicationAPI.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("CLIENTES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasColumnName("EMAIL").HasMaxLength(100);
                entity.Property(e => e.Telefone).HasColumnName("TELEFONE").HasMaxLength(20);
                entity.Property(e => e.Empresa).HasColumnName("EMPRESA").HasMaxLength(100);
                entity.Property(e => e.Status).HasColumnName("STATUS").IsRequired();
                entity.Property(e => e.DataCadastro).HasColumnName("DATACADASTRO");

                entity.HasMany(e => e.Interacoes)
                      .WithOne(i => i.Cliente)
                      .HasForeignKey(i => i.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Interacao>(entity =>
            {
                entity.ToTable("INTERACOES");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ClienteId).HasColumnName("CLIENTEID");
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
                entity.Property(e => e.DataInteracao).HasColumnName("DATA");
            });
        }
    }
}
