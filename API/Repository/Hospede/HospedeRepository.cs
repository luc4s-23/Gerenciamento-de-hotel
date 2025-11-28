// using System.Collections;
// using System.Collections.Generic;
// using Hoteis.API.Data;
// using Hoteis.API.Model;
// using Microsoft.EntityFrameworkCore;

// namespace Hoteis.API.Repository
// {
//     public class HospedeRepository : IHospedeRepository
//     {
//         private readonly AppDbContext _context;

//         public HospedeRepository(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IEnumerable<Hospede>> ListarTodosAsync()
//         {
//             return await _context.hospedes.ToListAsync();
//         }

//         public async Task<Hospede?> BuscarPorIdAsync(int id)
//         {
//             return await _context.hospedes.FindAsync(id);
//         }

//         public async Task<Hospede> AdicionarAsync(Hospede hospede)
//         {
//             _context.hospedes.Add(hospede);
//             await _context.SaveChangesAsync();
//             return hospede;
//         }

//         public async Task Atualizarasync(Hospede hospede)
//         {
//             _context.hospedes.Update(hospede);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeletarAsync(Hospede hospede)
//         {
//             var hospede_deletado = await BuscarPorIdAsync(hospede.Id_hospede);

//             if (hospede_deletado != null)
//             {
//                 _context.hospedes.Remove(hospede_deletado);

//                 await _context.SaveChangesAsync();
//             }
//         }

//         public async Task<Hospede?> BuscarPorCPFAsync(string cpf)
//         {
//             return await _context.hospedes.FirstOrDefaultAsync(h => h.CPF_hospede == cpf);
            
//         }
//     }
// }