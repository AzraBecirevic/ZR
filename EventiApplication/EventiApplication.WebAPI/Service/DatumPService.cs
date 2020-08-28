using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class DatumPService : BaseService<Model.DatumP, DatumPSearchRequest, Database.Event>
    {
        public DatumPService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }


        public override List<DatumP> Get(DatumPSearchRequest search)
        {

            DateTime datum = new DateTime(search.IzabraniDatum.Year, search.IzabraniDatum.Month, search.IzabraniDatum.Day, search.VrijemeEventa.Hours, search.VrijemeEventa.Minutes, 0);
            search.IzabraniDatum = datum; 


            DatumP Preporuka = new DatumP();

            var eventi = _ctx.Event.Where(e => e.KategorijaId == search.KategorijaId).ToList();

            List<int> Sume = new List<int>();
            Sume.Add(0);
            Sume.Add(0);
            Sume.Add(0);
            Sume.Add(0);
            Sume.Add(0);
            Sume.Add(0);
            Sume.Add(0);


            foreach(var e in eventi)
            {
                var suma = _ctx.ProdajaTip.Where(p => p.EventId == e.Id).Sum(p => p.BrojProdatihKarataTip);

                DayOfWeek DanEventa = e.DatumOdrzavanja.DayOfWeek;

                switch (DanEventa)
                {
                    case DayOfWeek.Monday:Sume[0] += suma; break;
                    case DayOfWeek.Tuesday: Sume[1] += suma; break;
                    case DayOfWeek.Wednesday: Sume[2] += suma; break;
                    case DayOfWeek.Thursday: Sume[3] += suma; break;
                    case DayOfWeek.Friday: Sume[4] += suma; break;
                    case DayOfWeek.Saturday: Sume[5] += suma; break;
                    case DayOfWeek.Sunday: Sume[6] += suma; break;
                   

                }
            }

            DayOfWeek PreporuceniDan  = search.IzabraniDatum.DayOfWeek;  
            int najsuma = Sume.Max();
            int index = Sume.IndexOf(najsuma);  
                                                /*  int najvecaSuma = 0;
                                                 for(int i = 0; i < 7; i++)
                                                 {
                                                     if (Sume[i] > najvecaSuma)
                                                         najvecaSuma = Sume[i];
                                                 }
                                                 */
           
            switch (index)
            {
                case 0: PreporuceniDan = DayOfWeek.Monday; break;
                case 1: PreporuceniDan = DayOfWeek.Tuesday; break;
                case 2: PreporuceniDan = DayOfWeek.Wednesday; break;
                case 3: PreporuceniDan = DayOfWeek.Thursday; break;
                case 4: PreporuceniDan = DayOfWeek.Friday; break;
                case 5: PreporuceniDan = DayOfWeek.Saturday; break;
                case 6: PreporuceniDan = DayOfWeek.Sunday; break;
                   
            }

     

            int brojac = 0;
            bool isPrviProvjeren = false;
            DateTime PocetniDatum = search.IzabraniDatum; 
            while (true)
            {
                brojac++;  

                if (brojac > 15)  
                {
                    Preporuka.Poruka = string.Empty;  // ili "nema preporuke"
                    Preporuka.PreporuceniDatum = search.IzabraniDatum;
                    break;
                }
                    
                if( brojac==1 && search.IzabraniDatum.DayOfWeek == PreporuceniDan)
                {
                    isPrviProvjeren = true;


                    Preporuka.Poruka = "Izabrani datum je preporuceni datum. ";   //+ PreporuceniDan.ToString(); 
                    Preporuka.PreporuceniDatum = search.IzabraniDatum;

                    
                    //treba provjeriti da li ima jos evenata na tom prostoru
                   var organizovani = _ctx.Event.Where(e => e.ProstorOdrzavanjaId == search.ProstorOdrzavanjaId)
                        .Where(e => e.DatumOdrzavanja.Date.CompareTo(PocetniDatum.Date) == 0).ToList();

                    bool PostojiEventURazmakuOd10Sati = false;

                    foreach(var o in organizovani)
                    {    
                        if (Math.Abs((o.DatumOdrzavanja - search.IzabraniDatum).TotalHours) < 10)
                            PostojiEventURazmakuOd10Sati = true;
                           
                    }
                    if (organizovani.Count != 0 && PostojiEventURazmakuOd10Sati==false)
                    {
                        // gdje razmak izedju nijedog org eventa i novog nije manji od 10 h
                        Preporuka.PreporuceniDatum = PocetniDatum;
                        Preporuka.Poruka += "Na ovaj datum na izabranom prostoru postoji/e organizovani event/i u satnici/ama: ";
                        foreach (var o in organizovani)
                        {
                            Preporuka.Poruka += o.VrijemeOdrzavanja + ",";
                        }

                      
                        break;
                    }

                    if (PostojiEventURazmakuOd10Sati == false)
                    {
                        Preporuka.IzabranJePreporucen = true;
                           break; 
                    }
                   /* else
                    {
                        Preporuka.Poruka += "postoji event, razmak manji od 10 sati";
                    }   */
                    
                }
               
                  if(!isPrviProvjeren)
                    PocetniDatum = PocetniDatum.AddDays(1);
                  if(isPrviProvjeren)                         
                    PocetniDatum = PocetniDatum.AddDays(7);  // da odmah ide na preporuceni dan 

                if (PocetniDatum.DayOfWeek == PreporuceniDan)    
                { 
                    isPrviProvjeren = true; 

                    // da li je izabrano mjesto slobodno u potpunosti
                    if(_ctx.Event.Where(e=>e.ProstorOdrzavanjaId==search.ProstorOdrzavanjaId)
                        .Where(e => e.DatumOdrzavanja.Date.CompareTo(PocetniDatum.Date) == 0).Count() == 0)
                    {
                        // nema nijedan event na tom prostoru tog dana
                        Preporuka.PreporuceniDatum = PocetniDatum;    
                        
                        Preporuka.Poruka = "Po trendu prodaje karata evenata ove kategorije preporuceni datum " +
                            "za ovaj event je " + PocetniDatum.ToShortDateString() + ", da li zelite promijeniti datum ? ";
                        break;
                    }


                    // ako ima jedan ili vise evenata u razlicito vrijeme na isti datum, prikazati u poruci
                 /*   var organizovani = _ctx.Event.Where(e => e.ProstorOdrzavanjaId == search.ProstorOdrzavanjaId)
                   .Where(e => e.DatumOdrzavanja.Date.CompareTo(PocetniDatum.Date) == 0)
                     /* .Where(e => e.DatumOdrzavanja.TimeOfDay != search.VrijemeEventa).ToList();
                    bool PostojiEventURazmakuOd10Sati = false;
                    foreach (var o in organizovani)
                    {     //Math.abs
                        if (Math.Abs((o.DatumOdrzavanja - search.IzabraniDatum).TotalHours) < 10)
                            PostojiEventURazmakuOd10Sati = true;

                    }
                    if (organizovani.Count != 0 && PostojiEventURazmakuOd10Sati == false)
                    {
                        // gdje razmak izedju nijedog org eventa i novog nije manji od 10 h
                        Preporuka.PreporuceniDatum = PocetniDatum;
                        Preporuka.Poruka += "Preporuceni datum je " + PocetniDatum.ToShortDateString();
                        Preporuka.Poruka += "Na ovaj datum na izabranom prostoru postoji/e organizovani event/i u satnici/ama: ";
                        foreach (var o in organizovani)
                        {
                            Preporuka.Poruka += o.VrijemeOdrzavanja + ",";
                        }

                        break;
                    }*/
                }

              }
              List<Model.DatumP> lista = new List<DatumP>();
              lista.Add(Preporuka);
              return lista;
             
          }
      }
  }
