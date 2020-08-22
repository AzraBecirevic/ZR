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
    public partial class PoslaniZahtjeviPage : ContentPage
    {
        PoslaniZahtijeviViewModel model = null;
        public PoslaniZahtjeviPage()
        {
            InitializeComponent();
            BindingContext = model = new PoslaniZahtijeviViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int prijateljstvoId =int.Parse(btn.CommandParameter.ToString());

            bool action = await DisplayAlert("", "Da li ste sigurni da zelite obrisati zahtjev?", "Da", "Ne");

            if (action)
            {
                await model.ObrisiZahtjev(prijateljstvoId);    
            }
           
        }
    }
}