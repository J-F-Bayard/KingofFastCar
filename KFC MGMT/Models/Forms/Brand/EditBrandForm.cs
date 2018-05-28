using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class EditBrandForm : Attribute
    {
        public int IdBrand { get; set; }

        [Display(Name = "Nom de la marque")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}