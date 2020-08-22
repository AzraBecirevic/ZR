using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Karta
    {
        public Karta()
        {
            Sjediste = new HashSet<Sjediste>();
        }

        public int Id { get; set; }
        public int? TipKarteId { get; set; }
        public TipKarte TipKarte { get; set; }
        public float Cijena { get; set; }
        public int KupovinaTipId { get; set; }
        public DateTime DatumKupovine { get; set; }

        public byte[] QrCode { get; set; } 

        public virtual KupovinaTip KupovinaTip { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }
    }
}
