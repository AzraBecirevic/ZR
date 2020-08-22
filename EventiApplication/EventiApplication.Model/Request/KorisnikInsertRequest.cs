using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class KorisnikInsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"[0-9]{9}")]
     //   [RegularExpression(@"\d{3}[-]\d{3}[-]\d{3}")]
        public string Telefon { get; set; }

        [Required]
        public int? GradId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(100)]
        public string Adresa { get; set; }

        [Required(AllowEmptyStrings = false)]
        //[MinLength(2)]
        [RegularExpression(@"\d{1,15}")]
        public string PostanskiBroj { get; set; }

    
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(30)]

        
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        public string PasswordConfirmation { get; set; }
        public byte[] Slika { get; set; } = null;
        public byte[] SlikaThumb { get; set; } = null;
    }
}
