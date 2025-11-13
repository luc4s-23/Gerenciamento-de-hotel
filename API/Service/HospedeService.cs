using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoteis.API.Extras;
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
        public async Task<Hospede?> AdicionarHospedeAsync(Hospede hospede)
        {
            try
            {
                var validacao = new HospedeValidator();
                var resultado = validacao.Validate(hospede);

                if (!resultado.IsValid)
                {
                    var erros = string.Join(", ", resultado.Errors.Select(e => e.ErrorMessage));
                    return erros;
                }
                
                var novoHospede = await _repository.AdicionarAsync(hospede);
                
            }
            catch (Exception ex)
            {

                return null;
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


        //Método usado para fazer a validação dos dados no momento que for inserir algum registro(Hospede)
        // public async Task<(int Status, object? MensagemOuObjeto)> ValidarHospedeAsync(Hospede hospede)
        // {
        //     if (hospede == null)
        //         return (400, "Os dados não foram enviados");

        //     if (string.IsNullOrWhiteSpace(hospede.Nome_hospede) || hospede.Nome_hospede == null)
        //         return (400, "O nome é obrigatório");

        //     if (string.IsNullOrWhiteSpace(hospede.CPF_hospede) || hospede.CPF_hospede.Length != 11)
        //         return (400, "CPG inválido. Deve conter 11 dígitos.");

        //     var existente = await _repository.BuscarPorCPFAsync(hospede.CPF_hospede);
        //     if (existente != null)
        //     {
        //         return (409, "Já existe um registro com este CPF.");
        //     }
        //     return (200, "Validação concluída com sucesso.");
        // }
    }
}