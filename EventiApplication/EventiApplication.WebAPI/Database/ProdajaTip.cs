using System;
using System.Collections.Generic;

//public enum TipKarte { Vip, Parter, Tribina, Obicna }

namespace EventiApplication.WebAPI.Database
{
    public partial class ProdajaTip
    {
        public ProdajaTip()
        {
            KupovinaTip = new HashSet<KupovinaTip>();
        }

        public int Id { get; set; }
     

        public int? TipKarteId { get; set; }
        public TipKarte TipKarte { get; set; }
        public int UkupnoKarataTip { get; set; }
        public int BrojProdatihKarataTip { get; set; }
        public float CijenaTip { get; set; }
        public bool PostojeSjedista { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<KupovinaTip> KupovinaTip { get; set; }
    }
}
