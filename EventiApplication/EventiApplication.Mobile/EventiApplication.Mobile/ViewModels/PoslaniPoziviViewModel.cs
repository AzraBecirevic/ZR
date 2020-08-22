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
    public class PoslaniPoziviViewModel : BaseViewModel
    {
        private readonly APIService _pozivNaEventService = new APIService("PozivNaEvent");
        PozivNaEventSearchRequest request = null;

        public PoslaniPoziviViewModel()
        {
            NoviPoziviCommand = new Command(async () => await Init());
            StariPoziviCommand = new Command(async () => await GetStariPozivi());
            PrihvaceniPoziviCommand = new Command(async () => await GetPrihvaceniPozivi());
            OdbijeniPoziviCommand = new Command(async () => await GetOdbijeniPozivi());
            NeodgovoreniPoziviCommand = new Command(async () =>await GetNeodgovoreniPozivi());
        }
        public ObservableCollection<PozivNaEvent> PoziviList { get; set; } = new ObservableCollection<PozivNaEvent>();

        public ICommand NoviPoziviCommand { get; set; }
        public ICommand StariPoziviCommand { get; set; }
        public ICommand OdbijeniPoziviCommand { get; set; }
        public ICommand PrihvaceniPoziviCommand { get; set; }
        public ICommand NeodgovoreniPoziviCommand { get; set; }

        public async Task GetNeodgovoreniPozivi()
        {
            request.NeodgovoreniPozivi = true;
            request.OdbijeniPozivi = false;
            request.PrihvaceniPozivi = false;
            var pozivi = await _pozivNaEventService.Get<List<PozivNaEvent>>(request);

            PoziviList.Clear();

            foreach (var poziv in pozivi)
            {
                PoziviList.Add(poziv);
            }
        }
        public async Task GetOdbijeniPozivi()
        {
            request.OdbijeniPozivi = true;
            request.PrihvaceniPozivi = false;
            request.NeodgovoreniPozivi = false;
            var pozivi = await _pozivNaEventService.Get<List<PozivNaEvent>>(request);

            PoziviList.Clear();

            foreach (var poziv in pozivi)
            {
                PoziviList.Add(poziv);
            }
        }

        public async Task GetPrihvaceniPozivi()
        {
            request.PrihvaceniPozivi = true;
            request.OdbijeniPozivi = false;
            request.NeodgovoreniPozivi = false;
            var pozivi = await _pozivNaEventService.Get<List<PozivNaEvent>>(request);

            PoziviList.Clear();

            foreach (var poziv in pozivi)
            {
                PoziviList.Add(poziv);
            }
        }

        public async Task Init()
        {
           
            request = new PozivNaEventSearchRequest
            {
                PoslaniPozivi = true,
                KorisnikPozivalacId = Global.Korisnik.Id,
                NoviPozivi = true,
             };

            await GetNeodgovoreniPozivi();
         
        }

        public async Task GetStariPozivi()
        {
            
            request = new PozivNaEventSearchRequest
            {
                PoslaniPozivi = true,
                KorisnikPozivalacId = Global.Korisnik.Id,
                StariPozivi = true
            };

            await GetNeodgovoreniPozivi();
        
        }

        public async void ObrisiPoziv(int id)
        {
            if (id > 0)
            {
                PozivNaEvent result = await _pozivNaEventService.Delete<PozivNaEvent>(id);
                if (result != null && result != default(PozivNaEvent))
                {

                    if (request != null && request.NeodgovoreniPozivi)
                        await GetNeodgovoreniPozivi(); 
                    if (request != null  && request.PrihvaceniPozivi)
                        await GetPrihvaceniPozivi();
                    if (request != null && request.NoviPozivi && request.OdbijeniPozivi)
                        await GetOdbijeniPozivi();
                }

            }
        }
    }
}
