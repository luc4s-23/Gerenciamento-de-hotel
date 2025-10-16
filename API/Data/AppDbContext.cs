using Hoteis.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Hospede> hospedes { get; set; }
        public DbSet<Quarto> quartos { get; set; }
        public DbSet<Reserva> reservas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}