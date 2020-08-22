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
 
    public class PrijateljstvaViewModel : BaseViewModel
    {
        private readonly APIService _prijateljstvoService = new APIService("Prijateljstvo");
        public ObservableCollection<PrijateljstvoPrikaz> PrijateljstvoList { get; set; } = new ObservableCollection<PrijateljstvoPrikaz>();

       public ICommand GetPoslaniZahtjeviCommand { get; set; }

      
        public async Task Init()
        {
            PrijateljstvoSearchRequest request = new PrijateljstvoSearchRequest
            {
                KorisnikPosiljalacId = Global.Korisnik.Id,
                KorisnikPrimalacId = Global.Korisnik.Id,
                IsPrihvaceno = true
            };
            var prijateljstva = await _prijateljstvoService.Get<List<Prijateljstvo>>(request);

            PrijateljstvoList.Clear();
            foreach (var p in prijateljstva)
            {
                if (p.KorisnikPosiljalacId == Global.Korisnik.Id)   // znaci primalac mu je prijatelj
                {
                    PrijateljstvoPrikaz prijatelj =new PrijateljstvoPrikaz
                    {
                        Id =p.Id,
                        IdPrijatelja = p.KorisnikPrimalacId,
                        ImePrezime = p.ImePrezimePrimaoca,
                        Slika=p.Slika,
                        IsVisible = (p.Slika == null) ? false : true, // false  //ako je slika null false, ako nije onda true
                        IconIsVisible = (p.Slika == null) ? true : false,
                        IconSource = "usericon.png"
                    };
          

                    PrijateljstvoList.Add(prijatelj);
                }
                else   // KorinsikPrimalac je ovah korisnik, posiljalac mu je prijatelj
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
               

                    PrijateljstvoList.Add(prijatelj);
                }
               
            }
        
        }


        public async Task ObrisiPrijateljstvo(int id)
        {
            if (id > 0)
            {
                Prijateljstvo result =await  _prijateljstvoService.Delete<Prijateljstvo>(id);
                if(result !=null || result != default(Prijateljstvo))
                {
                    await Application.Current.MainPage.DisplayAlert("Info", Messages.ObrisanoPrijateljstvo, "Ok");
                }
                await Init();
            }
        }
    }
}
