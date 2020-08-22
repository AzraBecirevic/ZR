using EventiApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventiApplication.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        private readonly APIService _kategorijeService = new APIService("Kategorija");
        List<Kategorija> kategorije = null;
        List<string> urls = new List<string> { "muzika.jpg", "kultura.png", "sport.jpg" };

        public ICommand BtnKulturaClicked { get; set; }
        public ICommand BtnMuzikaClicked { get; set; }
        public ICommand BtnSportClicked { get; set; }

        public HomePage()
        {

            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            kategorije = await _kategorijeService.Get<List<Kategorija>>(null);

            StackLayout stack = new StackLayout();

            if (kategorije != null && kategorije.Count > 0)
            {
                foreach (var k in kategorije)
                {

                    Button button = new Button();

                    button.Text = k.Naziv;
                    button.TextColor = Color.White;
                    button.BackgroundColor = Color.Transparent;
                    button.StyleId = k.Id.ToString();
                    button.BorderColor = Color.Transparent;
                    button.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
                    button.Clicked += Button_Clicked;
                    stack.Children.Add(button);
                }
                Random rnd = new Random();
                int index = rnd.Next(0, 3);    //2
                homePage.BackgroundImageSource = urls[index];

                Content = stack;  //?  
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            int kategorijaId = int.Parse(button.StyleId);
            Navigation.PushAsync(new EventiPage(kategorijaId));
        }
    }
}