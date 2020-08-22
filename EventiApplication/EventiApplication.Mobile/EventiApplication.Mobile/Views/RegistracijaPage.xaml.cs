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
    public partial class RegistracijaPage : ContentPage
    {
        private readonly APIService _registracijaService = new APIService("Registracija");
        public List<Grad> gradovi = new List<Grad>();
       
        public RegistracijaPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {

            gradovi = await _registracijaService.Get<List<Grad>>(null);
          
            GradoviPicker.ItemsSource = gradovi;

            base.OnAppearing();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }


    }
}