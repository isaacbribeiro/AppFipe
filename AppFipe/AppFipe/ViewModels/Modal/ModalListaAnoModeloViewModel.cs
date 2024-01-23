using AppFipe.Models.Models;
using AppFipe.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFipe.ViewModels.Modal
{
    public class ModalListaAnoModeloViewModel : INotifyPropertyChanged
    {
        private readonly ConsultarFipeViewModel _consultarFipe;
        private readonly RequisicaoAPI _requisicaoAPI;

        public ModalListaAnoModeloViewModel(ConsultarFipeViewModel consultarFipe, RequisicaoAPI requisicaoAPI)
        {
            _consultarFipe = consultarFipe;
            _requisicaoAPI = requisicaoAPI;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<DadosVeiculo> _listaAnoModelo = new ObservableCollection<DadosVeiculo>();

        public ObservableCollection<DadosVeiculo> ListaAnoModelo
        {
            get => _listaAnoModelo;
            set => _listaAnoModelo = value;
        }

        public ICommand InserirNaLista
        {
            get
            {
                return new Command<Veiculo>(async (veiculo) =>
                {
                    var dados = await _requisicaoAPI.GetMarcaAnoModelo(veiculo);

                    ListaAnoModelo.Clear();
                    dados.ForEach(x => ListaAnoModelo.Add(x));

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

                    ListaAnoModelo.Clear();

                    foreach (var lin in dados)
                    {
                        if (lin.Nome.Contains(caractereBusca.ToUpper()))
                            ListaAnoModelo.Add(lin);
                    }

                });
            }
        }

        public ICommand AnoModeloSelecionado
        {
            get
            {
                return new Command<Tuple<DadosVeiculo, Veiculo>>(async (parametros) =>
                {
                    try
                    {
                        _consultarFipe.AnoModelo = parametros.Item1.Codigo;

                        _consultarFipe.LabelAnoModelo = parametros.Item1.Nome;

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
