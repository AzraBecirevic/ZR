using EventiApplication.Mobile.ViewModels;
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
    public partial class DobijeniZahtijevi : ContentPage
    {
        DobijeniZahtijeviViewModel model = null;
        public DobijeniZahtijevi()
        {
            InitializeComponent();
            BindingContext = model = new DobijeniZahtijeviViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int prijateljstvoId = int.Parse(btn.CommandParameter.ToString());

            bool action = await DisplayAlert("", "Da li ste sigurni da zelite obrisati zahtjev?", "Da", "Ne");

            if (action)
            {
                await model.ObrisiZahtjev(prijateljstvoId);
                await model.Init();
            }

        }

        private async void PrihvatiZahtjev_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int prijateljstvoId = int.Parse(btn.CommandParameter.ToString());

            await model.PrihvatiZahtjev(prijateljstvoId);
            await model.Init();
        }
    }
}