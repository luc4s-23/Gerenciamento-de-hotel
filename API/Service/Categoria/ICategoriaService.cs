using Hoteis.API.DTO;

namespace Hoteis.API.Service.Categoria
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> Create(CategoriaDto dto);
        Task<CategoriaDto> GetById(int id);
        Task<IEnumerable<CategoriaDto>> GetAll();
        Task<CategoriaDto> Update(CategoriaDto dto);
        Task Delete(int id);
    }
}