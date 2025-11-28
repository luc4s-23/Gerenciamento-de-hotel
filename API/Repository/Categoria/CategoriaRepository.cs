
using System.Collections;
using Hoteis.API.Data;
using Microsoft.EntityFrameworkCore;
using CategoriaModel = Hoteis.API.Model.Categoria;

namespace Hoteis.API.Repository.Categoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public async Task AdicionarAsync(CategoriaModel categoria)
        {
            _context.categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(CategoriaModel categoria)
        {
            _context.categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoriaModel> BuscarPorIdAsync(CategoriaModel categoria)
        {
            return await _context.categorias.FindAsync(categoria.Id_Categoria);
        }

        public async Task<IList> ListarTodosAsync()
        {
            return await _context.categorias.ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var categoria = await _context.categorias.FindAsync(id);
            if(categoria != null)
            {
                _context.categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}