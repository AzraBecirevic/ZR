using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class PrijateljstvoPatchRequest
    {
        public int Id { get; set; }
        public bool IsPrihvaceno { get; set; }
    }
}
