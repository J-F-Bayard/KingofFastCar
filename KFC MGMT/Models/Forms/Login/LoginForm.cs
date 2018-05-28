using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Models.Forms.Login
{
    public class LoginForm : Attribute
    {
        [Required]
        [EmailAddress()]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }

        public bool Authentified { get; set; }

       
    }
}