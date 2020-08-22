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
    public partial class KupiKartuPage : ContentPage
    {
        //int EventId = 0;
        KupiKartuViewModel model = null;
        public KupiKartuPage(int eventId)
        {
            InitializeComponent();
            BindingContext = model = new KupiKartuViewModel();
            model.EventId = eventId;
            BrKarata.Keyboard = Keyboard.Numeric;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            IzborTipaKarte.ItemsSource = model.prodajaTipovi;
            
        }
    }
}