// using Hoteis.API.Model;

// namespace Hoteis.API.Service
// {
//     public interface IHospedeService
//     {
//         Task<IEnumerable<Hospede>> ListarTodosAsync();
//         Task<Hospede?> BuscarPorIdAsync(int id);
//         Task<(int Status, object? Dados)> AdicionarHospedeAsync(Hospede hospede);
//         Task AtualizarCadastroAsync(Hospede hospede);
//         Task ExcluirHospedeAsync(Hospede hospede);
//         Task<(int Status, object MensagemOuObjeto)> ValidarHospedeAsync(Hospede hospede);
//     }
// }