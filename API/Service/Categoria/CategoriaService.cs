
using Hoteis.API.DTO;
using Hoteis.API.Repository;
using Hoteis.API.Model;

namespace Hoteis.API.Service
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task NovaCategoria(CategoriaDto dto)
        {
            var NovaCategoria = new Categoria
            {
                Nome_Categoria = dto.Nome_Categoria
            };
            await _repository.AdicionarAsync(NovaCategoria);
        }

        public Task<Categoria> Update(CategoriaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}