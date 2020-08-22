using System;
using System.Collections.Generic;


namespace EventiApplication.WebAPI.Database
{
    public partial class ProstorOdrzavanja
    {
        public ProstorOdrzavanja()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }

        public int? TipProstoraOdrzavanjaId { get; set; }
        public TipProstoraOdrzavanja TipProstoraOdrzavanja { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }

        
      
        public virtual ICollection<Event> Event { get; set; }
    }
}
