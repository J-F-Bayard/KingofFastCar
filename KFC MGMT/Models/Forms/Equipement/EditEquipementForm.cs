using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class EditEquipementForm : Attribute
    {
        [Display(Name = "Id de l'équipement")]
        [Required]
        
        public int IdEquipement { get; set; }

        [Display(Name = "Nom de l'équipement")]
        
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        
        [MinLength(2)]
        public string Description { get; set; }
    }
}