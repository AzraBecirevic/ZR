using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class PozivNaEvent 
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string NazivEventa { get; set; }
        public string DatumEventa { get; set; }     
        public string KorisnikPozivalacImePrezime { get; set; }
        public string KorisnikPozvaniImePrezime { get; set; }
        public int KorisnikPozivalacId { get; set; }
        public int KorisnikPozvaniId { get; set; }
        public bool IsPrihvacen { get; set; }
        public bool IsOdbijen { get; set; }
        public bool IsNeodgovoren { get; set; }

    }
}
