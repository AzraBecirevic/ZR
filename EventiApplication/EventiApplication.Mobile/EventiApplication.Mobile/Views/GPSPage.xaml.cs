using EventiApplication.Model.Request;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventiApplication.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPSPage : ContentPage
    {
        public GPSPage()
        {
            InitializeComponent();
        }
        private readonly APIService _eventiService = new APIService("Event");
       
        List<Model.Event> Eventi = new List<Model.Event>();
        protected async override void OnAppearing()
        {
            base.OnAppearing();


            try
            {

                //trenutna lokacija korisnika
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });



              
                /* var locator = CrossGeolocator.Current;
                 locator.DesiredAccuracy = 50;

                 var positions = await locator.GetPositionsForAddressAsync("Obala Kulina bana 9, Sarajevo");
                  var pozicija = positions?.FirstOrDefault();                    
                 if (pozicija != null)
                 {
                      AdrLong.Text = pozicija.Longitude.ToString();
                      AdrLat.Text =  pozicija.Latitude.ToString();
                 }   
                 else
                 {
                     AdrLong.Text = "Pozicija Je Null";
                     AdrLat.Text = "Pozicija Je Null";

                 }
                 */



                EventSearchRequest request = new EventSearchRequest
                {
                    IsGps = true,
                    IsOdobren = true,
                    IsOtkazan = false,
                    TrenutniDatum = DateTime.Now,
                    TrenutnoVrijeme = DateTime.Now.TimeOfDay
                };

                var eventi = await _eventiService.Get<List<Model.Event>>(request);
               
                foreach (var e in eventi)
                {
                    var positions = await Geocoding.GetLocationsAsync(e.Adresa);
                    var pozicija = positions?.FirstOrDefault();
                    if (pozicija != null && location != null)
                    {
                       
                        var udaljenost = GetDistance(location.Longitude, location.Latitude, pozicija.Longitude, pozicija.Latitude);
                        udaljenost = udaljenost / 1000;
                        udaljenost = Math.Round(udaljenost);

                        if (udaljenost <= 20)
                        {
                            Eventi.Add(e);
                        }
                    }
                }
                if(eventi==null || eventi.Count == 0 || Eventi.Count()==0)
                {
                    Poruka.Text = "Trenutno nema najavljenih evenata u vasoj blizini";
                    Poruka.IsVisible = true;
                }
                else    
                    lista.ItemsSource = Eventi;
               
            }
            catch(Exception ex)
            {
                await DisplayAlert("Poruka", "Trenutno nije moguce prikazati GPS preporuku", "OK");
            }

            //obrnuto

            /*  var addrs = (await Geocoding.GetPlacemarksAsync(new Location(location.Latitude, location.Longitude))).FirstOrDefault();

              var Street = $"{addrs.Thoroughfare} {addrs.SubThoroughfare}";
              var City = $"{addrs.PostalCode} {addrs.Locality}";
              var Country = addrs.CountryName;

              PunaAdresa.Text = Street + " - " + City + " - " + Country;*/
            
        }


        public double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton imgBtn = sender as ImageButton;
            var id = imgBtn.CommandParameter.ToString();
            int idEventa = int.Parse(id);

            var Event = Eventi.Where(ev => ev.Id == idEventa).FirstOrDefault();

            if (Event != null)
            {
                var address = Event.Adresa;
               
                if (Device.RuntimePlatform == Device.Android)
                {
                    try
                    {
                        var locations = await Geocoding.GetLocationsAsync(address);

                        var location = locations?.FirstOrDefault();
                        if (location != null)
                        {
                            var Location = new Location(location.Latitude, location.Longitude);
                            var options = new MapLaunchOptions { Name = address, NavigationMode = NavigationMode.None };
                            await Map.OpenAsync(Location, options);
                        }

                      
                    }
                    catch
                    {
                        await Application.Current.MainPage.DisplayAlert("Info", "Problem sa prikazom lokacije", "OK");
                    }
                }
            }
        }
    }
}





