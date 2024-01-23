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
    public partial class ModalListaModelo : PopupPage
    {
        Veiculo veiculoGlobal;

        public ModalListaModelo(ConsultarFipeViewModel consultarFipe, Veiculo veiculo)
        {
            InitializeComponent();

            RequisicaoAPI requisicaoAPI = new RequisicaoAPI();

            BindingContext = new ModalListaModeloViewModel(consultarFipe, requisicaoAPI);

            veiculoGlobal = veiculo;

            var vm = (ModalListaModeloViewModel)BindingContext;
            vm.InserirNaLista.Execute(veiculo);

        }     

        private void BuscarNaLista(object sender, TextChangedEventArgs e)
        {
            var vm = (ModalListaModeloViewModel)BindingContext;
            vm.BuscarNaLista.Execute(new Tuple<Veiculo, string>(veiculoGlobal, e.NewTextValue));
        }

        private void ModeloSelecionado(object sender, ItemTappedEventArgs e)
        {
            var vm = (ModalListaModeloViewModel)BindingContext;
            vm.ModeloSelecionado.Execute(new Tuple<DadosVeiculo, Veiculo>((DadosVeiculo)e.Item, veiculoGlobal));
        }

        private void FecharModal_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }

    }
}