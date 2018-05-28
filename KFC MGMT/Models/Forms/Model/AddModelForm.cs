using KFC_MGMT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Controllers
{
    public class AddModelForm : Attribute
    {
        [Required]
        [Display(Name = "Nom de la marque")]
        public string BrandName { get; set; }
        public IEnumerable<SelectListItem> BrandList { get; set; }

        [Display(Name = "Nom du modèle")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}