using System;
using System.Collections.Generic;

namespace EventiApplication.WebAPI.Database
{
    public partial class KupovinaTip
    {
        public KupovinaTip()
        {
            Karta = new HashSet<Karta>();
        }

        public int Id { get; set; }
        public int KupovinaId { get; set; }
        public int BrojKarata { get; set; }
        public float Cijena { get; set; }
        public int? ProdajaTipId { get; set; }

        public virtual Kupovina Kupovina { get; set; }
        public virtual ProdajaTip ProdajaTip { get; set; }
        public virtual ICollection<Karta> Karta { get; set; }
    }
}
