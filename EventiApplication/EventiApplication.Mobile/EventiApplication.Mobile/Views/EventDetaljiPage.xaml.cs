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
    public partial class EventDetaljiPage : ContentPage
    {
        EventDetaljiViewModel model = null;
        int EventId { get; set; }

        public EventDetaljiPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new EventDetaljiViewModel();
            EventId = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(EventId);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RatingPage(EventId));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PozoviPrijateljePage(EventId));
        }

        private void KupiKartu_Clicked(object sender, EventArgs e)
        {    
            Navigation.PushAsync(new KupiKartuPage(EventId));
        }
    }
}