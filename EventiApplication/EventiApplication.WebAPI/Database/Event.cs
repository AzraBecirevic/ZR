using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{ 
    public partial class Event
    {
        public Event()
        {
       
            Kupovina = new HashSet<Kupovina>();
            Like = new HashSet<Like>();
            ProdajaTip = new HashSet<ProdajaTip>();
      
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public string VrijemeOdrzavanja { get; set; }

        public int? KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }
     
        public bool IsOdobren { get; set; }
        public bool IsOtkazan { get; set; }
        public int OrganizatorId { get; set; }
        public int? AdministratorId { get; set; }
        public int ProstorOdrzavanjaId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual Organizator Organizator { get; set; }
        public virtual ProstorOdrzavanja ProstorOdrzavanja { get; set; }
    
        public virtual ICollection<Kupovina> Kupovina { get; set; }
        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<ProdajaTip> ProdajaTip { get; set; }
   
    }
}
