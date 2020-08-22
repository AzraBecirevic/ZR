using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class OcjenaInsertRequest
    {
        public int KorisnikId { get; set; }
      
        public int EventId { get; set; }
       
        public int OcjenaEventa { get; set; }
    }
}
