// using Hoteis.API.Model;
// using Hoteis.API.Repository;

// namespace Hoteis.API.Service
// {
//     public class HospedeService : IHospedeService
//     {
//         private readonly IHospedeRepository _repository;

//         public HospedeService(IHospedeRepository repository)
//         {
//             _repository = repository;
//         }
//         public async Task<(int Status, object? Dados)> AdicionarHospedeAsync(Hospede hospede)
//         {
//             try
//             {
//                 var validacao = await ValidarHospedeAsync(hospede);
//                 if (validacao.Status != 200)
//                     return validacao;

//                 var novoHospede = await _repository.AdicionarAsync(hospede);
//                 return (201, novoHospede);
//             }
//             catch (Exception ex)
//             {

//                 return (500, $"Erro interno ao adicionar hóspede: {ex.Message}");
//             }
//         }
//         public Task AtualizarCadastroAsync(Hospede hospede)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<Hospede?> BuscarPorIdAsync(int id)
//         {
//             throw new NotImplementedException();
//         }

//         public Task ExcluirHospedeAsync(Hospede hospede)
//         {
//             throw new NotImplementedException();
//         }

//         public async Task<IEnumerable<Hospede>?> ListarTodosAsync()
//         {
//             var lista = await _repository.ListarTodosAsync();
//             if (lista == null || !lista.Any())
//             {
//                 return null;
//             }
//             return lista;
//         }

//         public Task<(int Status, object MensagemOuObjeto)> ValidarHospedeAsync(Hospede hospede)
//         {
//             return Task.FromResult((Status: 200, MensagemOuObjeto: (object?)null));
//         }
//     }
// }