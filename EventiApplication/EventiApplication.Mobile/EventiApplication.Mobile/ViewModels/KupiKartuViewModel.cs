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
    public class KupiKartuViewModel : BaseViewModel
    {
        private readonly APIService _kupovinaService = new APIService("Kupovina");
        private readonly APIService _prodajaTipService = new APIService("ProdajaTip");
        public int EventId { get; set; } = 0;
        int BrKarata = 1;

        public ObservableCollection<ProdajaTip> ProdajaTipList { get; set; } = new ObservableCollection<ProdajaTip>();

        public List<ProdajaTip> prodajaTipovi { get; set; } = null;

        public KupiKartuViewModel()
        {
            KupiKartuCommand = new Command(async () => await KupiKartu());
            UvecajBrKarataCommand = new Command(() => UvecajBrojKarata());
            SmanjiBrKarataCommand  = new Command(() => SmanjiBrojKarata());

        }

        public ICommand KupiKartuCommand { get; set; }
        public ICommand UvecajBrKarataCommand { get; set; }
        public ICommand SmanjiBrKarataCommand { get; set; }

        

        private ProdajaTip _prodajaTip = null;
        public ProdajaTip ProdajaTip
        {
            get { return _prodajaTip; }
            set { SetProperty(ref _prodajaTip, value); }
        }

        private string _lblProdajaTipErr=string.Empty;
        public string LblProdajaTipErr
        {
            get { return _lblProdajaTipErr; }
            set { SetProperty(ref _lblProdajaTipErr, value); }
        }

        private string _brojKarata = string.Empty;
        public string BrojKarata
        {
            get { return _brojKarata; }
            set { SetProperty(ref _brojKarata, value); }
        }
        public async Task Init()
        {
            ProdajaTipSearchRequest request = new ProdajaTipSearchRequest { EventId = this.EventId };
            prodajaTipovi = await _prodajaTipService.Get<List<ProdajaTip>>(request);
           
            ProdajaTipList.Clear();

            foreach(var p in prodajaTipovi)
            {
                ProdajaTipList.Add(p);
            }

            BrojKarata = BrKarata.ToString();
        }

        public async Task KupiKartu()
        {
            
            if (ProdajaTipValidation() && BrKarata>0)
            {
                KupovinaInsertRequest request = new KupovinaInsertRequest
                {
                    EventId = this.EventId,
                    KorisnikId = Global.Korisnik.Id,
                    ProdajaTipId = ProdajaTip.Id,
                     ZeljeniBrKarata=BrKarata
                };

                var result =await _kupovinaService.Insert<Kupovina>(request);
                if (result != null && result != default(Kupovina))
                    await Application.Current.MainPage.DisplayAlert("Info", "Uspjesno obavljena kupovina", "Ok");
            }
          
         
        }

        private bool ProdajaTipValidation()
        {
            if(ProdajaTip == null)
            {
                LblProdajaTipErr = "Morate izbrati tip karte";
                return false;
            }
            else
            {
                LblProdajaTipErr = null;
                return true;
            }
        }
        void UvecajBrojKarata()
        {
            BrKarata++;
            BrojKarata = BrKarata.ToString();
        }
        void SmanjiBrojKarata()
        {
            BrKarata--;
            if (BrKarata < 1)
                BrKarata = 1;
            BrojKarata = BrKarata.ToString();
        }
    }
}
