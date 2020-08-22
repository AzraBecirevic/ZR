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
    public partial class PasswordPromjenaPage : ContentPage
    {
        MojiPodaciViewModel model = null;
        public PasswordPromjenaPage()
        {
            InitializeComponent();
            BindingContext = model = new MojiPodaciViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();
        }
    }
}