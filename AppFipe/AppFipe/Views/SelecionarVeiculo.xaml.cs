using AppFipe.Services;
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
    public partial class SelecionarVeiculo : ContentPage
    {
        public SelecionarVeiculo()
        {
            InitializeComponent();

            BindingContext = new SelecionarVeiculoViewModel();
        }
    }
}