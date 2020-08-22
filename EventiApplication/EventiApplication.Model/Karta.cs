using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Karta
    {
        public int Id { get; set; }
        public int? TipKarteId { get; set; }
        // public TipKarte TipKarte { get; set; }
        public string TipKarteNaziv { get; set; }
        public float Cijena { get; set; }
        public int KupovinaTipId { get; set; }
        public string DatumKupovine { get; set; }
        public byte[] QrCode { get; set; }
    }
}
