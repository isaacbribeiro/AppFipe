using AppFipe.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AppFipe.ViewModels
{
    class ResultadoFipeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<TabelaFipe> _listaTabelaFipe = new ObservableCollection<TabelaFipe>();

        public ObservableCollection<TabelaFipe> ListaTabelaFipe
        {
            get => _listaTabelaFipe;
            set => _listaTabelaFipe = value;
        }

        public ICommand CarregarLista
        {
            get
            {
                return new Command<TabelaFipe>(async (TabelaFipe tabelaFipe) =>
                {
                    try
                    {
                        ListaTabelaFipe.Clear();

                        ListaTabelaFipe.Add(tabelaFipe);

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
