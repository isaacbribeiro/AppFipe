using Newtonsoft.Json;
using AppFipe.Models.Models;
using AppFipe.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppFipe.Services
{
    public class RequisicaoAPI : IRequisicaoAPI
    {
        private readonly string _url = "https://parallelum.com.br/fipe/api/v1/";

        public async Task<string> Api(Veiculo veiculo)
        {
            string url = _url + $"{veiculo.Caracteristica}/marcas/";
            url += veiculo.Marca != null ? $"{veiculo.Marca}/modelos/" : "";
            url += veiculo.Modelo != null ? $"{veiculo.Modelo}/anos/" : "";
            url += veiculo.AnoModelo != null ? $"{veiculo.AnoModelo}" : "";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<DadosVeiculo>> GetMarcaAnoModelo(Veiculo veiculo) =>                    
           JsonConvert.DeserializeObject<List<DadosVeiculo>>(await Api(veiculo));
          
        public async Task<ListaModelos> GetModelo(Veiculo veiculo) =>
            JsonConvert.DeserializeObject<ListaModelos>(await Api(veiculo));

        public async Task<TabelaFipe> Resultado(Veiculo veiculo) =>
            JsonConvert.DeserializeObject<TabelaFipe>(await Api(veiculo));
    }
}
