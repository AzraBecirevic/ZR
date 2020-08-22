using EventiApplication.Mobile.ViewModels;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventiApplication.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KomentarPage : ContentPage
    {
        RatingViewModel model = null;
        private readonly APIService _kupovinaService = new APIService("Kupovina");
        private readonly APIService _recenzijaService = new APIService("Recenzija");

        int KupovinaId = 0;
        Recenzija Recenzija = null;

        public KomentarPage(int kupovinaId)
        {
            InitializeComponent();
            BindingContext = model = new RatingViewModel();
            KupovinaId = kupovinaId;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Init();
        }

        private async void Init()
        {
            RecenzijaInit();
            var kupovina = await _kupovinaService.GetById<Kupovina>(KupovinaId);
            if (kupovina != null)
            {
                await model.Init(kupovina.EventId);
            }
        }

        private async void RecenzijaInit()
        {
            RecenzijaSearchRequest request = new RecenzijaSearchRequest { KupovinaId = this.KupovinaId };
            var recenzije = await _recenzijaService.Get<List<Recenzija>>(request);

            if (recenzije != null && recenzije.Count == 1)
            {
                Recenzija = recenzije[0];
                KomentarUnos.Text = Recenzija.Komentar;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.SpasiOcjenu();
           
            if (!string.IsNullOrWhiteSpace(KomentarUnos.Text))
            {
                RecenzijaInsertRequest request = new RecenzijaInsertRequest { Komentar = KomentarUnos.Text, KupovinaId = this.KupovinaId };

                if (Recenzija == null)
                {
                    var result = await _recenzijaService.Insert<Recenzija>(request);
                }
                else
                {
                    if (!Recenzija.Komentar.Equals(KomentarUnos.Text))
                    {
                        var result = await _recenzijaService.Update<Recenzija>(Recenzija.Id, request);
                    }     
                }
                   
            }

            Init();

        }
    }
}