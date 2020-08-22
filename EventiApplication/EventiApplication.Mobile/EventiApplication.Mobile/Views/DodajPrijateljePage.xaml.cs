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
    public partial class DodajPrijateljePage : ContentPage
    {
        DodajPrijateljeViewModel model;
        public DodajPrijateljePage()
        {
            InitializeComponent();
            BindingContext = model = new DodajPrijateljeViewModel();
        }

        private void DodajPrijatelje_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int id = int.Parse(button.CommandParameter.ToString());

            model.DodajPrijatelja(id);
            
        }
    }
}