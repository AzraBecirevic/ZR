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
    public partial class PrijateljstvoDetaljiPage : ContentPage
    {
        public PrijateljstvoDetaljiPage(int korisnikId)   // ovo je prijatelj trenutno prijavljenog korisnika
        {
            InitializeComponent();
        }
    }
}