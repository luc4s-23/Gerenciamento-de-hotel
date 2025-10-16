using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoteis.API.Model;
using Hoteis.API.Repository;

namespace Hoteis.API.Service
{
    public class HospedeService : IHospedeService
    {
        private readonly IHospedeRepository _repository;

        public HospedeService(IHospedeRepository repository)
        {
            _repository = repository;
        }
        public Task AdicionarHospedeAsync(Hospede hospede)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarCadastroAsync(Hospede hospede)
        {
            throw new NotImplementedException();
        }

        public Task<Hospede?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirHospedeAsync(Hospede hospede)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hospede>> ListarTodosAsync()
        {
            return await _repository.ListarTodosAsync();
        }
    }
}