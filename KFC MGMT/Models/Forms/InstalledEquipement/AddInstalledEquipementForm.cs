using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class AddInstalledEquipementForm : Attribute
    {
        [Display(Name = "Id voiture")]
        [Required]
       
        public int IdCar { get; set; }

        [Display(Name = "Id Equipement")]
        [Required]
        
        public int IdEquipement { get; set; }

    }
}