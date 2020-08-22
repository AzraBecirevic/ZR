using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventiApplication.Mobile.ViewModels
{
    public class PoslaniZahtijeviViewModel : BaseViewModel
    {
        private APIService _prijateljstvoService = new APIService("Prijateljstvo");
       public  ObservableCollection<PrijateljstvoPrikaz> PoslaniZahtjevi { get; set; } = new ObservableCollection<PrijateljstvoPrikaz>();

  
        public async Task Init()
        {
            PrijateljstvoSearchRequest request = new PrijateljstvoSearchRequest
            {
                KorisnikPosiljalacId = Global.Korisnik.Id,
                IsPrihvaceno = false
            };
            var poslaniZahtjevi = await _prijateljstvoService.Get<List<Prijateljstvo>>(request);
            
            PoslaniZahtjevi.Clear();

            foreach(var p in poslaniZahtjevi)
            {
                PrijateljstvoPrikaz zahtjev = new PrijateljstvoPrikaz
                {
                        Id=p.Id,
                        IdPrijatelja = p.KorisnikPrimalacId,
                        ImePrezime = p.ImePrezimePrimaoca,
                        Slika = p.Slika,
                        IsVisible = (p.Slika == null) ? false : true,
                        IconIsVisible = (p.Slika == null) ? true : false,
                        IconSource = "usericon.png"
                };

                PoslaniZahtjevi.Add(zahtjev);
            }
        }

        public async Task ObrisiZahtjev(int id)
        {
            if (id <= 0)
               await Application.Current.MainPage.DisplayAlert("Greska", Messages.NemoguceBrisanjeZahtijeva, "Ok");
            else
            {
                Prijateljstvo result = await _prijateljstvoService.Delete<Prijateljstvo>(id);
                if (result != null && result != default(Prijateljstvo))
                {
                    await Application.Current.MainPage.DisplayAlert("Info", Messages.ObrisanZahtjev, "Ok");
                }
                await Init();
            }
           
        }
    }
}
