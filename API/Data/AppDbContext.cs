using Hoteis.API.Model;
using Microsoft.EntityFrameworkCore;


namespace Hoteis.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Quarto> quartos { get; set; }
        public DbSet<Reserva> reservas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quarto>()
                .Property(q => q.Preco_diaria)
                .HasPrecision(18, 2);
                
            modelBuilder.Entity<Reserva>()
                .Property(r => r.ValorTotal)
                .HasPrecision(18, 2);
                
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Quarto)
                .WithMany()
    .           HasForeignKey(r => r.Quarto_ID_FK);
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Reserva>()
        //         .HasOne(r => r.hospede)
        //         .WithMany(h => h.reservas)
        //         .HasForeignKey(r => r.Hospede_ID_FK);

        //     modelBuilder.Entity<Reserva>()
        //         .HasOne(r => r.Quarto)
        //         .WithMany(q => q.reservas)
        //         .HasForeignKey(r => r.Quarto_ID_FK);
        // }
    }
}