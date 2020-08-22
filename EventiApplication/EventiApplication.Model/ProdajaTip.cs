using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class ProdajaTip
    {
        public int Id { get; set; }
        public int? TipKarteId { get; set; }
       // public TipKarte TipKarte { get; set; }
        public string TipKarteNaziv { get; set; }
        public int UkupnoKarataTip { get; set; }
        public int BrojProdatihKarataTip { get; set; }
        public float CijenaTip { get; set; }
        public bool PostojeSjedista { get; set; }
        public int EventId { get; set; }
        public string EventNaziv { get; set; }
    }
}
