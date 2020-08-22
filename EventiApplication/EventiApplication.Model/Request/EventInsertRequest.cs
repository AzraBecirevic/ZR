using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class EventInsertRequest
    {   
        [Required(AllowEmptyStrings =false)]
        [MinLength(2)]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Required]
        public DateTime DatumOdrzavanja { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string VrijemeOdrzavanja { get; set; }
        [Required]
        public int? KategorijaId { get; set; }
        public bool IsOdobren { get; set; }
        public bool IsOtkazan { get; set; }
        [Required]
        public int OrganizatorId { get; set; }
        public int? AdministratorId { get; set; }
        [Required]
        public int ProstorOdrzavanjaId { get; set; }
        //[Required]
        public byte[] Slika { get; set; } = null;
        //[Required]
        public byte[] SlikaThumb { get; set; } = null;
    }
}
