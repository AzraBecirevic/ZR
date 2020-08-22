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
    public class DobijeniPoziviViewModel : BaseViewModel
    {
        private readonly APIService _pozivNaEventService = new APIService("PozivNaEvent");
        PozivNaEventSearchRequest request = null;

        public DobijeniPoziviViewModel()
        {
            NoviPoziviCommand = new Command(async () => await Init());
            PrihvaceniPoziviCommand = new Command(async () => await GetPrihvaceniPozivi());
            OdbijeniPoziviCommand = new Command(async () => await GetOdbijeniPozivi());
        }
        public ObservableCollection<PozivNaEvent> PoziviList { get; set; } = new ObservableCollection<PozivNaEvent>();

        public ICommand NoviPoziviCommand { get; set; }
   
        public ICommand OdbijeniPoziviCommand { get; set; }
        public ICommand PrihvaceniPoziviCommand { get; set; }
        
      
       public async Task PrihvatiPoziv(int id)
        { 
            PozivNaEventPatchRequest patchRequest = new PozivNaEventPatchRequest { Id=id, IsPrihvacen = true };

            PozivNaEvent result = await _pozivNaEventService.UpdateAttribute<PozivNaEvent>(patchRequest);

            if(result!=null && result != default(PozivNaEvent))
            {  
                if (request != null && request.NoviPozivi && request.OdbijeniPozivi)
                    await GetOdbijeniPozivi();
                if (request != null && request.NoviPozivi && request.NeodgovoreniPozivi)
                    await Init();
               
            }             
        }

        public async Task OdbijPoziv (int id)
        {
            PozivNaEventPatchRequest patchRequest = new PozivNaEventPatchRequest { Id = id, IsOdbijen=true };

            PozivNaEvent result = await _pozivNaEventService.UpdateAttribute<PozivNaEvent>(patchRequest);

            if (result != null && result != default(PozivNaEvent))
            {
                await GetPrihvaceniPozivi();
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
                DobijeniPozivi = true,
                KorisnikPozvaniId = Global.Korisnik.Id,
                NoviPozivi = true,
                NeodgovoreniPozivi=true,
                OdbijeniPozivi=false,
                PrihvaceniPozivi =false
            };

            var pozivi = await _pozivNaEventService.Get<List<PozivNaEvent>>(request);

            PoziviList.Clear();

            foreach (var poziv in pozivi)
            {
                PoziviList.Add(poziv);
            }
        }

 
        public async void ObrisiPoziv(int id)
        {
            if (id > 0)
            {
                PozivNaEvent result = await _pozivNaEventService.Delete<PozivNaEvent>(id);
                if (result != null && result != default(PozivNaEvent))
                {
                    if (request != null && request.NeodgovoreniPozivi)
                        await Init();
                    if (request != null && request.OdbijeniPozivi)
                        await GetOdbijeniPozivi();
                    if (request != null && request.PrihvaceniPozivi)
                        await GetPrihvaceniPozivi();
                }
                 
            }
        }
    }
}
