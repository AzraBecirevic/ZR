using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Kupovina
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int EventId { get; set; }
        public string EventNaziv { get; set; }
        public string DatumEventa { get; set; }
        public string GradEventa { get; set; }
        public int BrojKupljenihKarata { get; set; }
        public float CijenaSvihKupljenihKarata { get; set; }
        public byte [] SlikaEventa { get; set; }
    }
}
