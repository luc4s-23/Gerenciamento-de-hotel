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
            var reserva = new Reserva
            {
                Quarto_ID_FK = dto.Quarto_ID_FK,
                Nome_hospede = dto.Nome_hospede,
                Contato_hospede = dto.Contato_hospede,
                Documento_hospede = dto.Documento_hospede,
                Data_entrada = DateTime.Now,
                Data_saida = dto.Data_saida,
                Preco_total = dto.Preco_total,
                Quantidade_hospedes = dto.Quantidade_hospedes
            };
            await _repository.AdicionarAsync(reserva);
            return reserva;
        }

        public async Task DeleteAsync(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            await _repository.DeletarAsync(id);
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _repository.ListarTodosAsync();
        }

        public async Task<Reserva> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var reservaPorId = await _repository.BuscarPorIdAsync(id);
            return reservaPorId;
        }

        public async Task<Reserva> UpdateAsync(ReservaDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var atualizarReserva = new Reserva
            {
                Quarto_ID_FK = dto.Quarto_ID_FK,
                Nome_hospede = dto.Nome_hospede,
                Contato_hospede = dto.Contato_hospede,
                Documento_hospede = dto.Documento_hospede,
                Data_entrada = DateTime.Now,
                Data_saida = dto.Data_saida,
                Preco_total = dto.Preco_total,
                Quantidade_hospedes = dto.Quantidade_hospedes
            };
            await _repository.Atualizarasync(atualizarReserva);
            return atualizarReserva;
        }
    }
}