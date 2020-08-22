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
    public partial class KartePage : ContentPage
    {
        KarteViewModel model = null;
        int KupovinaId = 0;
        public KartePage(int kupovinaId)
        {
            InitializeComponent();
            BindingContext = model = new KarteViewModel();
            KupovinaId = kupovinaId;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(KupovinaId);
        }
    }
}