using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class PozivNaEventInsertRequest
    {
        public int EventId { get; set; }
        public int KorisnikPozivalacId { get; set; }
        public int KorisnikPozvaniId { get; set; }
        public bool IsPrihvacen { get; set; }
        public bool IsOdbijen { get; set; }
    }
}
