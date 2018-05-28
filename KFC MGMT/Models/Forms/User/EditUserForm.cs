using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class EditUserForm : Attribute
    {
        [Display(Name = "ID de l'utilisateur")]
        [Required]        
        public int IdUser { get; set; }

        [Display(Name = "Prénom de l'utilisateur")]
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Display(Name = "Nom de l'utilisateur")]
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Password { get; set; }
        
    }
}