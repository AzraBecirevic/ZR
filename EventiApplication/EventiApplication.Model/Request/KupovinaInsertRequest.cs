using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class KupovinaInsertRequest
    {
        public int KorisnikId { get; set; }
        public int EventId { get; set; }

        public int ProdajaTipId { get; set; }
        public int ZeljeniBrKarata { get; set; }
    }
}
