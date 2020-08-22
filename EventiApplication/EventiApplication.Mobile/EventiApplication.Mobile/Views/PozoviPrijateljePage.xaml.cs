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
    public partial class PozoviPrijateljePage : ContentPage
    {
        PozoviPrijateljeViewModel model = null;
        int EventId;
        public PozoviPrijateljePage(int eventID)
        {
            InitializeComponent();
            EventId = eventID;
            BindingContext = model = new PozoviPrijateljeViewModel();
            model.EventId = eventID;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void PozivNaEvent_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int PrijateljId = int.Parse(button.CommandParameter.ToString());
            model.PozoviPrijatelja(EventId, PrijateljId);
        }
    }
}