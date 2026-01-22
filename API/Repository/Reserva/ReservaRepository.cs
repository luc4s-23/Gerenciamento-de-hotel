using Hoteis.API.Data;
using Hoteis.API.DTO;
using Hoteis.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReservaReadDTO>> ListarTodosAsync()
        {
            return await _context.reservas
                .Select(r => new ReservaReadDTO
                {
                    IdReserva = r.Id_reserva,
                    NumeroQuarto = r.Quarto.Numero_quarto,
                    TipoQuarto = r.Quarto.tipo,
                    DataCheckIn = r.DataCheckIn,
                    DataCheckOut = r.DataCheckOut,
                    QuantidadeDiarias = r.QuantidadeDiarias,
                    ValorTotal = r.ValorTotal,
                    Status = r.Status
                })
                .ToListAsync();
        }

        public async Task<Reserva?> BuscarPorIdAsync(int id)
        {
            return await _context.reservas.FindAsync(id);
        }

        public async Task AdicionarAsync(Reserva reserva)
        {
            _context.reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizarasync(Reserva reserva)
        {
            _context.reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var reserva_deletado = await _context.reservas.FindAsync(id);
            _context.reservas.Remove(reserva_deletado);

            await _context.SaveChangesAsync();

        }
    }
}