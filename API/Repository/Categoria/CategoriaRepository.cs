
// using Hoteis.API.Data;
// using Microsoft.EntityFrameworkCore;
// using Hoteis.API.Model;

// namespace Hoteis.API.Repository
// {
//     public class CategoriaRepository : ICategoriaRepository
//     {
//         private readonly AppDbContext _context;
//         private readonly ILogger<CategoriaRepository> _logger;

//         public CategoriaRepository(AppDbContext context, ILogger<CategoriaRepository> logger)
//         {
//             _context = context;
//             _logger = logger;
//         }

//         public async Task AdicionarAsync(Categoria categoria)
//         {
//             try
//             {
//                 _context.categorias.Add(categoria);
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateException dbEx)
//             {
//                 _logger.LogError(dbEx, "Erro ao inserir categoria no banco de dados.");
//                 throw;
//             }
//         }

//         public async Task AtualizarAsync(Categoria categoria)
//         {
//             try
//             {
//                 _context.categorias.Update(categoria);
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateException dbEx)
//             {
//                 _logger.LogError(dbEx, "Erro ao atualizar categoria no banco de dados.");
//                 throw;
//             }

//         }

//         public async Task<Categoria> BuscarPorIdAsync(int id)
//         {
//             return await _context.categorias.FindAsync(id);
//         }

//         public async Task<IEnumerable<Categoria>> ListarTodosAsync()
//         {
//             return await _context.categorias.ToListAsync();
//         }

//         public async Task<Categoria> RemoverAsync(int id)
//         {
//             try
//             {
//                 var categoria = await _context.categorias.FindAsync(id);
//                 if (categoria != null)
//                 {
//                     _context.categorias.Remove(categoria);
//                     await _context.SaveChangesAsync();
//                 }
//                 return categoria;
//             }
//             catch (DbUpdateException dbEx)
//             {
//                 _logger.LogError(dbEx, "Erro ao deletar categoria no banco de dados.");
//                 throw;
//             }
//         }
//     }
// }