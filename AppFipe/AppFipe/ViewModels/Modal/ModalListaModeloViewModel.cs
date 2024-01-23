using AppFipe.Models.Models;
using AppFipe.Services;
using AppFipe.Services.Interfaces;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AppFipe.ViewModels.Modal
{
    public class ModalListaModeloViewModel : INotifyPropertyChanged
    {
        private readonly ConsultarFipeViewModel _consultarFipe;
        private readonly RequisicaoAPI _requisicaoAPI;

        public ModalListaModeloViewModel(ConsultarFipeViewModel consultarFipe, RequisicaoAPI requisicaoAPI)
        {
            _consultarFipe = consultarFipe;
            _requisicaoAPI = requisicaoAPI;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<DadosVeiculo> _listaModelo = new ObservableCollection<DadosVeiculo>();

        public ObservableCollection<DadosVeiculo> ListaModelo
        {
            get => _listaModelo;
            set => _listaModelo = value;
        }

        public ICommand InserirNaLista
        {
            get
            {
                return new Command<Veiculo>(async (veiculo) =>
                {
                    var dados = await _requisicaoAPI.GetModelo(veiculo);

                    ListaModelo.Clear();
                    dados.Modelos.ForEach(x => ListaModelo.Add(x));

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

                    var dados = await _requisicaoAPI.GetModelo(veiculo);

                    ListaModelo.Clear();

                    foreach (var lin in dados.Modelos)
                    {
                        if (lin.Nome.Contains(caractereBusca.ToUpper()))
                            ListaModelo.Add(lin);
                    }
                });
            }
        }

        public ICommand ModeloSelecionado
        {
            get
            {
                return new Command<Tuple<DadosVeiculo, Veiculo>>(async (parametros) =>
                {
                    try
                    {
                        _consultarFipe.Modelo = parametros.Item1.Codigo;
                        _consultarFipe.AnoModelo = null;

                        _consultarFipe.LabelModelo = parametros.Item1.Nome;
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
