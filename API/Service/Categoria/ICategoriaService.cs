
using Hoteis.API.DTO;
using Hoteis.API.Model;

namespace Hoteis.API.Service
{
    public interface ICategoriaService
    {
        Task NovaCategoria(CategoriaDto dto);
        Task<Categoria> GetById(int id);
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> Update(CategoriaDto dto);
        Task Delete(int id);
    }
}