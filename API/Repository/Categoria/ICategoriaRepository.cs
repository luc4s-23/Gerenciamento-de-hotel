using System.Collections;
using CategoriaModel = Hoteis.API.Model.Categoria;

namespace Hoteis.API.Repository
{
    public interface ICategoriaRepository
    {
        Task<IList> ListarTodosAsync();
        Task<CategoriaModel> BuscarPorIdAsync(CategoriaModel categoria);
        Task AdicionarAsync(CategoriaModel categoria);
        Task AtualizarAsync(CategoriaModel categoria);
        Task RemoverAsync(int id);
    }
}