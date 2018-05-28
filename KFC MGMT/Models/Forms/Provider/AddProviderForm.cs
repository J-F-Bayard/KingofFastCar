using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class AddProviderForm : Attribute
    {
        [Display(Name = "Nom du fournisseur")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Tva")]
        [Required]
        public string Tva { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Téléphone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Rue")]
        [Required]
        [MinLength(2)]
        public string Street { get; set; }

        [Display(Name = "Numéro")]
        [Required]
        public string Number { get; set; }

        [Display(Name = "CP")]
        [Required]
        public int Zip { get; set; }

        [Display(Name = "Localité")]
        [Required]
        [MinLength(2)]
        public string Locality { get; set; }

        [Display(Name = "Pays")]
        [Required]
        [MinLength(2)]
        public string Country { get; set; }

        [Display(Name = "Numéro de compte")]
        [Required]
        [MinLength(2)]
        public string Account { get; set; }

        [Display(Name = "Actif")]
        [Required]
        public bool Active { get; set; }
    }
}