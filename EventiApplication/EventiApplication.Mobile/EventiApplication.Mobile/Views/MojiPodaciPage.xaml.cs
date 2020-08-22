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
    public partial class MojiPodaciPage : ContentPage
    {
        MojiPodaciViewModel model = null;
        public MojiPodaciPage()
        {
            InitializeComponent();
            BindingContext = model = new MojiPodaciViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();
        }

        private void PromijeniPodatke_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PromjenaPodatakaPage());
        }

        private void PromijeniLozinku_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PasswordPromjenaPage());
        }
    }
}