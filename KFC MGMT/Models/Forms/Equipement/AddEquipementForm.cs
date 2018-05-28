using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class AddEquipementForm : Attribute
    {
        [Display(Name = "Nom de l'équipement")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required]
        [MinLength(2)]
        public string Description { get; set; }
    }
}