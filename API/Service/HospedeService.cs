using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoteis.API.Model;
using Hoteis.API.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hoteis.API.Service
{
    public class HospedeService : IHospedeService
    {
        private readonly IHospedeRepository _repository;

        public HospedeService(IHospedeRepository repository)
        {
            _repository = repository;
        }
        public async Task<(int Status, object? Dados)> AdicionarHospedeAsync(Hospede hospede)
        {
            try
            {
                var validacao = await ValidarHospedeAsync(hospede);
                if (validacao.Status != 200)
                    return validacao;

                var novoHospede = await _repository.AdicionarAsync(hospede);
                return (201, novoHospede);
            }
            catch (Exception ex)
            {

                return (500, $"Erro interno ao adicionar hóspede: {ex.Message}");
            }
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

        public async Task<IEnumerable<Hospede>?> ListarTodosAsync()
        {
            var lista = await _repository.ListarTodosAsync();
            if (lista == null || !lista.Any())
            {
                return null;
            }
            return lista;
        }

        public async Task<(int Status, object? MensagemOuObjeto)> ValidarHospedeAsync(Hospede hospede)
        {
            if (hospede == null)
                return (400, "Os dados não foram enviados");

            if (string.IsNullOrWhiteSpace(hospede.Nome_hospede))
                return (400, "O nome é obrigatório");

            if (string.IsNullOrWhiteSpace(hospede.CPF_hospede) || hospede.CPF_hospede.Length != 11)
                return (400, "CPG inválido. Deve conter 11 dígitos.");

            var existente = await _repository.BuscarPorCPFAsync(hospede.CPF_hospede);
            if (existente != null)
            {
                return (409, "Já existe um registro com este CPF.");
            }
            return (200, "Validação concluída com sucesso.");
        }
    }
}