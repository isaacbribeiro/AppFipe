using AppFipe.Services;
using AppFipe.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFipe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarFipe : ContentPage
    {
        public ConsultarFipe(string caracteristica)
        {
            InitializeComponent();

            RequisicaoAPI requisicaoAPI = new RequisicaoAPI();

            BindingContext = new ConsultarFipeViewModel(requisicaoAPI);

            var vm = (ConsultarFipeViewModel)BindingContext;
            vm.VeiculoSelecionado.Execute(caracteristica);

        }     

    }
}