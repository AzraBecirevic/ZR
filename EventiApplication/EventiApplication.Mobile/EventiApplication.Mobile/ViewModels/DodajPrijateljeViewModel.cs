using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventiApplication.Mobile.ViewModels
{
    public class DodajPrijateljeViewModel: BaseViewModel
    {
        public DodajPrijateljeViewModel()
        {
            PretraziCommand = new Command(async () => await Pretrazi());
        }

        private readonly APIService _korisnikService = new APIService("Korisnik");
        private readonly APIService _prijateljstvoService = new APIService("Prijateljstvo");


        public ICommand PretraziCommand { get; set; }

        public ObservableCollection<KorisnikPrikaz> KorisniciList { get; set; } = new ObservableCollection<KorisnikPrikaz>();

        private string _pretarga = string.Empty;
        public string Pretraga
        {
            get { return _pretarga; }
            set { SetProperty(ref _pretarga, value); }
        }

        public async Task Pretrazi()
        {
            if(!string.IsNullOrEmpty(Pretraga) && !string.IsNullOrWhiteSpace(Pretraga))
            {
               KorisnikSearchRequest request = new KorisnikSearchRequest {
                   Ime = Pretraga, 
                   Prezime = Pretraga, 
                   Username =null,
                   IsUserSearch=true,
                   IdKorisnikaPretrazitelja=Global.Korisnik.Id
               };

                var korisnici = await _korisnikService.Get<List<Korisnik>>(request);
                
                KorisniciList.Clear();

                foreach(var k in korisnici)
                {
                    KorisnikPrikaz korisnik = new KorisnikPrikaz
                    {
                        IconSource = "usericon.png",
                        Id = k.Id,
                        Ime = k.Ime,
                        Prezime = k.Prezime,
                        Slika = k.Slika,
                        IsVisibleSlika = ((k.Slika == null) || k.Slika.Length<=0) ? false : true,
                        IsVisbleIcon = ((k.Slika == null) || k.Slika.Length <= 0) ? true : false
                    };

                    KorisniciList.Add(korisnik);
                }
            }
        }

        public async void DodajPrijatelja(int id)
        {
            if(id != Global.Korisnik.Id)
            {
                PrijateljstvoInsertRequest request = new PrijateljstvoInsertRequest
                {
                    DatumSlanjaZahtjeva = DateTime.Now,
                    IsPrihvaceno = false,
                    KorisnikPosiljalacId = Global.Korisnik.Id,
                    KorisnikPrimalacId = id
                };

                Prijateljstvo result =await _prijateljstvoService.Insert<Prijateljstvo>(request);
                if (result != null || result != default(Prijateljstvo))
                    await Application.Current.MainPage.DisplayAlert("Info", Messages.DodanoPrijateljstvo, "Ok");

                await Pretrazi();
            }
          
        }
    }
}
