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
    public partial class RatingPage : ContentPage
    {
        int EventId { get; set; }
        RatingViewModel model = null;
        public RatingPage(int id)
        {
            InitializeComponent();
            EventId = id;
            BindingContext = model = new RatingViewModel();
           // model.EventId = EventId;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(EventId);
        }
    }
}