using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class AdministratorInsertRequest
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Ime { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Prezime { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{9}")]
        //   [RegularExpression(@"\d{3}[-]\d{3}[-]\d{3}")]
        public string Telefon { get; set; }

        [Required]
        public int? GradId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password{ get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string PasswordConfirmation { get; set; }
    }
}
