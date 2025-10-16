using System.Collections;
using Hoteis.API.Data;
using Hoteis.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.Repository
{
    public class QuartoRepository
    {
        private readonly AppDbContext _context;

        public QuartoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList> ListarTodosAsync()
        {
            return await _context.quartos.ToListAsync();
        }

        public async Task<Quarto?> BuscarPorIdAsync(int id)
        {
            return await _context.quartos.FindAsync(id);
        }

        public async Task AdicionarAsync(Quarto quarto)
        {
            _context.quartos.Add(quarto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Quarto quarto)
        {
            _context.quartos.Update(quarto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var quarto = await BuscarPorIdAsync(id);
            if (quarto != null)
            {
                _context.quartos.Remove(quarto);
                await _context.SaveChangesAsync();
            }
        }
    }
}