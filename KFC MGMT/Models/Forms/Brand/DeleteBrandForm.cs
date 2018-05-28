using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class DeleteBrandForm : Attribute
    {
        public int IdBrand { get; set; }

        [Display(Name = "Nom de la marque")]
        public string Name { get; set; }
    }
}