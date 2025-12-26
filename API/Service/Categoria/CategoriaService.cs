
// using Hoteis.API.DTO;
// using Hoteis.API.Repository;
// using Hoteis.API.Model;

// namespace Hoteis.API.Service
// {
//     public class CategoriaService : ICategoriaService
//     {

//         private readonly ICategoriaRepository _repository;
//         private readonly ILogger<CategoriaService> _logger;


//         public CategoriaService(ICategoriaRepository repository, ILogger<CategoriaService> logger)
//         {
//             _repository = repository;
//             _logger = logger;
//         }

//         public async Task<Categoria> Delete(int id)
//         {
//             if (id <= 0)
//             {
//                 throw new ArgumentException("O ID deve ser maior que zero.", nameof(id));
//             }

//             var categoria = await _repository.BuscarPorIdAsync(id);

//             if (categoria == null) throw new KeyNotFoundException($"Categoria com ID {id} não encontrado");

//             var categoriaDeletar = await _repository.RemoverAsync(id);
            
//             return categoriaDeletar;
//         }

//         public async Task<IEnumerable<Categoria>> GetAll()
//         {
//             return await _repository.ListarTodosAsync();
//         }

//         public async Task<Categoria> GetById(int id)
//         {
//             if (id == null)
//             {
//                 throw new ArgumentNullException(nameof(id));
//             }
//             var categoria = await _repository.BuscarPorIdAsync(id);
//             return categoria;
//         }

//         public async Task NovaCategoria(CategoriaDto dto)
//         {
//             if (dto == null)
//             {
//                 throw new ArgumentNullException(nameof(dto));
//             }
//             if (string.IsNullOrWhiteSpace(dto.Nome_Categoria))
//             {
//                 throw new ArgumentException("O nome da categoria é obrigatório", nameof(dto.Nome_Categoria));
//             }

//             try
//             {
//                 var NovaCategoria = new Categoria
//                 {
//                     Nome_Categoria = dto.Nome_Categoria.Trim()
//                 };
//                 await _repository.AdicionarAsync(NovaCategoria);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Erro inesperado ao criar nova categoria");
//                 throw;
//             }
//         }
//     }
// }

//Classe inoperante