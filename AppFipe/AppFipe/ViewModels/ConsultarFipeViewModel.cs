using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using AppFipe.Models.Models;
using AppFipe.Services;
using AppFipe.Views;
using AppFipe.Views.Modal;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace AppFipe.ViewModels
{
    public class ConsultarFipeViewModel : INotifyPropertyChanged
    {
        private readonly RequisicaoAPI _requisicaoAPI;

        public ConsultarFipeViewModel(RequisicaoAPI requisicaoAPI)
        {
            _requisicaoAPI = requisicaoAPI;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string _imagem;

        ObservableCollection<DadosVeiculo> _listaMarca = new ObservableCollection<DadosVeiculo>();
        ObservableCollection<DadosVeiculo> _listaModelo = new ObservableCollection<DadosVeiculo>();
        ObservableCollection<DadosVeiculo> _listaAnoModelo = new ObservableCollection<DadosVeiculo>();

        public string Imagem
        {
            get => _imagem;
            set
            {
                _imagem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Imagem"));
            }
        }

        string _labelMarca = "Selecione uma Marca";

        public string LabelMarca
        {
            get => _labelMarca;
            set
            {
                _labelMarca = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LabelMarca"));
            }
        }

        string _labelModelo = "Selecione um Modelo";

        public string LabelModelo
        {
            get => _labelModelo;
            set
            {
                _labelModelo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LabelModelo"));
            }
        }

        string _labelAnoModelo = "Selecione o Ano Modelo";

        public string LabelAnoModelo
        {
            get => _labelAnoModelo;
            set
            {
                _labelAnoModelo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LabelAnoModelo"));
            }
        }

        public string Caracteristica { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }

        public ICommand VeiculoSelecionado
        {
            get
            {
                return new Command<string>((string caracteristica) =>
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.Caracteristica = caracteristica;

                    switch (caracteristica)
                    {

                        case "carros":
                            Imagem = "carro_preto";
                            break;

                        case "motos":
                            Imagem = "moto_preto";
                            break;

                        case "caminhoes":
                            Imagem = "caminhao_preto";
                            break;

                    }

                    Caracteristica = caracteristica;
                    Marca = null;
                    Modelo = null;
                    AnoModelo = null;

                });
            }
        }

        public ICommand ModalMarca
        {
            get
            {
                return new Command(async () =>
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.Caracteristica = Caracteristica;
                    await PopupNavigation.Instance.PushAsync(new ModalListaMarca(this, veiculo));
                });
            }
        }

        public ICommand ModalModelo
        {
            get
            {
                return new Command(async () =>
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.Caracteristica = Caracteristica;
                    veiculo.Marca = Marca;
                    if (veiculo.Marca != null)
                        await PopupNavigation.Instance.PushAsync(new ModalListaModelo(this, veiculo));
                });
            }
        }

        public ICommand ModalAnoModelo
        {
            get
            {
                return new Command(async () =>
                {
                    Veiculo veiculo = new Veiculo();
                    veiculo.Caracteristica = Caracteristica;
                    veiculo.Marca = Marca;
                    veiculo.Modelo = Modelo;
                    if (Modelo != null)
                        await PopupNavigation.Instance.PushAsync(new ModalListaAnoModelo(this, veiculo));
                });
            }
        }

        public ICommand PesquisarFipe
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (Marca != null && Modelo != null && AnoModelo != null)
                        {
                            Veiculo veiculo = new Veiculo();
                            veiculo.Caracteristica = Caracteristica;
                            veiculo.Marca = Marca;
                            veiculo.Modelo = Modelo;
                            veiculo.AnoModelo = AnoModelo;

                            TabelaFipe tabelaFipe = await _requisicaoAPI.Resultado(veiculo);

                            await Application.Current.MainPage.Navigation.PushAsync(new ResultadoFipe(tabelaFipe));
                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Ops", "Preencha todos os dados", "Ok");
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
