using EventiApplication.Mobile.ViewModels;
using EventiApplication.Model;
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
    public partial class PrijateljstvaPage : ContentPage
    {
        PrijateljstvaViewModel model = null;
        public PrijateljstvaPage()
        {
            InitializeComponent();
            BindingContext = model = new PrijateljstvaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void PoslaniZahtjevi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PoslaniZahtjeviPage());
        }

        private void DobijeniZahtjevi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DobijeniZahtijevi());

        }

        private void DodajNovePrijatelje_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajPrijateljePage());
        }

      
        private async void ObrisiPrijateljstvo_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int prijateljstvoId = int.Parse(btn.CommandParameter.ToString());

            bool action = await DisplayAlert("", "Da li ste sigurni da zelite obrisati prijatelja?", "Da", "Ne");

            if (action)
            {
                await model.ObrisiPrijateljstvo(prijateljstvoId);
            }
        }
    }
}