using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Recenzija
    {
        public int Id { get; set; }
        public string Komentar { get; set; }
        public int KupovinaId { get; set; }

        public virtual Kupovina Kupovina { get; set; }
    }
}
