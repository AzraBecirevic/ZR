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
    public partial class DobijeniPoziviPage : ContentPage
    {
        DobijeniPoziviViewModel model = null;
        public DobijeniPoziviPage()
        {
            InitializeComponent();
            BindingContext = model = new DobijeniPoziviViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }
        private void ObrisiPoziv_Clicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            int id = int.Parse(button.CommandParameter.ToString());
            model.ObrisiPoziv(id);
        }

        private async void PrihvatiPoziv_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int id = int.Parse(button.CommandParameter.ToString());
            await model.PrihvatiPoziv(id);
        }

        private async void OdbijPoziv_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int id = int.Parse(button.CommandParameter.ToString());
            await model.OdbijPoziv(id);
        }

        private void StariPozivi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DobijeniStariPoziviPage());
        }
    }
}