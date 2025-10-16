using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoteis.API.Model;

namespace Hoteis.API.Service
{
    public interface IHospedeService
    {
        Task<IEnumerable<Hospede>> ListarTodosAsync();
        Task<Hospede?> BuscarPorIdAsync(int id);
        Task AdicionarHospedeAsync(Hospede hospede);
        Task AtualizarCadastroAsync(Hospede hospede);
        Task ExcluirHospedeAsync(Hospede hospede);
    }
}