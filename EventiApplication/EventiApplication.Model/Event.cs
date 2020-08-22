using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public string VrijemeOdrzavanja { get; set; }
        public string KategorijaNaziv { get; set; }
        public int KategorijaId { get; set; }
        public bool IsOdobren { get; set; }
        public bool IsOtkazan { get; set; }
        public int OrganizatorId { get; set; }
        public string OrganizatorNaziv { get; set; }
        public int? AdministratorId { get; set; }
        public int ProstorOdrzavanjaId { get; set; }
        public string ProstorOdrzavanjaGradAdresa { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string DatumOdrz { get; set; }

        public byte[] Slika { get; set; } = null;
        public byte[] SlikaThumb { get; set; } = null;
       
    }
}
