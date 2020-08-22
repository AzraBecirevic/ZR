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
    public partial class PosjeceniEventiPage : ContentPage
    {
        PosjeceniEventiViewModel model = null;
        public PosjeceniEventiPage()
        {
            InitializeComponent();
            BindingContext = model = new PosjeceniEventiViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void KomentarButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int KupovinaId = int.Parse(btn.CommandParameter.ToString());
            Navigation.PushAsync(new KomentarPage(KupovinaId));
        }

        private void PsojeceniEventi_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new KartePage((e.SelectedItem as Kupovina).Id));
        }
    }
}