using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class Sjediste
    {
        public int Id { get; set; }
        public int BrojSjedista { get; set; }
        public int KartaId { get; set; }

        public virtual Karta Karta { get; set; }
    }
}
