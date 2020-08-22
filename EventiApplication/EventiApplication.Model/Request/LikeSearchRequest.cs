using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class LikeSearchRequest
    {
        public int EventId { get; set; }
        public int KorisnikId { get; set; }
    }
}
