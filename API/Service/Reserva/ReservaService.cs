using Hoteis.API.Model;
using Hoteis.API.DTO;
using Hoteis.API.Repository;
using Hoteis.API.Data;
using Microsoft.EntityFrameworkCore;


namespace Hoteis.API.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly IQuartoRepository _quartoRepository;
        private readonly AppDbContext _context;

        public ReservaService(IReservaRepository repository, IQuartoRepository quartoRepository, AppDbContext context)
        {
            _repository = repository;
            _quartoRepository = quartoRepository;
            _context = context;
        }

        public async Task<Reserva> ReservarQuartoAsync(ReservaDTO dto, int quarto_id_fk)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (quarto_id_fk <= 0)
                throw new ArgumentException("ID do quarto inválido.", nameof(quarto_id_fk));

            if (dto.QuantidadeDiarias <= 0)
                throw new ArgumentException("Quantidade de diárias deve ser maior que zero");

            if (!dto.Quantidade_hospedes.HasValue)
                throw new ArgumentException("Quantidade de hóspedes é obrigatória.");

            var quarto = await _quartoRepository.BuscarPorIdAsync(quarto_id_fk);

            if (quarto == null)
                throw new KeyNotFoundException($"Quarto com ID {quarto_id_fk} não encontrado.");

            //var dataEntrada = DateTime.UtcNow;
            //var dataSaida = dataEntrada.AddDays(dto.Quantidade_diarias);

            //var precoTotal = quarto.Preco_diaria * dto.Quantidade_diarias;

            var reserva = new Reserva
            {
                Quarto_ID_FK = quarto_id_fk,
                Nome_hospede = dto.Nome_hospede,
                Contato_hospede = dto.Contato_hospede,
                Documento_hospede = dto.Documento_hospede,
                QuantidadeDiarias = dto.QuantidadeDiarias,
                Quantidade_hospedes = dto.Quantidade_hospedes.Value,
                DataCheckIn = DateTime.UtcNow,
                DataCheckOut = dto.DataCheckIn.AddDays(dto.QuantidadeDiarias),
                Status = Reserva.StatusReserva.CheckInRealizado,
                ValorTotal = dto.QuantidadeDiarias * quarto.Preco_diaria
            };

            quarto.Ocupar();

            await _repository.AdicionarAsync(reserva);
            await _quartoRepository.AtualizarAsync(quarto);

            return reserva;
        }
        public async Task DeletePorIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Reserva não encontrada!", nameof(id));
            }
            await _repository.DeletarAsync(id);
        }
        public async Task<List<ReservaReadDTO>> BuscarTodosAsync()
        {
            return await _context.reservas
                .Select(r => new ReservaReadDTO
                {
                    IdReserva = r.Id_reserva,
                    Nome_hospede = r.Nome_hospede,
                    NumeroQuarto = r.Quarto.Numero_quarto,
                    DataCheckIn = r.DataCheckIn,
                    DataCheckOut = r.DataCheckOut,
                    QuantidadeDiarias = r.QuantidadeDiarias,
                    ValorTotal = r.ValorTotal,
                    Status = r.Status,
                    Contato_hospede = r.Contato_hospede,
                    Documento_hospede = r.Documento_hospede
                })
                .ToListAsync();
        }
        public async Task<ReservaReadDTO?> BuscarPorIdAsync(int id)
        {
            return await _context.reservas
                .Where(r => r.Id_reserva == id)
                .Select(r => new ReservaReadDTO
                {
                    IdReserva = r.Id_reserva,
                    Nome_hospede = r.Nome_hospede,
                    NumeroQuarto = r.Quarto.Numero_quarto,
                    DataCheckIn = r.DataCheckIn,
                    DataCheckOut = r.DataCheckOut,
                    QuantidadeDiarias = r.QuantidadeDiarias,
                    ValorTotal = r.ValorTotal,
                    Status = r.Status,
                    Contato_hospede = r.Contato_hospede,
                    Documento_hospede = r.Documento_hospede
                })
                .FirstOrDefaultAsync();
        }
        public async Task<Reserva> AtualizarAsync(int id, ReservaDTO dto)
        {
            var reserva = await _context.reservas.FindAsync(id);
            if (reserva.Id_reserva <= 0)
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
            if (dto.Quantidade_hospedes.HasValue)
            {
                AtualizarReserva.Quantidade_hospedes = dto.Quantidade_hospedes.Value;
            }
            await _repository.Atualizarasync(AtualizarReserva);
            return AtualizarReserva;
        }
    }
}