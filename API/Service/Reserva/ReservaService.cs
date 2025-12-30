using Hoteis.API.Model;
using Hoteis.API.DTO;
using Hoteis.API.Repository;

namespace Hoteis.API.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly IQuartoRepository _quartoRepository;

        public ReservaService(IReservaRepository repository, IQuartoRepository quartoRepository)
        {
            _repository = repository;
            _quartoRepository = quartoRepository;
        }

        public async Task<Reserva> CreateAsync(ReservaDTO dto, int quarto_id_fk)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (quarto_id_fk <= 0)
                throw new ArgumentException("ID do quarto inválido.", nameof(quarto_id_fk));

            if (!dto.Preco_total.HasValue)
                throw new ArgumentException("Preço total é obrigatório.");

            if (!dto.Quantidade_hospedes.HasValue)
                throw new ArgumentException("Quantidade de hóspedes é obrigatória.");

            var quarto = await _quartoRepository.BuscarPorIdAsync(quarto_id_fk);

            if (quarto == null)
                throw new KeyNotFoundException($"Quarto com ID {quarto_id_fk} não encontrado.");

            if (quarto.Status == "Ocupado")
                throw new InvalidOperationException("Quarto já está ocupado.");

            var reserva = new Reserva
            {
                Quarto_ID_FK = quarto_id_fk,
                Nome_hospede = dto.Nome_hospede,
                Contato_hospede = dto.Contato_hospede,
                Documento_hospede = dto.Documento_hospede,
                Data_entrada = DateTime.Now,
                Preco_total = dto.Preco_total.Value,
                Quantidade_hospedes = dto.Quantidade_hospedes.Value
            };

            quarto.Status = "Ocupado";

            await _repository.AdicionarAsync(reserva);
            await _quartoRepository.AtualizarAsync(quarto);

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