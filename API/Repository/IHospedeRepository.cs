using Hoteis.API.Model;

namespace Hoteis.API.Repository
{
    public interface IHospedeRepository
    {
        Task<IEnumerable<Hospede>> ListarTodosAsync();
        Task<Hospede?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Hospede hospede);
        Task Atualizarasync(Hospede hospede);
        Task DeletarAsync(Hospede hospede);
    }
}