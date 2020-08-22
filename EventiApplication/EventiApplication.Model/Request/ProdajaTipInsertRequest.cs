using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class ProdajaTipInsertRequest
    {
        [Required]
        public int? TipKarteId { get; set; }
        //public TipKarte TipKarte { get; set; }

        [Required]
        public int UkupnoKarataTip { get; set; }
     //   public int BrojProdatihKarataTip { get; set; } = 0;  // a pri insertu ce autoamtski biti 0
        
        [Required]
        public float CijenaTip { get; set; }
        public bool PostojeSjedista { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}
