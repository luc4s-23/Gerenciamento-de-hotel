using Hoteis.API.Model;
using Hoteis.API.DTO;
using Hoteis.API.Repository;

namespace Hoteis.API.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reserva> CreateAsync(ReservaDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("Informe todos os dados necessários", nameof(dto));
            }

            /*
                Implementar uma verificação do Número do quarto, se o mesmo já existe e se já esta reservado ou não!!!
                
            if (string.IsNullOrEmpty(dto.Numero_quarto)) // Adicione Numero_quarto ao DTO se necessário
            {
                throw new ArgumentException("Número do quarto é obrigatório");
            }

            // Cheque se o quarto existe e está disponível
            var quartoExistente = await _repositoryQuarto.BuscarPorNumeroAsync(dto.Numero_quarto); // Assuma um repositório para Quarto
            if (quartoExistente == null)
            {
                throw new KeyNotFoundException($"Quarto com número {dto.Numero_quarto} não encontrado");
            }
            if (quartoExistente.Status != "Disponivel") // Assuma um enum ou string para status
            {
                throw new InvalidOperationException($"Quarto {dto.Numero_quarto} já está reservado ou indisponível");
            }
            */

            var reserva = new Reserva
            {
                Nome_hospede = dto.Nome_hospede,
                Contato_hospede = dto.Contato_hospede,
                Documento_hospede = dto.Documento_hospede,
                Data_entrada = DateTime.Now,
                Data_saida = null,
                Preco_total = dto.Preco_total.Value,
                Quantidade_hospedes = dto.Quantidade_hospedes.Value
            };

            //Tratar o status do quarto BEM AQUI no momento que for efetuada a reserva!!!
            await _repository.AdicionarAsync(reserva);
            return reserva;
        }
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Reserva não encontrada!", nameof(id));
            }
            await _repository.DeletarAsync(id);
        }
        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _repository.ListarTodosAsync();
        }

        public async Task<Reserva> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Reserva não encontrada!", nameof(id));
            }
            var reservaPorId = await _repository.BuscarPorIdAsync(id);
            return reservaPorId;
        }

        public async Task<Reserva> UpdateAsync(int id, ReservaDTO dto)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"O ID {id} informado não existe ou não foi encontrado", nameof(id));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var AtualizarReserva = await _repository.BuscarPorIdAsync(id);
            if (AtualizarReserva == null)
            {
                throw new KeyNotFoundException($"Reserva com ID {id} não encontrada");
            }
            if (dto.Nome_hospede != null)
            {
                AtualizarReserva.Nome_hospede = dto.Nome_hospede;
            }
            if (dto.Contato_hospede != null)
            {
                AtualizarReserva.Contato_hospede = dto.Contato_hospede;
            }
            if (dto.Documento_hospede != null)
            {
                AtualizarReserva.Documento_hospede = dto.Documento_hospede;
            }
            if (dto.Data_entrada.HasValue)
            {
                AtualizarReserva.Data_entrada = dto.Data_entrada.Value;
            }
            if (dto.Preco_total.HasValue)
            {
                AtualizarReserva.Preco_total = dto.Preco_total.Value;
            }
            if (dto.Data_entrada.HasValue)
            {
                AtualizarReserva.Quantidade_hospedes = dto.Quantidade_hospedes.Value;
            }
            await _repository.Atualizarasync(AtualizarReserva);
            return AtualizarReserva;
        }
    }
}