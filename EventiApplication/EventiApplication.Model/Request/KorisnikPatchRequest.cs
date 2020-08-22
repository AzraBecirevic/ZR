using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class KorisnikPatchRequest
    {
        public int Id { get; set; }
        public bool IsAktivan { get; set; }
    }
}
