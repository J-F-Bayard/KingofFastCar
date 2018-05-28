using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Controllers
{
    public class EditModelForm : Attribute
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdModel { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdBrand { get; set; }

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