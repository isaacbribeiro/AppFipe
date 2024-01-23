using AppFipe.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFipe.Services.Interfaces
{
    public interface IRequisicaoAPI
    {
        Task<List<DadosVeiculo>> GetMarcaAnoModelo(Veiculo veiculo);
        Task<ListaModelos> GetModelo(Veiculo veiculo);
        Task<TabelaFipe> Resultado(Veiculo veiculo);
    }
}
