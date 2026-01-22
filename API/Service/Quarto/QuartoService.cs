using Hoteis.API.DTO;
using Hoteis.API.Repository;
using Hoteis.API.Model;

namespace Hoteis.API.Service
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _repository;

        public QuartoService(IQuartoRepository repository)
        {
            _repository = repository;
        }
        public async Task AdicionarQuartoAsync(QuartoDTO dto)
        {
            // Validação básica dos dados do DTO
            if (string.IsNullOrWhiteSpace(dto.Numero_quarto.ToString()))
            {
                throw new ArgumentException("O número do quarto é obrigatório.", nameof(dto.Numero_quarto));
            }

            if (!Enum.IsDefined(typeof(TipoQuarto), dto.tipo))
            {
                throw new ArgumentException("Tipo de quarto inválido.", nameof(dto.tipo));
            }

            if (dto.Preco_diaria <= 0)
            {
                throw new ArgumentException("O preço por noite deve ser maior que zero.", nameof(dto.Preco_diaria));
            }

            // Criação da entidade Quarto a partir do DTO
            var quarto = new Quarto
            {
                // Id seria gerado pelo banco de dados, então não setamos aqui
                Numero_quarto = dto.Numero_quarto,
                tipo = dto.tipo,
                Capacidade = dto.Capacidade.Value,
                Preco_diaria = dto.Preco_diaria.Value,
                Descricao = dto.Descricao
            };
            await _repository.AdicionarAsync(quarto);

            // Aqui você poderia adicionar lógica para salvar no banco de dados,
            // mas como não foi especificado, retornamos apenas a entidade criada.
            // Exemplo: _context.Quartos.Add(quarto); _context.SaveChanges();
        }
        public async Task<IEnumerable<Quarto>> ListarAsync()
        {
            return await _repository.ListarTodosAsync();
        }
        public async Task DeletarQuartoAsync(int id)
        {
            var quartoDeletar = await _repository.BuscarPorIdAsync(id);
            if (quartoDeletar == null)
            {
                throw new ArgumentNullException("Unidade não encontrada, impossível deletar o quarto", nameof(quartoDeletar));
            }
            await _repository.RemoverAsync(quartoDeletar.Id_quarto);
        }
        public async Task<Quarto> BuscarPorIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Unidade não encontrada", nameof(id));
            }
            return await _repository.BuscarPorIdAsync(id);
        }
        public async Task<Quarto> AtualizarQuartoAsync(int id, QuartoDTO dto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID do quarto precisa ser válido", nameof(id));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var quartoExistente = await _repository.BuscarPorIdAsync(id);
            if (quartoExistente == null)
            {
                throw new KeyNotFoundException($"Quarto com ID: {id} não encontrado");
            }
            // Atribuições condicionais: só atualiza se o valor foi fornecido no DTO
            if (dto.Numero_quarto != null) // Para strings
            {
                quartoExistente.Numero_quarto = dto.Numero_quarto;
            }
            if (dto.tipo != null)
            {
                quartoExistente.tipo = dto.tipo;
            }
            if (dto.Preco_diaria.HasValue) // Para tipos numéricos nullable, como decimal? ou int?
            {
                quartoExistente.Preco_diaria = dto.Preco_diaria.Value;
            }
            if (dto.Capacidade.HasValue)
            {
                quartoExistente.Capacidade = dto.Capacidade.Value;
            }
            if (dto.Descricao != null)
            {
                quartoExistente.Descricao = dto.Descricao;
            }

            await _repository.AtualizarAsync(quartoExistente);
            return quartoExistente;
        }
        public async Task ValidarInfosQuarto(QuartoDTO dto)
        {
            var novoQuarto = await _repository.BuscarPorNumero(dto.Numero_quarto);
            if (novoQuarto != null)
            {
                throw new Exception($"O número de quartos '{dto.Numero_quarto}, já está em uso, por favor, use outro!'");
            }
            //var categoriaExistente = await _quartoRepository.
        }

    }
}