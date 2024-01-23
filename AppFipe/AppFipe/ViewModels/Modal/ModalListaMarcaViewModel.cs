using AppFipe.Models.Models;
using AppFipe.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppFipe.ViewModels.Modal
{
    public class ModalListaMarcaViewModel : INotifyPropertyChanged
    {
        private readonly ConsultarFipeViewModel _consultarFipe;
        private readonly RequisicaoAPI _requisicaoAPI;

        public ModalListaMarcaViewModel(ConsultarFipeViewModel consultarFipe, RequisicaoAPI requisicaoAPI)
        {
            _consultarFipe = consultarFipe;
            _requisicaoAPI = requisicaoAPI;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<DadosVeiculo> _listaMarca = new ObservableCollection<DadosVeiculo>();

        public ObservableCollection<DadosVeiculo> ListaMarca
        {
            get => _listaMarca;
            set => _listaMarca = value;
        }

        public ICommand InserirNaLista
        {
            get
            {
                return new Command<Veiculo>(async (veiculo) =>
                {
                    var dados = await _requisicaoAPI.GetMarcaAnoModelo(veiculo);

                    ListaMarca.Clear();
                    dados.ForEach(x => ListaMarca.Add(x));

                });
            }
        }

        public ICommand BuscarNaLista
        {
            get
            {
                return new Command<Tuple<Veiculo, string>>(async (parametros) =>
                {
                    Veiculo veiculo = parametros.Item1;
                    string caractereBusca = parametros.Item2;

                    var dados = await _requisicaoAPI.GetMarcaAnoModelo(veiculo);

                    ListaMarca.Clear();

                    foreach (var lin in dados)
                    {
                        if (lin.Nome.Contains(caractereBusca.ToUpper()))
                            ListaMarca.Add(lin);
                    }

                });
            }
        }

        public ICommand MarcaSelecionado
        {
            get
            {
                return new Command<Tuple<DadosVeiculo, Veiculo>>(async (parametros) =>
                {
                    try
                    {
                        _consultarFipe.Marca = parametros.Item1.Codigo;
                        _consultarFipe.Modelo = null;
                        _consultarFipe.AnoModelo = null;

                        _consultarFipe.LabelMarca = parametros.Item1.Nome;
                        _consultarFipe.LabelModelo = "Selecione um Modelo";
                        _consultarFipe.LabelAnoModelo = "Selecione o Ano Modelo";

                        await PopupNavigation.Instance.PopAsync();

                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
                    }
                });
            }
        }

    }
}
