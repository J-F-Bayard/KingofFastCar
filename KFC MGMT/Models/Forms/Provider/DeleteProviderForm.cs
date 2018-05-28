using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KFC_MGMT.Controllers
{
    public class DeleteProviderForm : Attribute
    {
        [Display(Name = "Id du fournisseur")]
        [Required]
      
        public int IdProvider { get; set; }
    }
}