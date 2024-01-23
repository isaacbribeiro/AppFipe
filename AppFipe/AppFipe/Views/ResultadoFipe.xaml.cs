using AppFipe.Models.Models;
using AppFipe.Services;
using AppFipe.Services.Interfaces;
using AppFipe.ViewModels;
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
    public partial class ResultadoFipe : ContentPage
    {
        public ResultadoFipe(TabelaFipe tabelaFipe)
        {
            InitializeComponent();

            BindingContext = new ResultadoFipeViewModel();
            
            var vm = (ResultadoFipeViewModel)BindingContext;
            vm.CarregarLista.Execute(tabelaFipe);

        }
    }
}