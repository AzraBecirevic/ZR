using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;
using System.Collections.ObjectModel;

namespace EventiApplication.Mobile.ViewModels
{
    public class EventDetaljiViewModel:BaseViewModel
    {
        private readonly APIService _eventService = new APIService("Event");
        private readonly APIService _likeService = new APIService("Like");

        public ObservableCollection<Event> PreporuceniEventiList { get; set; } = new ObservableCollection<Event>();

        public EventDetaljiViewModel()
        {
            ImgTappedCommand = new Command(async () => await ImgTapped());
            GetLocationCommand = new Command(async () => await GetLocation());
           
        }

        private Event Event { get; set; }
        private Like Like { get; set; }

        int EventId = 0;
        bool IsLikean = false;

        private string _imgSource = "hearticonempty.png";
        private string _naziv=string.Empty;
        private string _datumVrijeme = string.Empty;
        private string _adresa = string.Empty;
        private string _opis = string.Empty;
        private string _organizator = string.Empty;

        public ICommand ImgTappedCommand { get; set; }
        public ICommand GetLocationCommand { get; set; }
       

        public string ImgSource
        {
            get { return _imgSource; }
            set { SetProperty(ref _imgSource, value); }
        }

        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }
        public string DatumVrijeme
        {
            get { return _datumVrijeme; }
            set { SetProperty(ref _datumVrijeme, value); }
        }
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }
        public string Organizator
        {
            get { return _organizator; }
            set { SetProperty(ref _opis, value); }
        }
        private byte[] _slika;
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }
        private bool _visible = false;
        public bool Visible
        {
            get { return _visible; }
            set { SetProperty(ref _visible, value); }
        }

        public async Task Init(int id)
        {   //Event
            Event = await _eventService.GetById<Event>(id);
            if (Event == null)
                return;
            EventId = id;
            Naziv = Event.Naziv;
            DatumVrijeme =Event.DatumOdrzavanja.ToShortDateString() +" - " + Event.VrijemeOdrzavanja +" h";
            Adresa = Event.ProstorOdrzavanjaGradAdresa;  
            Opis = Event.Opis;
            Organizator = Event.OrganizatorNaziv;
            Slika = Event.Slika;

            LikeSearchRequest request = new LikeSearchRequest { EventId = id, KorisnikId = Global.Korisnik.Id };
            List<Like> likes = await _likeService.Get<List<Like>>(request);

            if (likes!=null && likes.Count == 1)   
            {
                Like = likes[0];
                IsLikean = true;
                ImgSource = "hearticonfilled.png";
            }

            EventSearchRequest eventSearch = new EventSearchRequest { EventId = id, IsPreporuka = true };
            var preporuceniEventi = await _eventService.Get<List<Event>>(eventSearch);
            if (preporuceniEventi.Count > 0)
                Visible = true;
            PreporuceniEventiList.Clear();
            foreach(var p in preporuceniEventi)
            {
                PreporuceniEventiList.Add(p);
            }
        }

        public async Task ImgTapped ()
        {
            if(IsLikean == false)    // znaci da zeli da like-a
            {
                LikeInsertRequest request = new LikeInsertRequest
                {
                    DatumLajka = DateTime.Now,
                    EventId = this.EventId,
                    KorisnikId = Global.Korisnik.Id
                };
                Like = await _likeService.Insert<Like>(request);
                if (Like != null)
                {
                    IsLikean = true;
                    ImgSource = "hearticonfilled.png";
                }  
            }
            else  //Islikean je true, znaci da zeli da ukloni like
            {
                if(Like != null && Like.Id!=0)  
                {
                    var res = await _likeService.Delete<Like>(Like.Id);
                    IsLikean = false;
                    ImgSource = "hearticonempty.png";
                }
                 
            }
        }

        public async Task GetLocation()
        {
            var address = Event.Adresa; 
            if (Device.RuntimePlatform == Device.UWP)
            {
                try
                {
                    await Launcher.OpenAsync("bingmaps:?where=" + address);
                }
                catch
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Problem sa prikazom lokacije", "OK");

                }
            }
            else if (Device.RuntimePlatform == Device.Android)
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

                    //ili 
                    //  await Launcher.OpenAsync("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA");
                }
                catch
                {
                   await Application.Current.MainPage.DisplayAlert("Info", "Problem sa prikazom lokacije", "OK");
                }

            }
        }

      
    }
}
