using AppFipe.Models.Models;
using AppFipe.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFipe.ViewModels
{
    internal class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RedirecionaSelecionarVeiculo
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new SelecionarVeiculo());
                });
            }
        }

    }
}
