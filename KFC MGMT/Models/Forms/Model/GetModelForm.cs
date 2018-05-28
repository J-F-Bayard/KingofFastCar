using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Controllers
{
    public class GetModelForm : Attribute
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdModel { get; set ; }

        [HiddenInput(DisplayValue = false)]
        public int IdBrand { get; set; }

        [Display(Name = "Nom de la marque")]
        [MinLength(2)]
        public string BrandName { get; set; }

        [Display(Name = "Nom du modèle")]
        [MinLength(2)]
        public string Name { get; set; }
        
    }
}