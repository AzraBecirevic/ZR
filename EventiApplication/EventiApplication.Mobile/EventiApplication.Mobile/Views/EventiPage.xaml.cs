using EventiApplication.Mobile.ViewModels;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventiApplication.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventiPage : ContentPage
    {
        int kategorijaId { get; set; } = 0;
        EventiViewModel model = null;

        public EventiPage(int kategorijaId)
        {
            InitializeComponent();
            this.kategorijaId = kategorijaId;
            BindingContext = model = new EventiViewModel();
            model.kategorijaId = kategorijaId;   //? ne treba
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await model.Init(kategorijaId, null);
           
        }

        private async void PretagaBtn_Clicked(object sender, EventArgs e)
        {
            string pretraga = searchBar.Text;

            await model.Init(kategorijaId, pretraga);
        }

        private void EventiList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EventDetaljiPage((e.SelectedItem as Event).Id));
        }
    }
}
