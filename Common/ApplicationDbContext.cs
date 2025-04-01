using CRMApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApplicationAPI.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Interacoes)
                .WithOne(i => i.Cliente)
                .HasForeignKey(i => i.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
