using AppFipe.Models.Models;
using AppFipe.Services;
using AppFipe.ViewModels;
using AppFipe.ViewModels.Modal;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFipe.Views.Modal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalListaAnoModelo : PopupPage
    {
        Veiculo veiculoGlobal;

        public ModalListaAnoModelo(ConsultarFipeViewModel consultarFipe, Veiculo veiculo)
        {
            InitializeComponent();

            RequisicaoAPI requisicaoAPI = new RequisicaoAPI();

            BindingContext = new ModalListaAnoModeloViewModel(consultarFipe, requisicaoAPI);

            veiculoGlobal = veiculo;

            var vm = (ModalListaAnoModeloViewModel)BindingContext;
            vm.InserirNaLista.Execute(veiculo);

        }

        private void BuscarNaLista(object sender, TextChangedEventArgs e)
        {
            var vm = (ModalListaAnoModeloViewModel)BindingContext;
            vm.BuscarNaLista.Execute(new Tuple<Veiculo, string>(veiculoGlobal, e.NewTextValue));
        }

        private void AnoModeloSelecionado(object sender, ItemTappedEventArgs e)
        {
            var vm = (ModalListaAnoModeloViewModel)BindingContext;
            vm.AnoModeloSelecionado.Execute(new Tuple<DadosVeiculo, Veiculo>((DadosVeiculo)e.Item, veiculoGlobal));
        }

        private void FecharModal_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }

    }
}