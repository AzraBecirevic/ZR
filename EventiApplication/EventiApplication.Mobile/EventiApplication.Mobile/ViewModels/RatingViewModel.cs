using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventiApplication.Mobile.ViewModels
{
    public class RatingViewModel : BaseViewModel
    {
        private readonly APIService _ocjenaService = new APIService("Ocjena");
        Ocjena Ocjena = null;
        int ocjena;
        int EventId { get; set; }

        public RatingViewModel()
        {
            Z1TappedCommand = new Command(() => Z1Tapped());
            Z2TappedCommand = new Command(() => Z2Tapped());
            Z3TappedCommand = new Command(() => Z3Tapped());
            Z4TappedCommand = new Command(() => Z4Tapped());
            Z5TappedCommand = new Command(() => Z5Tapped());
            SpasiOcjenuCommand = new Command(async() =>await SpasiOcjenu());
        }

        private string _imgSourceZ1 = "star.png";
        public string ImgSourceZ1
        {
            get { return _imgSourceZ1; }
            set { SetProperty(ref _imgSourceZ1, value); }
        }

        private string _imgSourceZ2 = "star.png";
        public string ImgSourceZ2
        {
            get { return _imgSourceZ2; }
            set { SetProperty(ref _imgSourceZ2, value); }
        }

        private string _imgSourceZ3 = "star.png";
        public string ImgSourceZ3
        {
            get { return _imgSourceZ3; }
            set { SetProperty(ref _imgSourceZ3, value); }
        }

        private string _imgSourceZ4 = "star.png";
        public string ImgSourceZ4
        {
            get { return _imgSourceZ4; }
            set { SetProperty(ref _imgSourceZ4, value); }
        }

        private string _imgSourceZ5 = "star.png";
        public string ImgSourceZ5
        {
            get { return _imgSourceZ5; }
            set { SetProperty(ref _imgSourceZ5, value); }
        }
        private string _poruka = string.Empty;
        public string Poruka
        {
            get { return _poruka; }
            set { SetProperty(ref _poruka, value); }
        }
        public ICommand Z1TappedCommand { get; set; }
        public ICommand Z2TappedCommand { get; set; }
        public ICommand Z3TappedCommand { get; set; }
        public ICommand Z4TappedCommand { get; set; }
        public ICommand Z5TappedCommand { get; set; }
        public ICommand SpasiOcjenuCommand { get; set; }


        public void Z1Tapped()
        {
            if(ImgSourceZ1 == "star.png")   //nije tapped
            {
                ImgSourceZ1 = "starfilled.png";
                ocjena++;
            }
            else   //Img source je starFilled pa je zvijezda tapped, sto znaci da uklnaja tu ocjenu
            {
                ImgSourceZ1 = "star.png";
                ocjena--;
            }
        }
        public void Z2Tapped()
        {
            if (ImgSourceZ2 == "star.png")   //nije tapped
            {
                ImgSourceZ2 = "starfilled.png";
                ocjena++;
            }
            else   //Img source je starFilled pa je zvijezda tapped, sto znaci da uklnaja tu ocjenu
            {
                ImgSourceZ2 = "star.png";
                ocjena--;
            }
        }

        public void Z3Tapped()
        {
            if (ImgSourceZ3 == "star.png")   //nije tapped
            {
                ImgSourceZ3 = "starfilled.png";
                ocjena++;
            }
            else   //Img source je starFilled pa je zvijezda tapped, sto znaci da uklnaja tu ocjenu
            {
                ImgSourceZ3 = "star.png";
                ocjena--;
            }
        }

        public void Z4Tapped()
        {
            if (ImgSourceZ4 == "star.png")   //nije tapped
            {
                ImgSourceZ4 = "starfilled.png";
                ocjena++;
            }
            else   //Img source je starFilled pa je zvijezda tapped, sto znaci da uklnaja tu ocjenu
            {
                ImgSourceZ4 = "star.png";
                ocjena--;
            }
        }

        public void Z5Tapped()
        {
            if (ImgSourceZ5 == "star.png")   //nije tapped
            {
                ImgSourceZ5 = "starfilled.png";
                ocjena++;
            }
            else   //Img source je starFilled pa je zvijezda tapped, sto znaci da uklnaja tu ocjenu
            {
                ImgSourceZ5 = "star.png";
                ocjena--;
            }
        }

        public async Task SpasiOcjenu()
        {
       
            if (ocjena > 0)
            {
                OcjenaInsertRequest request = new OcjenaInsertRequest
                {
                    EventId = this.EventId,
                    KorisnikId = Global.Korisnik.Id,
                    OcjenaEventa = ocjena
                };

                if (Ocjena == null)    // prvi put ocjenjuje
                {
                    var result = await _ocjenaService.Insert<Ocjena>(request);
                    if(result != null && result!= default(Ocjena))
                        await Application.Current.MainPage.DisplayAlert("Info", Messages.OcjenaUspjesnoSpasena, "Ok");
                }
                else
                {
                    if (Ocjena.OcjenaEventa != ocjena)
                    {
                        var result = await _ocjenaService.Update<Ocjena>(Ocjena.Id, request);
                        if (result != null && result != default(Ocjena))
                            await Application.Current.MainPage.DisplayAlert("Info", Messages.OcjenaUspjesnoIzmijenjena, "Ok");
                    } 
                }
                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Info", Messages.OcjenaVecaOd0, "Ok");
            }
        }

  
        public async Task Init(int eventId)
        {
            EventId = eventId;
            OcjenaSearchRequest request = new OcjenaSearchRequest { EventId = eventId, KorisnikId = Global.Korisnik.Id };
            List<Ocjena>ocjene = await _ocjenaService.Get<List<Ocjena>>(request);

            if (ocjene != null && ocjene.Count==1)
            {
                Ocjena = ocjene[0];
                switch (Ocjena.OcjenaEventa)
                {
                    case 1: ImgSourceZ1 = "starfilled.png"; break;
                    case 2: ImgSourceZ1 = "starfilled.png"; ImgSourceZ2= "starfilled.png"; break;
                    case 3: ImgSourceZ1 = "starfilled.png"; ImgSourceZ2 = "starfilled.png"; ImgSourceZ3 = "starfilled.png"; break;
                    case 4: ImgSourceZ1 = "starfilled.png"; ImgSourceZ2 = "starfilled.png"; ImgSourceZ3 = "starfilled.png"; ImgSourceZ4 = "starfilled.png";  break;
                    case 5: ImgSourceZ1 = "starfilled.png"; ImgSourceZ2 = "starfilled.png"; ImgSourceZ3 = "starfilled.png"; ImgSourceZ4 = "starfilled.png"; ImgSourceZ5="starfilled.png"; break;
                    default: break; 
                }
                ocjena = Ocjena.OcjenaEventa;
                Poruka = "Ovaj event ste ocijenili sa ocjenom " + ocjena;
            }

        }
    } 
}
