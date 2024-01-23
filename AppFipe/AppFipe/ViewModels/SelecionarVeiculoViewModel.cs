using AppFipe.Services;
using AppFipe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFipe.ViewModels
{
    internal class SelecionarVeiculoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RedirecionaConsultarFipe
        {
            get
            {
                return new Command<string>((string caracteristica) =>
                {                   
                     Application.Current.MainPage.Navigation.PushAsync(new ConsultarFipe(caracteristica));
                });
            }
        }

    }
}
