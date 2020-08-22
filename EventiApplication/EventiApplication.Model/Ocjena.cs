using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Ocjena
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }
       
        public int EventId { get; set; }
      
        public int OcjenaEventa { get; set; }
    }
}
