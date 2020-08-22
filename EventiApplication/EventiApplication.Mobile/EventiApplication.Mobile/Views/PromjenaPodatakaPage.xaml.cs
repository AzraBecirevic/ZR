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
    public partial class PromjenaPodatakaPage : ContentPage
    {
        Korisnik korisnik;
        MojiPodaciViewModel model = null;
        private readonly APIService _gradService = new APIService("Grad");
        public PromjenaPodatakaPage()
        {
            InitializeComponent();
            BindingContext=  model = new MojiPodaciViewModel();
          
        }

        protected async override void OnAppearing()
        {

            GradoviPicker.ItemsSource = await _gradService.Get<List<Grad>>(null); 
            base.OnAppearing();
            model.Init();
        }
    }
}