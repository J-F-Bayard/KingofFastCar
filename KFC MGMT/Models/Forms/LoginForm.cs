using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Models.Forms
{
    public class LoginForm : Attribute
    {

        [Required]
        [EmailAddress()]
        public String Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

    }
}