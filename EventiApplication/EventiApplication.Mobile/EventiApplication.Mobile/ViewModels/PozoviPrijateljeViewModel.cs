using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EventiApplication.Mobile.ViewModels
{
    public class PozoviPrijateljeViewModel : BaseViewModel
    {
        private readonly APIService _pozivNaEventService = new APIService("PozivNaEvent");
        private readonly APIService _prijateljstvoService = new APIService("Prijateljstvo");
        public int EventId = 0;

        private string _poruka = string.Empty;
        public string Poruka
        {
            get { return _poruka; }
            set { SetProperty(ref _poruka, value); }
        }

        public ObservableCollection<PrijateljstvoPrikaz> PrijateljiList { get; set; } = new ObservableCollection<PrijateljstvoPrikaz>();
        public async Task Init()
        {
            PrijateljstvoSearchRequest request = new PrijateljstvoSearchRequest
            {
                KorisnikPosiljalacId = Global.Korisnik.Id,
                KorisnikPrimalacId = Global.Korisnik.Id,
                IsPrihvaceno = true,    //--
                EventId = this.EventId,
                PozivalacId = Global.Korisnik.Id
            };
            var prijateljstva = await _prijateljstvoService.Get<List<Prijateljstvo>>(request);
            if (prijateljstva.Count == 0)
                Poruka = Messages.NemaPrikazanihPrijatelja;

            PrijateljiList.Clear();
            foreach (var p in prijateljstva)
            {
                if (p.KorisnikPosiljalacId == Global.Korisnik.Id)   // znaci primalac mu je prijatelj
                {
                    PrijateljstvoPrikaz prijatelj = new PrijateljstvoPrikaz
                    {
                        Id = p.Id,
                        IdPrijatelja = p.KorisnikPrimalacId,
                        ImePrezime = p.ImePrezimePrimaoca,
                        Slika = p.Slika,
                        IsVisible = (p.Slika == null) ? false : true, // false  //ako je slika null false, ako nije onda true
                        IconIsVisible = (p.Slika == null) ? true : false,
                        IconSource = "usericon.png"
                    };


                    PrijateljiList.Add(prijatelj);
                }
                else   // KorinsikPrimalac je ovaj korisnik, posiljalac mu je prijatelj
                {
                    PrijateljstvoPrikaz prijatelj = new PrijateljstvoPrikaz
                    {
                        Id = p.Id,
                        IdPrijatelja = p.KorisnikPosiljalacId,
                        ImePrezime = p.ImePrezimePosiljaoca,
                        Slika = p.Slika,
                        IsVisible = (p.Slika == null) ? false : true, // false  //ako je slika null false, ako nije onda true
                        IconIsVisible = (p.Slika == null) ? true : false,
                        IconSource = "usericon.png"
                    };


                    PrijateljiList.Add(prijatelj);
                }
            }
        }

        public async void PozoviPrijatelja(int eventId, int prijateljId)
        {
            PozivNaEventInsertRequest request = new PozivNaEventInsertRequest
            {
                EventId = eventId,
                KorisnikPozivalacId = Global.Korisnik.Id,
                KorisnikPozvaniId = prijateljId,
                IsOdbijen = false,
                IsPrihvacen = false
            };

            PozivNaEvent result = await _pozivNaEventService.Insert<PozivNaEvent>(request);

            if (result != null || result != default(PozivNaEvent))
                await Init();
        }
    }
}
