using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class ProstorOdrzavanja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int? TipProstoraOdrzavanjaId { get; set; }  
        public TipProstoraOdrzavanja TipProstoraOdrzavanja { get; set; }
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
