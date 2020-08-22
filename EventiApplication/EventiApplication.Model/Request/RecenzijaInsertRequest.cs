using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class RecenzijaInsertRequest
    {
        public string Komentar { get; set; }
        public int KupovinaId { get; set; }
    }
}
