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
    public partial class PoziviPage : ContentPage
    {
        public PoziviPage()
        {
            InitializeComponent();
        }

        private void PoslaniPozivi_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new PoslaniPoziviPage());
        }

        private void DobijeniPozivi_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new DobijeniPoziviPage());
        }
    }
}