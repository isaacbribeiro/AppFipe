using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.ChartEntry;
using SkiaSharp;
using AppFipe.Services;
using AppFipe.ViewModels;

namespace AppFipe.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
    {
        List<Entry> entryList;
        public Home ()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();

            entryList = new List<Entry>();

            LoadEntries();

            linesChart.Chart = new LineChart()
            {
                Entries = entryList
            };

        }

        private void LoadEntries()
        {
            Entry e1 = new Entry((float)8.5)
            {
                Label = "Jan",
                ValueLabel = "8.5%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e2 = new Entry((float)-3.2)
            {
                Label = "Fev",
                ValueLabel = "-3.2%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e3 = new Entry((float)2.0)
            {
                Label = "Mar",
                ValueLabel = "2.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e4 = new Entry((float)15.0)
            {
                Label = "Abr",
                ValueLabel = "15.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e5 = new Entry((float)5.0)
            {
                Label = "Maio",
                ValueLabel = "5.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e6 = new Entry((float)7.5)
            {
                Label = "Jun",
                ValueLabel = "7.5%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e7 = new Entry((float)-2.0)
            {
                Label = "Jul",
                ValueLabel = "-2.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e8 = new Entry((float)10.0)
            {
                Label = "Ago",
                ValueLabel = "10.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e9 = new Entry((float)5.5)
            {
                Label = "Set",
                ValueLabel = "5.5%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e10 = new Entry((float)12.0)
            {
                Label = "Out",
                ValueLabel = "12.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e11 = new Entry((float)8.0)
            {
                Label = "Nov",
                ValueLabel = "8.0%",
                Color = SKColor.Parse("#F9A825")
            };

            Entry e12 = new Entry((float)4.5)
            {
                Label = "Dez",
                ValueLabel = "4.5%",
                Color = SKColor.Parse("#F9A825")
            };

            entryList.Add(e1);
            entryList.Add(e2);
            entryList.Add(e3);
            entryList.Add(e4);
            entryList.Add(e5);
            entryList.Add(e6);
            entryList.Add(e7);
            entryList.Add(e8);
            entryList.Add(e9);
            entryList.Add(e10);
            entryList.Add(e11);
            entryList.Add(e12);

        }

    }
}