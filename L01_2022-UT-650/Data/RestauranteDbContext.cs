using Microsoft.EntityFrameworkCore;
using L01_2022_UT_650.Models;

namespace L01_2022_UT_650.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Motorista)
                .WithMany()
                .HasForeignKey(p => p.MotoristaId);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Plato)
                .WithMany()
                .HasForeignKey(p => p.PlatoId);
        }
    }
}
