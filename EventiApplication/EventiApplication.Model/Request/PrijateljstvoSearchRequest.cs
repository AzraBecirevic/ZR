using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class PrijateljstvoSearchRequest
    {
   //     public int Id { get; set; }
        public int KorisnikPosiljalacId { get; set; }
        public int KorisnikPrimalacId { get; set; }
        public bool IsPrihvaceno { get; set; }

        public int EventId { get; set; }
        public int PozivalacId { get; set; }
    }
}
