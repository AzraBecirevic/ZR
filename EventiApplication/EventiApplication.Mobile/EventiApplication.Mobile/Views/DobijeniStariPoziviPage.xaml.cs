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
    public partial class DobijeniStariPoziviPage : ContentPage
    {
        DobijeniStariPoziviViewModel model = null;
        public DobijeniStariPoziviPage()
        {
            InitializeComponent();
            BindingContext = model = new DobijeniStariPoziviViewModel();
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
    }
}