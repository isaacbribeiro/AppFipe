using System.Collections.Generic;

namespace AppFipe.Models.Models
{
    public class DadosVeiculo
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class ListaModelos
    {
        public List<DadosVeiculo> Modelos { get; set; }      
        public List<DadosVeiculo> Anos { get; set; }
    }

}
