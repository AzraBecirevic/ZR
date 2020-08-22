using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class ProstorOdrzavanjaInsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        [MinLength(2)]
        [MaxLength(60)]
        public string Naziv { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(100)]
        public string Adresa { get; set; }

        [Required]
        public int? TipProstoraOdrzavanjaId { get; set; }

        [Required]
        public int GradId { get; set; }
       
    }
}
