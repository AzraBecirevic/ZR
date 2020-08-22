using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class OrganizatorInsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        [MaxLength(30)]
        [MinLength(2)]
        public string Naziv { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{9}")]
        //   [RegularExpression(@"\d{3}[-]\d{3}[-]\d{3}")]
        public string Telefon { get; set; }

        [Required] //!=0
        public int? GradId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //public string Username { get; set; }
        //public string PasswordSalt { get; set; }
        //public string PasswordHash { get; set; }
        //public Grad Grad { get; set; }
    }
}
