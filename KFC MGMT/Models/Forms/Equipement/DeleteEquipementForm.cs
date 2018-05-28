using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class DeleteEquipementForm : Attribute
    {
        [Display(Name = "Id de l'équipement")]
        [Required]

        public int IdEquipement { get; set; }
    }
}