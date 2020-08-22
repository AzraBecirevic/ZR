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
    public class DobijeniZahtijeviViewModel : BaseViewModel
    {
        private APIService _prijateljstvoService = new APIService("Prijateljstvo");
        public ObservableCollection<PrijateljstvoPrikaz> DobijeniZahtjevi { get; set; } = new ObservableCollection<PrijateljstvoPrikaz>();


        public async Task Init()
        {
            PrijateljstvoSearchRequest request = new PrijateljstvoSearchRequest
            {
                KorisnikPrimalacId = Global.Korisnik.Id,
                IsPrihvaceno = false
            };
            var dobijeniZahtjevi = await _prijateljstvoService.Get<List<Prijateljstvo>>(request);

            DobijeniZahtjevi.Clear();

            foreach (var p in dobijeniZahtjevi)
            {
                PrijateljstvoPrikaz zahtjev = new PrijateljstvoPrikaz
                {
                    Id = p.Id,
                    IdPrijatelja = p.KorisnikPosiljalacId,
                    ImePrezime = p.ImePrezimePosiljaoca,
                    Slika = p.Slika,
                    IsVisible = (p.Slika == null) ? false : true,
                    IconIsVisible = (p.Slika == null) ? true : false,
                    IconSource = "usericon.png"
                 };
            
                DobijeniZahtjevi.Add(zahtjev);
            }
        }

        public async Task ObrisiZahtjev(int id)
        {
            if (id <= 0)
                await Application.Current.MainPage.DisplayAlert("Greska", Messages.NemoguceBrisanjeZahtijeva, "Ok");

            Prijateljstvo result = await _prijateljstvoService.Delete<Prijateljstvo>(id);
            if (result != null && result != default(Prijateljstvo))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", Messages.ObrisanZahtjev, "Ok");
            }

        }

        public async Task PrihvatiZahtjev(int id)
        {
            if (id <= 0)
                await Application.Current.MainPage.DisplayAlert("Greska", Messages.ProblemBrisanjaZahtijeva, "Ok");

            else
            {
                PrijateljstvoPatchRequest request = new PrijateljstvoPatchRequest
                {
                    Id = id,
                    IsPrihvaceno = true
                };

                var result = await _prijateljstvoService.UpdateAttribute<Prijateljstvo>(request);

                if (result != null && result != default(Prijateljstvo))
                {
                    await Application.Current.MainPage.DisplayAlert("Info", Messages.PrihvacenZahtjev, "Ok");
                }
            }

        }
    }
}
